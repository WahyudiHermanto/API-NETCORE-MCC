using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class JWTokenVM
    {
        public HttpStatusCode Status { get; set; }
        public string IdToken { get; set; }
        public string Message { get; set; }
    }
}
