using AutoMapper;
using MyShop.Consumer.Application.Commands.Address;
using MyShop.Consumer.Application.Domain;
using MyShop.Consumer.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Infrastructure.Automapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<AddressCommand, Address>();
            CreateMap<User, UserDto>();
        }
    }
}
