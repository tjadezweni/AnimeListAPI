using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest<int>
{
    public int Id { get; set; }
}
