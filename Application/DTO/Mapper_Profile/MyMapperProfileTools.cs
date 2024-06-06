using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;

namespace Application.DTO.Mapper_Profile
{
    public class MyMapperProfileTools : Profile
    {
        public MyMapperProfileTools(){
           //Aqui se Agregaran las configuraciones de las entidades
           //Clientes
           CreateMap<Customer, CustomerDTO>();

           //Empployee
           CreateMap<Employee, EmployeeDTO>();

            //Users
            CreateMap<User, UserDTO>()
                 .ForMember(a => a.Image, b => b.MapFrom(c => c.Employee.Image))
                 .ForMember(a => a.CompleteName, b => b.MapFrom(c => c.Employee.Name + " " + c.Employee.LastName))
                 .ForMember(a => a.Roles, b => b.MapFrom(c => c.Userrols.Select(a => a.Rol)));
                
           CreateMap<Role, RolDTO>();
           //Invoice
          //CreateMap<Invoice, InvoiceDTO>();
        }
    }
}