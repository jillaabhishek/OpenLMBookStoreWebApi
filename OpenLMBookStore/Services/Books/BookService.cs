using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Books
{
    public class BookService : IBook
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;


        public BookService(BookStoreDbContext dbContext, IMapper mapper, ILogger<BookService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookModel> AddBook(BookModel bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);

            if (string.IsNullOrEmpty(book.BookId))
                book.BookId = Guid.NewGuid().ToString();

            _dbContext.Attach(book.Author);
            _dbContext.Attach(book.Publisher);

            _dbContext.Books.Add(book);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<BookModel>(book);
        }

        public async Task<HttpResponseMessage> DeleteBook(string bookId)
        {
            Book book = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId.Equals(bookId));

            HttpResponseMessage response;

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();

                response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                response.RequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"Book {book.Name} Deleted");
            }
            else
            {
                response = new HttpResponseMessage(System.Net.HttpStatusCode.ExpectationFailed);
                response.RequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"Book not found using BookId {book.BookId}");
            }

            return await Task.FromResult(response);
        }

        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            IList<Book> book = await _dbContext.Books
                            .Include(x => x.Author)
                            .Include(x => x.Publisher)
                            .AsNoTracking()
                            .ToListAsync();

            return _mapper.Map<IList<BookModel>>(book);
        }

        public async Task<BookModel> GetBookById(string bookId)
        {
            Book book = await _dbContext.Books
                                        .Include(x => x.Author)
                                        .Include(x => x.Publisher)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.BookId.Equals(bookId));

            return _mapper.Map<BookModel>(book);
        }

        public async Task<BookModel> UpdateBook(string bookId, BookModel bookDto)
        {
            Book existingBook = await _dbContext.Books
                                           .Include(x => x.Author)
                                           .Include(x => x.Publisher)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(x => x.BookId.Equals(bookId));

            if (existingBook != null)
            {
                Book updateBook = _mapper.Map<Book>(bookDto);
                _dbContext.Books.Update(updateBook);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<BookModel>(updateBook);
            }

            return null;
        }
    }
}
