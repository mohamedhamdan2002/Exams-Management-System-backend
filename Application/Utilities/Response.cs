using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string[]? Errors { get; set; }
        public Response() { }
        public Response(T data) 
        {
            Succeeded = true;
            this.Data = data;
            Errors = null;
        }
        public static implicit operator Response<T>(T data) => new(data);
    }
}
