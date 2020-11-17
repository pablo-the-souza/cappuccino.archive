
using API.Data;
using Archive.API.Entities;
using Archive.API.ResourceParameters;
using Archive.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archivr.API.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly IArchiveFileRepository _archiveFileRepository;

        public FilesController(IArchiveFileRepository archiveFileRepository)
        {
            _archiveFileRepository = archiveFileRepository ??
                throw new ArgumentNullException(nameof(archiveFileRepository));
        }

        [HttpGet()]
        public async Task<IActionResult> GetFiles()
        {
            var filesFromRepo = await _archiveFileRepository.GetFilesAsync();
            return Ok(filesFromRepo);
        }

        [HttpGet("{id}", Name = "GetFile")]
        public async Task<IActionResult> GetFileById(Guid id)
        {
            var fileFromRepo = await _archiveFileRepository.GetFileAsync(id);

            if(fileFromRepo == null)
            {
                return NotFound();  
            }

            return Ok(fileFromRepo);
        }

        [HttpPost]
        public async Task<ActionResult> AddFile(ArchiveFile file)
        {
            _archiveFileRepository.AddFile(file);

            await _archiveFileRepository.SaveChangesAsync();

            return CreatedAtRoute("GetFile", new { id = file.Id }, file);
        }

        // [HttpDelete("{id}")]
        // public ActionResult<file> Deletefile(int id)
        // {
        //     var fileForDeletion = _context.files.FirstOrDefault(r => r.Id == id);
        //     _context.files.Remove(fileForDeletion);
        //     _context.SaveChanges();
        //     return Ok();
        // }

        // [HttpPut("{id}")]
        // public ActionResult<file> Updatefile(int id, [FromBody] file file)
        // {
        //     var fileForUpdate = _context.files.FirstOrDefault(r => r.Id == id);

        //     fileForUpdate.Date = file.Date; 
        //     fileForUpdate.Name = file.Name; 
        //     fileForUpdate.Value = file.Value;
        //     fileForUpdate.Category = file.Category; 
        //     fileForUpdate.Type = file.Date; 

        //     _context.SaveChanges();

        //     return Ok();
        // }
    }
}

