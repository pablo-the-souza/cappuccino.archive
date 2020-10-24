using System;
using System.Collections.Generic;
using Archive.API.Entities;
using Archive.API.ResourceParameters;

namespace Archive.API.Services
{
    public interface IArchiveBoxRepository
    {   
        IEnumerable<ArchiveBox> GetBoxes(); 
        IEnumerable<ArchiveBox> GetBoxes(BoxesResourceParameters boxesResourceParameters); 
        ArchiveBox GetBox(Guid boxId);
        void AddBox(ArchiveBox archiveBox);
        void DeleteBox(ArchiveBox archiveBox);
        void UpdateBox(ArchiveBox archiveBox);
        bool BoxExists(Guid boxId);
        bool Save();
    }
}
