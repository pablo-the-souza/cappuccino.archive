using System;
using System.Collections.Generic;
using API.Data.Helpers;
using Archive.API.Entities;
using Archive.API.ResourceParameters;

namespace Archive.API.Services
{
    public interface IArchiveBoxRepository
    {   
        IEnumerable<ArchiveBox> GetBoxes(); 
        PagedList<ArchiveBox> GetBoxes(BoxesResourceParameters boxesResourceParameters); 
        ArchiveBox GetBox(Guid boxId);
        void AddBox(ArchiveBox archiveBox);
        void DeleteBox(ArchiveBox archiveBox);
        void UpdateBox(ArchiveBox archiveBox);
        bool BoxExists(Guid boxId);
        bool Save();
    }
}
