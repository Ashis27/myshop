using AutoMapper;
using MediatR;
using MyShop.Consumer.Application.DTO;
using MyShop.Consumer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Consumer.Application.Domain;

namespace MyShop.Consumer.Application.QueryAndHandlers
{
    public class ConsumerQueryHandler : IRequestHandler<GetConsumerQuery, UserDto>
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public ConsumerQueryHandler(IUserQueryRepository queryRepository,IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetConsumerQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User, UserDto>(await _queryRepository.GetUserAsync(request.Id));

            return user;
        }
    }
}
