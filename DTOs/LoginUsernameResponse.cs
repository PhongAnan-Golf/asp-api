using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class LoginUsernameResponse
    {
        public required string Nid { get; set; }
        public static LoginUsernameResponse FromNid(string nid)
        {
            return new LoginUsernameResponse { Nid = nid };
        }
    }
}