using System;
using System.Collections.Generic;
using Archive.API.Entities;

namespace Archive.API.Services
{
    public interface IArchiveBoxRepository
    {   
        IEnumerable<ArchiveBox> GetBoxes(); 
        ArchiveBox GetBox(Guid archiveBoxId);
        // void AddBox(ArchiveBox archiveBox);
        // void DeleteBox(ArchiveBox archiveBox);
        // void UpdateBox(ArchiveBox archiveBox);
        // bool BoxExists(Guid archiveBoxId);
        bool Save();
    }
}
