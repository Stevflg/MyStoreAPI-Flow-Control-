using System.Net;

namespace Application.Common.Errors
{
    public interface IError
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
    }

}