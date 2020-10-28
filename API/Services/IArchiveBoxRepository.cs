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
        Task<IEnumerable<ArchiveBox>> GetBoxes(); 
        Task<PagedList<ArchiveBox>> GetBoxes(BoxesResourceParameters boxesResourceParameters); 
        Task<ArchiveBox> GetBox(Guid boxId);
        void AddBox(ArchiveBox archiveBox);
        void DeleteBox(ArchiveBox archiveBox);
        void UpdateBox(ArchiveBox archiveBox);
        bool BoxExists(Guid boxId);
        bool Save();
    }
}
