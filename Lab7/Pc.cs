using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Pc
    {
        public int PcId { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        
        public int CpuId { get; set; }
        public virtual List <Drive> Drives { get; set; }
    }
}
