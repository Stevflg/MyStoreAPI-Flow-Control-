using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Contracts.SecurityApp
{
    public interface IGenerateToken
    {
        string Create(UserDTO userLogin);
    }
}
