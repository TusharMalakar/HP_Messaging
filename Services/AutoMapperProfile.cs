using System;
using AutoMapper;
using HP_Messaging.Data.Entities;
using HP_Messaging.Models;

namespace HP_Messaging.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        : this("MyProfile")
        {
        }

        protected AutoMapperProfile(string profileName) : base(profileName)
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
            CreateMap<MessageReply, MessageReplyModel>().ReverseMap();
        }
        
    }
}
