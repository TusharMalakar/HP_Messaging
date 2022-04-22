using System;
using AutoMapper;
using HP_Messaging.Entities;
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
            CreateMap<ChatUser, ChatUserModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
            CreateMap<MessageType, MessageTypeModel>().ReverseMap();
        }
        
    }
}
