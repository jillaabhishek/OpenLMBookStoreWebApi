using OpenLMBookStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Authors
{
    public interface IAuthor
    {
        Task<AuthorModel> GetAllBooks(string authorId);

        Task<IEnumerable<AuthorModel>> GetAllAuthor();
    }
}
