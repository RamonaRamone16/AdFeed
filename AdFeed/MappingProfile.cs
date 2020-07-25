using AdFeed.DAL.Entities;
using AdFeed.Models;
using AutoMapper;
using System;

namespace AdFeed
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AdCreateModelToAdMap();
            AdToAdModelMap();
        }

        public void AdCreateModelToAdMap()
        {
            CreateMap<AdCreateModel, Ad>()
                .ForMember(to => to.Date, from => from.MapFrom(p => DateTime.Now))
                .ForMember(target => target.Images,
                    src => src.Ignore()); 
        }

        public void AdToAdModelMap()
        {
            CreateMap<Ad, AdModel>()
                .ForMember(to => to.Category, from => from.MapFrom(p => p.Category.Name));
        }
    }
}
