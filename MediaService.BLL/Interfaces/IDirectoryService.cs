﻿#region usings

using System;
using System.Threading.Tasks;
using MediaService.BLL.DTO;

#endregion

namespace MediaService.BLL.Interfaces
{
    public interface IDirectoryService : IObjectService<DirectoryEntryDto>
    {
        Task AddRootDirToUserAsync(string userId);

        Task<DirectoryEntryDto> GetRootAsync(string ownerId);
    }
}