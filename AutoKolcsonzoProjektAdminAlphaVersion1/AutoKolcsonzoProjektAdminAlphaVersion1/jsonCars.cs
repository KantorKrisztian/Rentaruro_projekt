using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKolcsonzoProjektAdminAlphaVersion1
{
    public class jsonCars
    {
        public int id { get; set; }
        public string picture { get; set; }
        public string licensePlate { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string year { get; set; }
        public string drive { get; set; }
        public string gearShift { get; set; }
        public string fuel { get; set; }
        public bool airCondition { get; set; }
        public bool radar { get; set; }
        public bool cruiseControl { get; set; }
        public string info { get; set; }
        public string location { get; set; }
        public int OneToFive { get; set; }
        public int SixToForteen { get; set; }
        public int OverForteen { get; set; }
        public int Deposit { get; set; }
    }
}
