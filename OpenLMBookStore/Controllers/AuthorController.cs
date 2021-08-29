using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities.Authentication;
using OpenLMBookStore.Services.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Author )]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _authorService;

        public AuthorController(IAuthor authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("getallbooks/{authorId}")]
        public async Task<ActionResult<AuthorModel>> GetAllBooks(string authorId)
        {
            if (!string.IsNullOrEmpty(authorId))
            {
                AuthorModel authorDto = await _authorService.GetAllBooks(authorId);

                if (authorDto == null) return NotFound();

                return authorDto;
            }

            return BadRequest("AuthorId can't be null");
        }

        [HttpGet("getallauthors")]
        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            return await _authorService.GetAllAuthor();
        }
    }
}
