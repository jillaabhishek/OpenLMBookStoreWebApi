using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IBook _book;
        public UserController(IBook book)
        {
            _book = book;
        }

        [HttpGet("GetBookById/{bookId}")]        
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

        [HttpGet("GetAllBooks")]
        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            return await _book.GetAllBooks();
        }

        [HttpGet("GetBestSellerBooks")]
        public async Task<IEnumerable<BookModel>> GetBestSellerBooks()
        {
            var booksDto = await _book.GetAllBooks();

            if (booksDto != null)
                return booksDto.Where(x => x.IsBookBestSeller).ToList();

            return booksDto;                             
        }
    }
}
