using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Interfaces;

public interface IStudioRepository : IAsyncRepository<Studio>
{
}
