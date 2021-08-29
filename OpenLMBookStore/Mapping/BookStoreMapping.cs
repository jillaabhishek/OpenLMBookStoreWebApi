using AutoMapper;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Mapping
{
    public class BookStoreMapping : Profile
    {
        public BookStoreMapping()
        {
            CreateMap<BookModel, Book>()
                .ForMember(book => book.Category, x => x.MapFrom(y => y.Category.ToString()))
                .ForMember(book => book.BookBinding, x => x.MapFrom(y => y.BookBinding.ToString()))
                .ReverseMap();

            CreateMap<Author, AuthorModel>().ReverseMap();

            CreateMap<Publisher, PublisherModel>().ReverseMap();

            CreateMap<Order, OrderModel>().ReverseMap();

            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}
