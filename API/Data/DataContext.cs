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
                    Code = "ABC123",
                    DestructionFlag = "NEVER",
                    Reference = "AB12",
                    DateLeftOffice = new DateTimeOffset(),
                    Comments = "This is a comment"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Nancy",
                    Code = "ABD123",
                    DestructionFlag = "NEVER",
                    Reference = "AB12",
                    DateLeftOffice = new DateTimeOffset(),
                    Comments = "This is a comment"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Eli",
                    Code = "ABC124",
                    DestructionFlag = "NEVER",
                    Reference = "AB12",
                    DateLeftOffice = new DateTimeOffset(),
                    Comments = "This is a comment"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Arnold",
                    Code = "ABE125",
                    DestructionFlag = "NEVER",
                    Reference = "AB12",
                    DateLeftOffice = new DateTimeOffset(),
                    Comments = "This is a comment"
                },
                new ArchiveBox()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Name = "Seabury",
                    Code = "FBC129",
                    DestructionFlag = "NEVER",
                    Reference = "AB12",
                    DateLeftOffice = new DateTimeOffset(),
                    Comments = "This is a comment"
                }
                );

                






            modelBuilder.Entity<ArchiveFile>().HasData(
               new ArchiveFile()
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   ArchiveBoxId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Commandeering a Ship",
                   Code = "AMJ613",
                   PolicyType = "Type 1",
                   PolicyNumber = "Number 1",
                   DateStart = new DateTimeOffset(),
                   DateEnd = new DateTimeOffset(),
                   Comments = "This is a small comment"

               },
               new ArchiveFile()
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   ArchiveBoxId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Overthrowing Mutiny",
                   Code = "CMC463",
                   PolicyType = "Type 2",
                   PolicyNumber = "Number 2",
                   DateStart = new DateTimeOffset(),
                   DateEnd = new DateTimeOffset(),
                   Comments = "This is a great comment"
               },
               new ArchiveFile()
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   ArchiveBoxId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Name = "Avoiding Brawls ",
                   Code = "IHC192",
                   PolicyType = "Type 3",
                   PolicyNumber = "Number 4",
                   DateStart = new DateTimeOffset(),
                   DateEnd = new DateTimeOffset(),
                   Comments = "This is a stupid comment"
               },
               new ArchiveFile()
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   ArchiveBoxId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Name = "Singalong Pirate Hits",
                   Code = "JUR771",
                   PolicyType = "Type 4",
                   PolicyNumber = "Number 4",
                   DateStart = new DateTimeOffset(),
                   DateEnd = new DateTimeOffset(),
                   Comments = "This is a smart comment"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}