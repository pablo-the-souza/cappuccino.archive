

using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using Archive.API.Entities;

namespace Archive.API.Services
{
    public class ArchiveFileRepository : IArchiveFileRepository, IDisposable
    {

        
        private readonly ArchiveContext _context;

        public ArchiveFileRepository(ArchiveContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

         public IEnumerable<ArchiveFile> GetFiles()
        {

            return _context.ArchiveFiles
                .OrderBy(f => f.Name).ToList();
        }

         public ArchiveFile GetFile(Guid fileId)
        {

            if (fileId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(fileId));
            }

            return _context.ArchiveFiles
              .Where(c => c.Id == fileId).FirstOrDefault();
        }

        // public void AddArchiveFile(ArchiveFile archiveFile)
        // {

        //     if (archiveFile == null)
        //     {
        //         throw new ArgumentNullException(nameof(ArchiveFile));
        //     }
        //     // always set the AuthorId to the passed-in authorId
        //     _context.ArchiveFiles.Add(archiveFile); 
        // }         

        // public void DeleteArchiveFile(ArchiveFile archiveFile)
        // {
        //     _context.ArchiveFiles.Remove(archiveFile);
        // }

        // public void UpdateArchiveFile(ArchiveFile archiveFile)
        // {
        //     // no code in this implementation
        // }



        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
