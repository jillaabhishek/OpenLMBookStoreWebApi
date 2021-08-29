using OpenLMBookStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Books
{
    public interface IBook
    {
        Task<BookModel> AddBook(BookModel bookDto);

        Task<BookModel> GetBookById(string bookId);

        Task<IEnumerable<BookModel>> GetAllBooks();

        Task<BookModel> UpdateBook(string bookId, BookModel bookDto);

        Task<HttpResponseMessage> DeleteBook(string bookId);
    }
}
