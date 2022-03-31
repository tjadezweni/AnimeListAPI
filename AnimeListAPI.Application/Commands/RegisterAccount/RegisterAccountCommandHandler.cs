using AnimeListAPI.Application.Security;
using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.RegisterAccount;

public class RegisterAccountCommandHandler
    : IRequestHandler<RegisterAccountCommand, UserTokens>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtSettings _jwtSettings;

    public RegisterAccountCommandHandler(IUnitOfWork unitOfWork, JwtSettings jwtSettings)
    {
        _unitOfWork = unitOfWork;
        _jwtSettings = jwtSettings;
    }

    public async Task<UserTokens> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Username = request.AccountDto.Username,
            Password = request.AccountDto.Password
        };
        user = await _unitOfWork._userRepository.AddAsync(user);
        var userToken = new UserTokens()
        {
            GuidId = Guid.NewGuid(),
            Id = user.UserId,
            Username = user.Username
        };
        var token = JwtHelpers.GenTokenKey(userToken, _jwtSettings);
        return token;
    }
}
