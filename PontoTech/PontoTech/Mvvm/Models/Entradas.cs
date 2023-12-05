using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoTech.Mvvm.Models
{
    public class Entradas
    {
        private DateTime HoraDia;
        private String Marcador;

        public Entradas(String marcador) {
            this.HoraDia = DateTime.Now;
            this.Marcador = marcador;
        }
    }
}
