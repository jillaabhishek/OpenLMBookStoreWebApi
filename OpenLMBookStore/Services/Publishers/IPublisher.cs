using OpenLMBookStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Publishers
{
    public interface IPublisher
    {
        Task<PublisherModel> GetAllBooks(string publisherId);

        Task<IEnumerable<PublisherModel>> GetAllPublisher();
    }
}
