using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities.Authentication;
using OpenLMBookStore.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace OpenLMBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook _book;
        public BooksController(IBook book)
        {
            _book = book;
        }

        [HttpGet("{bookId}")]
        [Authorize]
        public async Task<ActionResult<BookModel>> GetBookById(string bookId)
        {
            if (!string.IsNullOrEmpty(bookId))
            {
                BookModel bookDto = await _book.GetBookById(bookId);

                if (bookDto == null)
                    return NotFound();

                return bookDto;
            }
            else
            {
                return BadRequest($"BookId {bookId} was null or empty");
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<BookModel>> AddBook(BookModel bookDto)
        {
            if (bookDto != null)
                return await _book.AddBook(bookDto);

            return BadRequest("Book model was null");
        }

        [HttpPut("{bookId}")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Publisher)]
        public async Task<ActionResult<BookModel>> UpdateBook(string bookId, BookModel bookDto)
        {
            if (bookDto == null)
                return NotFound();

            if (bookId != bookDto.BookId)
            {
                return BadRequest("Parameter BookId and model bookId doesn't match.");
            }

            if (bookDto != null)
                return await _book.UpdateBook(bookId, bookDto);

            return BadRequest("Book model was null");
        }

        [HttpDelete("{bookId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> DeleteBook(string bookId)
        {
            if (string.IsNullOrEmpty(bookId))
                return BadRequest("BookId is null");

            await _book.DeleteBook(bookId);
            return Ok();
        }
    }
}
