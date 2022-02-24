﻿using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Studios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios;

public class StudioService : IStudioService
{
    private readonly IUnitOfWork unitOfWork;

    public StudioService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Studio> Create(Studio newStudio)
    {
        var existingStudio = await unitOfWork.Studio.GetByIdAsync(newStudio.Id);
        if (existingStudio is not null)
        {
            throw new Exception(ErrorMessages.IdFound(ModelType.Studio));
        }
        var studio = new Studio()
        {
            Id = newStudio.Id,
            Name = newStudio.Name,
        };
        await unitOfWork.Studio.CreateAsync(studio);
        await unitOfWork.SaveAsync();
        return studio;
    }

    public async Task Delete(int id)
    {
        await unitOfWork.Studio.DeleteAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Studio>> Get()
    {
        return await unitOfWork.Studio.GetAsync();
    }

    public async Task<Studio?> GetById(int id)
    {
        return await unitOfWork.Studio.GetByIdAsync(id);
    }

    public async Task<Studio> Update(Studio updatedStudio)
    {
        await unitOfWork.Studio.UpdateAsync(updatedStudio);
        await unitOfWork.SaveAsync();
        return updatedStudio;
    }
}