using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoTech.Mvvm.Models
{
    public class BancoDadosContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(options != null)
            {
                string conecaostr = "server=a3.cy9jxemryba8.us-east-2.rds.amazonaws.com;port=3306;database=PontoTech;uid=admin;password=";
                options.UseMySql(conecaostr,ServerVersion.AutoDetect(conecaostr));
            }
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
