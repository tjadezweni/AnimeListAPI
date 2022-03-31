using AnimeListAPI.Application.Dtos;
using AnimeListAPI.Application.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.RegisterAccount;

public class RegisterAccountCommand : IRequest<UserTokens>
{
    public AccountDto AccountDto { get; private set; } = null!;

    public RegisterAccountCommand(AccountDto accountDto)
    {
        AccountDto = accountDto;
    }
}
