﻿using AnimeList.Domain.Studios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Queries;

public class GetStudioByIdQuery : IRequest<Studio?>
{
    public int Id { get; }

    public GetStudioByIdQuery(int id)
    {
        Id = id;
    }
}
