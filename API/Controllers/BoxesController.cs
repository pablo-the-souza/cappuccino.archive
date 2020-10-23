
using API.Data;
using Archive.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/boxes")]
    public class BoxesController : ControllerBase
    {
        private readonly ArchiveContext _context;

        public BoxesController(ArchiveContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ArchiveBox>> GetBoxes()
        {
            return _context.ArchiveBoxes.ToList();
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

