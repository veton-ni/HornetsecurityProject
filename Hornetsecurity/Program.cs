using Hornetsecurity.Persistence;
using Hornetsecurity.Service;
using Hornetsecurity.Utils;


public class Program
{
    static FolderScannerService _folderScannerService = new();
    const int leftPad = 25;

    static void Main(string[] args)
    {
        MigrationManager.ApplyMigrations();

        while (true)
        {
            Console.Write("Folder Path:");
            var command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
                continue;

            if (command?.ToLower() == "exit") break;

            if (!FileUtils.IsFolderPathValid(command!))
            {
                Console.WriteLine("Invalid path! Please try agen!");
                continue;
            }


            ScaningFolder(Path.GetFullPath(command!));

            Console.WriteLine($"-- List Of Files");
            Console.WriteLine($" {"FileName",leftPad},  {"Scanned",leftPad},  {"LastSeen",leftPad}");
            
            foreach (var file in _folderScannerService.GetFileDetails())
            {
                Console.WriteLine($" {file.Value.Name,leftPad},  {file.Value.Scanned,leftPad},  {file.Value.LastSeen?.ToString("dd-MM-yyyy hh:mm:ss"),leftPad}");
            }


        }

        Console.WriteLine("- End of proces!");
    }

    private static void ScaningFolder(string path)
    {
        var watch = new System.Diagnostics.Stopwatch();

        watch.Start();
        _folderScannerService.ScanFolderMultiThread(path);
        watch.Stop();

        Console.WriteLine($"-- Number of Files: {_folderScannerService.GetFileDetails().Count}");
        Console.WriteLine($"-- Execution Time: {watch.ElapsedMilliseconds} ms");

        _folderScannerService.SaveChangesToDB();
    }


}











