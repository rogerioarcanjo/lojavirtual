using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOs
{
    public class AuthenticationInfo
    {
        public string? Token { get; set; }
        public string? UserName { get; set; }
    }
}
