using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoklamaSistem
{
    public static class UserSession
    {
        public static string UserName { get; set; }
        public static string RootStatus { get; set; } // "enable" veya "disable" tutacak
    }
}
