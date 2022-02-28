﻿using AnimeList.Domain.Languages;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Commands;

public class UpdateLanguageCommand : IRequest<Language>
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}