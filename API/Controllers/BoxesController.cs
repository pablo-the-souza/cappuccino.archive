
using API.Data;
using Archive.API.Entities;
using Archive.API.ResourceParameters;
using Archive.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/boxes")]
    public class BoxesController : ControllerBase
    {
        private readonly IArchiveBoxRepository _archiveBoxRepository;

        public BoxesController(IArchiveBoxRepository archiveBoxRepository)
        {
            _archiveBoxRepository = archiveBoxRepository ??
                throw new ArgumentNullException(nameof(archiveBoxRepository));
        }
        
        [HttpGet()]
        public IActionResult GetBoxes([FromQuery] BoxesResourceParameters boxesResourceParameters)
        {
            var boxesFromRepo = _archiveBoxRepository.GetBoxes(boxesResourceParameters);
            return Ok(boxesFromRepo);
        }

        [HttpGet("{id}", Name=  "GetBox")]
        public IActionResult GetBoxById(Guid id)
        {
            
            var boxFromRepo = _archiveBoxRepository.GetBox(id);

            if(boxFromRepo == null)
            {
                return NotFound();  
            }

            return Ok(boxFromRepo);
        }

        [HttpPost]
        public ActionResult<ArchiveBox> AddBox(ArchiveBox archiveBox)
        {
           if(archiveBox == null) 
           {
               return BadRequest();
           }

            _archiveBoxRepository.AddBox(archiveBox);
            _archiveBoxRepository.Save();

            return CreatedAtRoute("GetBox", new {  id = archiveBox.Id }, archiveBox);
        }

        [HttpPut("{boxId}")]
        public ActionResult<ArchiveBox> UpdateBox(Guid boxId, ArchiveBox archiveBox)
        {
            var boxFromRepo = _archiveBoxRepository.GetBox(boxId);

            if (boxFromRepo == null)
            {
                return NotFound();
            }

            boxFromRepo.Name = archiveBox.Name; 
            boxFromRepo.Code = archiveBox.Code; 

            _archiveBoxRepository.Save();

            return NoContent();
            
        }

        // [HttpDelete("{id}")]
        // public ActionResult<box> Deletebox(int id)
        // {
        //     var boxForDeletion = _context.boxs.FirstOrDefault(r => r.Id == id);
        //     _context.boxs.Remove(boxForDeletion);
        //     _context.SaveChanges();
        //     return Ok();
        // }

        
    }
}

