using AnimeListAPI.Application.Security;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.LoginAccount;

public class LoginAccountQueryHandler
    : IRequestHandler<LoginAccountQuery, UserTokens>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtSettings _jwtSettings;

    public LoginAccountQueryHandler(IUnitOfWork unitOfWork, JwtSettings jwtSettings)
    {
        _unitOfWork = unitOfWork;
        _jwtSettings = jwtSettings;
    }

    public async Task<UserTokens> Handle(LoginAccountQuery request, CancellationToken cancellationToken)
    {
        var username = request.AccountDto.Username;
        var password = request.AccountDto.Password;
        var user = await _unitOfWork._userRepository.GetAsync(user => user.Username == username);
        if (user is null || user.Password != password)
        {
            throw new InvalidOperationException("Login credentials are invalid");
        }
        var userTokens = new UserTokens()
        {
            Username = username,
            Id = user.UserId,
            GuidId = Guid.NewGuid()
        };
        var token = JwtHelpers.GenTokenKey(userTokens, _jwtSettings);
        return token;
    }
}
