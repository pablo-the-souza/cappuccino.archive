
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveBox>> Deletebox(Guid id)
        {
            var fileFromRepo = await _archiveFileRepository.GetFileAsync(id);

            if (fileFromRepo == null)
            {
                return NotFound();
            }

            _archiveFileRepository.DeleteFile(fileFromRepo);
            await _archiveFileRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArchiveFile>> UpdateFile(Guid id, ArchiveFile archiveFile)
        {
            var fileFromRepo = await _archiveFileRepository.GetFileAsync(id);

            if (fileFromRepo == null)
            {
                return NotFound();
            }

            fileFromRepo.Name = archiveFile.Name;
            fileFromRepo.Code = archiveFile.Code;

            await _archiveFileRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}

