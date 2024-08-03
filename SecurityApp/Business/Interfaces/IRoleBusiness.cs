﻿using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleBusiness
    {
        Task Delete(int id);

        Task<Role> Save(RoleDto entity); 
        Task<RoleDto> GetById(int id);

        Task Update(int id, RoleDto entity);
    }
}
