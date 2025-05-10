using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class jsonPersonalInfo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string realName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime birth { get; set; }
        public string tax { get; set; }
    }
}
