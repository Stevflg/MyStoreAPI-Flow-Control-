using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts.SecurityApp
{
    public interface IGenerateToken
    {
        string Create(User userLogin,List<Role> roles);
    }
}
