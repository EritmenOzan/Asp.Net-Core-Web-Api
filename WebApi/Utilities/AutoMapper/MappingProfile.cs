using OpenQA.Selenium.DevTools.V127.Profiler;
using AutoMapper;
using Profile = AutoMapper.Profile;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>();   
        }
    }
}
