using AnimeList.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.WebApi.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class AppController : ControllerBase
{
    public IUnitOfWork unitOfWork { get; }

    public AppController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}
