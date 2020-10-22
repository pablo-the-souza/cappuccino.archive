using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Services
{
    public interface ICourseLibraryRepository
    {    
        IEnumerable<Course> GetCourses(Guid authorId);
        Course GetCourse(Guid authorId, Guid courseId);
        void AddCourse(Guid authorId, ArchiveFile archiveFile);
        void UpdateCourse(ArchiveFile archiveFile);
        void DeleteCourse(ArchiveFile archiveFile);
        bool Save();
    }
}
