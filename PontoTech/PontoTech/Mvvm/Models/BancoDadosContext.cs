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
                string conecaostr = "server=a3.cy9jxemryba8.us-east-2.rds.amazonaws.com;port=3306;database=PontoTech;uid=admin;password=DhomynyFarias1512";
                options.UseMySql(conecaostr,ServerVersion.AutoDetect(conecaostr));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entradas>(entity => 
            {
                entity.HasKey(e => e.Marcador);
                entity.Property(e => e.HoraDia);
            
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Cpf);
                entity.Property(e => e.nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Senha).IsRequired();
            });
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Entradas> Entradas { get; set;}
    }
}
