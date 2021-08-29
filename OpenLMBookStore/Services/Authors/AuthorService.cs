using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Authors
{
    public class AuthorService : IAuthor
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorService(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAuthor()
        {
            IList<Author> authors = await _dbContext.Authors.ToListAsync();

            return _mapper.Map<IList<AuthorModel>>(authors);
        }

        public async Task<AuthorModel> GetAllBooks(string authorId)
        {
            Author author = await _dbContext.Authors
                                            .FirstOrDefaultAsync(x => x.AuthorId == authorId);

            return _mapper.Map<AuthorModel>(author);
        }
    }
}
