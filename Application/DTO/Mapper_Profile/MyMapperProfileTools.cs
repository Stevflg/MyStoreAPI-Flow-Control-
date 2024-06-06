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

           //Invoice
          //CreateMap<Invoice, InvoiceDTO>();
        }
    }
}