using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgaNice.Responses
{
    internal class SimpleResponse : IResponse
    {
        public bool Success { get ; set ; }
        public string Message { get; set; }
    }
}
