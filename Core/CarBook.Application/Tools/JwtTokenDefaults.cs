using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string Issuer = "https://localhost";
        public const string ValidAudience = "https://localhost";
        public const string Key = "CarBook+*010203CARBOOK01.CarBookProject";
        public const int ExpireMinutes = 5;
    }
}
