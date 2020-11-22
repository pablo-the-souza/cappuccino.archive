

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Helpers;
using Archive.API.Entities;
using Archive.API.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace Archive.API.Services
{
    public class ArchiveBoxRepository : IArchiveBoxRepository, IDisposable
    {
        private ArchiveContext _context;

        public ArchiveBoxRepository(ArchiveContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ArchiveBox>> GetBoxesAsync()
        {
            return await _context.ArchiveBoxes.ToListAsync<ArchiveBox>();
        }

        public Task<PagedList<ArchiveBox>> GetBoxesAsync(BoxesResourceParameters boxesResourceParameters)
        {
            if (boxesResourceParameters == null) 
            {
                throw new ArgumentNullException(nameof(boxesResourceParameters));
            }

            //deferred execution
            var collection = _context.ArchiveBoxes as IQueryable<ArchiveBox>;

            if(!string.IsNullOrWhiteSpace(boxesResourceParameters.searchByName)) 
            {
                var searchByName = boxesResourceParameters.searchByName.Trim();
                collection = collection.Where(b => b.Name.Contains(searchByName));
            }

            if(!string.IsNullOrWhiteSpace(boxesResourceParameters.searchByCode)) 
            {
                var searchByCode = boxesResourceParameters.searchByCode.Trim();
                collection = collection.Where(b => b.Code.Contains(searchByCode));
            }     
           
            

            if (!string.IsNullOrWhiteSpace(boxesResourceParameters.OrderBy))
            {
                switch (boxesResourceParameters.OrderBy)
                {
                    case "name":
                        collection = collection.OrderBy(b => b.Name);
                        break;
                    case "code":
                        collection = collection.OrderBy(b => b.Code);
                        break; 
                    case "code desc":
                        collection = collection.OrderByDescending(b => b.Code);
                        break; 
                    default:
                        throw new ArgumentNullException(nameof(boxesResourceParameters.OrderBy));
                }
            }


            return PagedList<ArchiveBox>.Create(collection,
                boxesResourceParameters.PageNumber,
                boxesResourceParameters.PageSize); 
        }

        public async Task<ArchiveBox> GetBoxAsync(Guid archiveBoxId)
        {
            if (archiveBoxId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(archiveBoxId));
            }

            return await _context.ArchiveBoxes.FirstOrDefaultAsync(a => a.Id == archiveBoxId);
        }

        // Not async because not I/O bound
        public void AddBox(ArchiveBox archiveBox)
        {
            if (archiveBox == null)
            {
                throw new ArgumentNullException(nameof(archiveBox));
            }

            // the repository fills the id (instead of using identity columns)
            // archiveBox.Id = Guid.NewGuid();

            _context.ArchiveBoxes.Add(archiveBox);
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
        
        public bool BoxExists(Guid boxId)
        {
            if (boxId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(boxId));
            }

            return _context.ArchiveBoxes.Any(a => a.Id == boxId);
        }

        public void DeleteBox(ArchiveBox archiveBox)
        {
            if (archiveBox == null)
            {
                throw new ArgumentNullException(nameof(archiveBox));
            }

            _context.ArchiveBoxes.Remove(archiveBox);
        }

        public void UpdateBox(ArchiveBox archiveBox)
        {
            // no code in this implementation
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
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
               if (_context != null) 
               {
                   _context.Dispose();
                   _context = null; 
               }
            }
        }
    }
}
