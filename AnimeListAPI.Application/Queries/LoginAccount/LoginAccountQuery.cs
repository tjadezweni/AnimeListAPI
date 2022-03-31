using AnimeListAPI.Application.Dtos;
using AnimeListAPI.Application.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.LoginAccount;

public class LoginAccountQuery : IRequest<UserTokens>
{
    public AccountDto AccountDto { get; private set; } = null!;

    public LoginAccountQuery(AccountDto accountDto)
    {
        AccountDto = accountDto;
    }
}
