using AnimeList.Domain.Studios;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Commands;

public class UpdateStudioCommand : IRequest<Studio>
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
