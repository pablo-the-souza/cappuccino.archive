using System;
using System.Collections.Generic;
using Archive.API.Entities;

namespace Archive.API.Services
{
    public interface IArchiveBoxRepository
    {    
        ArchiveBox GetBox(Guid archiveBoxId);
        IEnumerable<ArchiveBox> GetBoxes(IEnumerable<Guid> archiveBoxIds);
        void AddBox(ArchiveBox archiveBox);
        void DeleteBox(ArchiveBox archiveBox);
        void UpdateBox(ArchiveBox archiveBox);
        bool BoxExists(Guid archiveBoxId);
        bool Save();
    }
}
