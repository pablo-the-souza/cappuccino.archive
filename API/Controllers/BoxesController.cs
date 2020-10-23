
using API.Data;
using Archive.API.Entities;
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
        
        [HttpGet]
        public IActionResult GetBoxes()
        {
            var boxesFromRepo = _archiveBoxRepository.GetBoxes();
            return new JsonResult(boxesFromRepo);
        }

        // [HttpGet("{id}", Name = "GetRecordById")]
        // public ActionResult<Record> GetRecordById(int id)
        // {
        //     return _context.Records.Find(id);
        // }

        // [HttpPost]
        // public ActionResult<Record> AddRecord(Record record)
        // {
        //     _context.Records.Add(record);
        //     _context.SaveChanges();

        //     return CreatedAtAction("GetRecordById", new { id = record.Id }, record);
        // }

        // [HttpDelete("{id}")]
        // public ActionResult<Record> DeleteRecord(int id)
        // {
        //     var recordForDeletion = _context.Records.FirstOrDefault(r => r.Id == id);
        //     _context.Records.Remove(recordForDeletion);
        //     _context.SaveChanges();
        //     return Ok();
        // }

        // [HttpPut("{id}")]
        // public ActionResult<Record> UpdateRecord(int id, [FromBody] Record record)
        // {
        //     var recordForUpdate = _context.Records.FirstOrDefault(r => r.Id == id);
            
        //     recordForUpdate.Date = record.Date; 
        //     recordForUpdate.Name = record.Name; 
        //     recordForUpdate.Value = record.Value;
        //     recordForUpdate.Category = record.Category; 
        //     recordForUpdate.Type = record.Date; 

        //     _context.SaveChanges();

        //     return Ok();
        // }
    }
}

