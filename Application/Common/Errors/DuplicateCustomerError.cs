using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Errors
{
    public class DuplicateCustomerError : IError
    {
        //Para implementar Fluent Result se implementa interfaz para mardar los errores que requiero sean arrojados en el sistema
        //al momento de una incidencia
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
