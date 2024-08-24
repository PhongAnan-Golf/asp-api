using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace api.Models
{
    public class User
    {

        // public int Id { get; set; }
        public string Nid { get; set; }=string.Empty;
        // public DateTime CreateOn { get; set; }
    }
}