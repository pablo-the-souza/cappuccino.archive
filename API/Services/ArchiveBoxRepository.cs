

using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using Archive.API.Entities;

namespace Archive.API.Services
{
    public class ArchiveBoxRepository : IArchiveBoxRepository, IDisposable
    {
        private readonly ArchiveContext _context;

        public ArchiveBoxRepository(ArchiveContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

public IEnumerable<ArchiveBox> GetBoxes()
        {
            return _context.ArchiveBoxes.ToList<ArchiveBox>();
        }
        // public IEnumerable<ArchiveBox> GetBoxes(IEnumerable<Guid> archiveBoxIds)
        // {
        //     if (archiveBoxIds == null)
        //     {
        //         throw new ArgumentNullException(nameof(archiveBoxIds));
        //     }

        //     return _context.ArchiveBoxes.Where(a => archiveBoxIds.Contains(a.Id))
        //         .OrderBy(a => a.Name)
        //         .ToList();
        // }
        // public void AddBox(ArchiveBox archiveBox)
        // {
        //     if (archiveBox == null)
        //     {
        //         throw new ArgumentNullException(nameof(archiveBox));
        //     }

        //     // the repository fills the id (instead of using identity columns)
        //     archiveBox.Id = Guid.NewGuid();

        //     foreach (var course in archiveBox.ArchiveFiles)
        //     {
        //         course.Id = Guid.NewGuid();
        //     }

        //     _context.ArchiveBoxes.Add(archiveBox);
        // }

        // public bool BoxExists(Guid archiveBoxId)
        // {
        //     if (archiveBoxId == Guid.Empty)
        //     {
        //         throw new ArgumentNullException(nameof(archiveBoxId));
        //     }

        //     return _context.ArchiveBoxes.Any(a => a.Id == archiveBoxId);
        // }

        // public void DeleteBox(ArchiveBox archiveBox)
        // {
        //     if (archiveBox == null)
        //     {
        //         throw new ArgumentNullException(nameof(archiveBox));
        //     }

        //     _context.ArchiveBoxes.Remove(archiveBox);
        // }
        
        // public ArchiveBox GetBox(Guid archiveBoxId)
        // {
        //     if (archiveBoxId == Guid.Empty)
        //     {
        //         throw new ArgumentNullException(nameof(archiveBoxId));
        //     }

        //     return _context.ArchiveBoxes.FirstOrDefault(a => a.Id == archiveBoxId);
        // }

        // public void UpdateBox(ArchiveBox archiveBox)
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
