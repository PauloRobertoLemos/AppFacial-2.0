using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoTech.Mvvm.Models
{
    public class Entradas
    {
        public DateTime HoraDia { get; set; }
        public String Marcador { get; set; }

        public Entradas(String marcador) {
            this.HoraDia = DateTime.Now;
            this.Marcador = marcador;
        }
    }
}
