using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class PcContext : DbContext
    {
        public DbSet <Pc> Pcs { get; set; }
        public DbSet <Cpu> Cpus { get; set; }
        public DbSet <Drive> Drives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\KurmisOG\source\repos\Lab7\Lab7\PcDb.mdf;Integrated Security=True");
        }
    }
}
