
using API.Data.Helpers;
using Archive.API.Entities;
using Archive.API.ResourceParameters;
using Archive.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

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
        public IActionResult GetBoxes([FromQuery] BoxesResourceParameters boxesResourceParameters)
        {
            var boxesFromRepo = _archiveBoxRepository.GetBoxes(boxesResourceParameters);

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
        public IActionResult GetBoxById(Guid id)
        {

            var boxFromRepo = _archiveBoxRepository.GetBox(id);

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
            _archiveBoxRepository.Save();

            return CreatedAtRoute("GetBox", new { id = archiveBox.Id }, archiveBox);
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

        [HttpDelete("{id}")]
        public ActionResult<ArchiveBox> Deletebox(Guid id)
        {
            var boxFromRepo = _archiveBoxRepository.GetBox(id);

            if (boxFromRepo == null)
            {
                return NotFound();
            }

            _archiveBoxRepository.DeleteBox(boxFromRepo);
            _archiveBoxRepository.Save();

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

