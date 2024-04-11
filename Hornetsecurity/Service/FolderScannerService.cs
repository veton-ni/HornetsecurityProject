using Hornetsecurity.Models;
using Hornetsecurity.Persistence;
using Hornetsecurity.Utils;

namespace Hornetsecurity.Service
{
    internal class FolderScannerService
    {

        private HashesFileRepository _repository;
        private Dictionary<string, HashesFile> _files;

        public FolderScannerService()
        {
            _repository = new HashesFileRepository(new AppDbContext());
            _files = _repository.GetAll().ToHashSet().ToDictionary(x => x.Path);
        }

        public void SaveChangesToDB()
        {
            var newFiles = GetFileDetails().Select(x => x.Value).Where(x => x.Scanned == 0).ToList();
            var updateFiles = GetFileDetails().Select(x => x.Value).Where(x => x.Scanned > 1).ToList();


            newFiles.ForEach(x => x.Scanned++);

            _repository.AddRange(newFiles);
            foreach(var udpate in updateFiles)
            {
                _repository.Update(udpate);
            }

            _repository.Complete();

        }

        public Dictionary<string, HashesFile> GetFileDetails() => _files;


        public void ScanFolderMultiThread(string path)
        {
            List<Task> TaskList = new List<Task>();

            foreach (var file in GetAllFilesInFolder(path))
            {
                var taks = new Task<int>(() => ScanFile(file));
                taks.Start();
                TaskList.Add(taks);
            }

            Task.WaitAll(TaskList.ToArray());

            Console.WriteLine($"All threads are finished!");
        }
        private List<string> GetAllFilesInFolder(string path)
        {
            List<string> files = new();

            if (FileUtils.IsPathValid(path))
            {
                string[] fileEntries = Directory.GetFiles(path);
                files.AddRange(fileEntries);

                string[] subdirectoryEntries = Directory.GetDirectories(path);
                foreach (string subdirectory in subdirectoryEntries)
                    files.AddRange(GetAllFilesInFolder(subdirectory));

            }
            return files;
        }
        private int ScanFile(string path)
        {
            if (GetFileDetails().ContainsKey(path))
            {
                var file = _files[path];
                file.LastSeen = DateTime.Now;
                file.Scanned++;
                return 1;
            }

            HashesFile fileDetail = FileUtils.ScanFile(path);
            GetFileDetails().Add(path, fileDetail);
            return 1;
        }


    }
}
