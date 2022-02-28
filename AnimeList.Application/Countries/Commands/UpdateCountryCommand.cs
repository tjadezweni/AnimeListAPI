using AnimeList.Domain.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Commands;

public class UpdateCountryCommand : IRequest<Country>
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
