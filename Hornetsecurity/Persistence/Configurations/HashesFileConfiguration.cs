using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Hornetsecurity.Models;

namespace Hornetsecurity.Persistence.Configurations
{
    internal class HashesFileConfiguration : IEntityTypeConfiguration<HashesFile>
    {
        public void Configure(EntityTypeBuilder<HashesFile> builder)
        {

            builder.ToTable("HashesFile");
            builder.HasKey(t => t.Path);

            builder.Property(t => t.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            builder.Property(t => t.Path)
                    .HasMaxLength(500)
                    .IsRequired();

            builder.Property(t => t.Md5)
                    .HasMaxLength(2000);
            builder.Property(t => t.Sha1)
                    .HasMaxLength(2000);
            builder.Property(t => t.Sha256)
                    .HasMaxLength(2000);


            //public string Md5 { get; set; }
            //public string Sha1 { get; set; }
            //public string Sha256 { get; set; }

            //public int Scanned { get; set; }
            //public DateTime? LastSeen { get; set; }
        }
    }
}