
using API.Data.Helpers;
using Archive.API.Entities;
using Archive.API.ResourceParameters;
using Archive.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

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

        [HttpGet(Name = "GetBoxes")]
        public async Task<IActionResult> GetBoxes([FromQuery] BoxesResourceParameters boxesResourceParameters)
        {
            var boxesFromRepo = await _archiveBoxRepository.GetBoxesAsync(boxesResourceParameters);

            var previousPageLink = boxesFromRepo.HasPrevious ? 
                CreateBoxesResourceUri(boxesResourceParameters, ResourceUriType.Previous): null; 

            var nextPageLink = boxesFromRepo.HasNext ? 
                CreateBoxesResourceUri(boxesResourceParameters, ResourceUriType.Next): null; 

            var paginationMetadata  = new 
            {
                totalCount = boxesFromRepo.TotalCount,
                pageSize = boxesFromRepo.PageSize,
                currentPage = boxesFromRepo.CurrentPage,
                totalPages = boxesFromRepo.TotalPages,
                previousPageLink,
                nextPageLink
            }; 
            
            //Add Response Header to Response
            Response.Headers.Add("X-Pagination", 
                JsonSerializer.Serialize(paginationMetadata));
                

            return Ok(boxesFromRepo);
        }

        [HttpGet("{id}", Name = "GetBox")]
        public async Task<IActionResult> GetBoxById(Guid id)
        {

            var boxFromRepo = await _archiveBoxRepository.GetBoxAsync(id);

            if (boxFromRepo == null)
            {
                return NotFound();
            }

            return Ok(boxFromRepo);
        }

        [HttpPost]
        public ActionResult<ArchiveBox> AddBox(ArchiveBox archiveBox)
        {
            if (archiveBox == null)
            {
                return BadRequest();
            }

            _archiveBoxRepository.AddBox(archiveBox);
            _archiveBoxRepository.SaveChangesAsync();

            return CreatedAtRoute("GetBox", new { id = archiveBox.Id }, archiveBox);
        }

        [HttpPut("{boxId}")]
        public async Task<ActionResult<ArchiveBox>> UpdateBox(Guid boxId, ArchiveBox archiveBox)
        {
            var boxFromRepo = await _archiveBoxRepository.GetBoxAsync(boxId);

            if (boxFromRepo == null)
            {
                return NotFound();
            }

            boxFromRepo.Name = archiveBox.Name;
            boxFromRepo.Code = archiveBox.Code;

            await _archiveBoxRepository.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchiveBox>> Deletebox(Guid id)
        {
            var boxFromRepo = await _archiveBoxRepository.GetBoxAsync(id);

            if (boxFromRepo == null)
            {
                return NotFound();
            }

            _archiveBoxRepository.DeleteBox(boxFromRepo);
            await _archiveBoxRepository.SaveChangesAsync();

            return NoContent();
        }

        private string CreateBoxesResourceUri(
            BoxesResourceParameters boxesResourceParameters,
            ResourceUriType type
        )
        {
            switch (type)
            {
                case ResourceUriType.Previous:
                    return Url.Link("GetBoxes",
                    new
                    {
                        pageNumber = boxesResourceParameters.PageNumber - 1,
                        pageSize = boxesResourceParameters.PageSize,
                        searchByName = boxesResourceParameters.searchByName,
                        searchByCode = boxesResourceParameters.searchByCode,
                    });

                case ResourceUriType.Next:
                    return Url.Link("GetBoxes",
                    new
                    {
                        pageNumber = boxesResourceParameters.PageNumber + 1,
                        pageSize = boxesResourceParameters.PageSize,
                        searchByName = boxesResourceParameters.searchByName,
                        searchByCode = boxesResourceParameters.searchByCode,
                    });

                default:
                    return Url.Link("GetBoxes",
                    new
                    {
                        pageNumber = boxesResourceParameters.PageNumber - 1,
                        pageSize = boxesResourceParameters.PageSize,
                        searchByName = boxesResourceParameters.searchByName,
                        searchByCode = boxesResourceParameters.searchByCode,
                    });
            }
        }
    }
}

