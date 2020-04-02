using AutoMapper;
using LibraryAssistant.Domain.Models;
using LibraryAssistant.Resources.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.AutoMapping
{
    public class BookRequestToBookModelProfile : Profile
    {
        public BookRequestToBookModelProfile()
        {
            CreateMap<BookCreateRequestModified, Book>();
        }
    }
}
