﻿#region usings

using System;

#endregion

namespace MediaService.BLL.DTO
{
    public abstract class ObjectEntryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public string Discriminator { get; set; }

        public DateTime Created { get; set; }

        public DateTime Downloaded { get; set; }

        public DateTime Modified { get; set; }


        public DirectoryEntryDto Parent { get; set; }

        public Guid? ParentId { get; set; }
    }
}