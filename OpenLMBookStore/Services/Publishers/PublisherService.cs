using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Publishers
{
    public class PublisherService : IPublisher
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public PublisherService(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PublisherModel> GetAllBooks(string publisherId)
        {
            Publisher publisher = await _dbContext.Publishers
                                                  .FirstOrDefaultAsync(x => x.PublisherId == publisherId);

            return _mapper.Map<PublisherModel>(publisher);
        }

        public async Task<IEnumerable<PublisherModel>> GetAllPublisher()
        {
            IList<Publisher> publishers = await _dbContext.Publishers.ToListAsync();

            return _mapper.Map<IList<PublisherModel>>(publishers);
        }
    }
}
