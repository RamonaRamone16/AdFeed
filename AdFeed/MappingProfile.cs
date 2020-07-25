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
            AdToAdCreateModelMap();
            AdToAdModelMap();
            CommentToCommentModelMap();
            CommentCreateModelToCommentMap();
        }

        public void AdCreateModelToAdMap()
        {
            CreateMap<AdCreateModel, Ad>()
                .ForMember(to => to.UpdatedOnDate, from => from.MapFrom(p => DateTime.Now))
                .ForMember(target => target.Images,
                    src => src.Ignore()); 
        }

        public void AdToAdCreateModelMap()
        {
            CreateMap<Ad, AdCreateModel>()
                .ForMember(target => target.Images,
                    src => src.Ignore());
        }

        public void AdToAdModelMap()
        {
            CreateMap<Ad, AdModel>()
                .ForMember(to => to.Category, from => from.MapFrom(p => p.Category.Name));
        }

        public void CommentToCommentModelMap()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(to => to.Author, from => from.MapFrom(p => p.Author.UserName));
        }

        public void CommentCreateModelToCommentMap()
        {
            CreateMap<CommentCreateModel, Comment>()
                .ForMember(to => to.Date, from => from.MapFrom(p => DateTime.Now));
        }
    }
}
