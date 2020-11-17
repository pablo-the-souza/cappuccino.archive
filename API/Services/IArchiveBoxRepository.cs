using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Helpers;
using Archive.API.Entities;
using Archive.API.ResourceParameters;

namespace Archive.API.Services
{
    public interface IArchiveBoxRepository
    {   
        Task<IEnumerable<ArchiveBox>> GetBoxesAsync(); 
        Task<PagedList<ArchiveBox>> GetBoxesAsync(BoxesResourceParameters boxesResourceParameters); 
        Task<ArchiveBox> GetBoxAsync(Guid Id);
        void AddBox(ArchiveBox archiveBox);
        void DeleteBox(ArchiveBox archiveBox);
        void UpdateBox(ArchiveBox archiveBox);
        bool BoxExists(Guid boxId);
        Task <bool> SaveChangesAsync();
    }
}
