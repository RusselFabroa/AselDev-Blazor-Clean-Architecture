using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselBlazorCleanArchitecture.Shared.Models.Responses
{
    public class APIResponse<T>
    {

        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }


        public APIResponse() { }

        public APIResponse(T data, string message = "", int statusCode = 200)
        {
            Success = true;
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }



        public APIResponse(string message, int statusCode)
        {
            Success = false;
            Data = default;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
