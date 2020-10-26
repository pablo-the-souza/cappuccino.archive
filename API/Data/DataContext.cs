using System;
using Archive.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ArchiveContext : DbContext
    {
        public ArchiveContext(DbContextOptions<ArchiveContext> options) : base(options) { }

        public DbSet<ArchiveBox> ArchiveBoxes { get; set; }
        public DbSet<ArchiveFile> ArchiveFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<ArchiveBox>().HasData(
                new ArchiveBox()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Berry",
                    Code = "ABC123"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Nancy",
                    Code = "ABD123"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Eli",
                    Code = "ABC124"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Arnold",
                    Code = "ABE125"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Name = "Seabury",
                    Code = "FBC129"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Name = "Rutherford",
                    Code = "GBC723"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    Name = "Atherton",
                    Code = "AMC663"
                }, 
                new ArchiveBox()
                {
                    Id = Guid.Parse("f6632e52-adfb-4623-a73c-49d63a7b4dbd"),
                    Name = "Mackenzie",
                    Code = "ABC123"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("80d195e3-fa6a-4e6b-bb11-b39770fac04d"),
                    Name = "Nantucket",
                    Code = "ABD123"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("a7d6b0c5-d06c-46ed-b8d6-d89f6d65b0a7"),
                    Name = "Jorge",
                    Code = "ABC124"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("5a2af4bb-34eb-4041-9a0c-906905b15ac0"),
                    Name = "Gracie",
                    Code = "ABE125"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("fa19ebda-ab4b-435d-9842-1ed4f85e541d"),
                    Name = "Hemingway",
                    Code = "FBC129"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("18f9eec5-53f1-4a3a-a289-13283f4634e7"),
                    Name = "Gretzky",
                    Code = "GBC723"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("3f330133-0007-440a-b326-bdef6c93d01f"),
                    Name = "Lagertha",
                    Code = "AMC663"
                }
                );

                






            modelBuilder.Entity<ArchiveFile>().HasData(
               new ArchiveFile()
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   ArchiveBoxId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Commandeering a Ship Without Getting Caught",
                   Code = "AMJ613"
               },
               new ArchiveFile()
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   ArchiveBoxId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Overthrowing Mutiny",
                   Code = "CMC463"
               },
               new ArchiveFile()
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   ArchiveBoxId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Name = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                   Code = "IHC192"
               },
               new ArchiveFile()
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   ArchiveBoxId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Name = "Singalong Pirate Hits",
                   Code = "JUR771"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}