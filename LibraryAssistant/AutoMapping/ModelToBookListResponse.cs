using AutoMapper;
using LibraryAssistant.Domain.Models;
using LibraryAssistant.Resources.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.AutoMapping
{
    public class ModelToBookListResponse : Profile
    {
        public ModelToBookListResponse()
        {
            CreateMap<Book, BookListResponse>();
        }
    }
}
