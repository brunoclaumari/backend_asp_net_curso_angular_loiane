using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICourse.DTO
{
    public class CustomResponse
    {
        public int? StatusCode { get; set; }

        public bool IsSucessfull { get; set; }

        public string Message { get; set; }
    }
}
