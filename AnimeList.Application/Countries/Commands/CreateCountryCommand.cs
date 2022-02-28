using AnimeList.Domain.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Commands;

public class CreateCountryCommand : IRequest<Country>
{
    [Required]
    public string Name { get; set; } = null!;
}
