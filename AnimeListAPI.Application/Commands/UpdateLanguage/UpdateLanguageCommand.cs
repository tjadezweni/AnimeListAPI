using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateLanguage;

public class UpdateLanguageCommand : IRequest<Language>
{
    public Language Language { get; set; }
}
