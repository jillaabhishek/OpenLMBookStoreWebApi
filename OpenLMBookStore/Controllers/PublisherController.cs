using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities.Authentication;
using OpenLMBookStore.Services.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin+","+UserRoles.Publisher)]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisher _publisherService;

        public PublisherController(IPublisher publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("GetAllBooks/{publisherId}")]
        public async Task<ActionResult<PublisherModel>> GetAllBooks(string publisherId)
        {
            if (!string.IsNullOrEmpty(publisherId))
            {
                PublisherModel publisherDto = await _publisherService.GetAllBooks(publisherId);

                if (publisherDto == null) return NotFound();

                return publisherDto;
            }

            return BadRequest("publisherId can't be null");
        }

        [HttpGet("GetAllPublisher")]
        public async Task<IEnumerable<PublisherModel>> GetAllPublisher()
        {
            return await _publisherService.GetAllPublisher();
        }
    }
}
