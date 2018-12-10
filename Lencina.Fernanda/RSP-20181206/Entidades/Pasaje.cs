using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Pasaje
    {
        private Pasajero pasajero;
        private string origen;
        private string destino;
        private float precio;
        private DateTime fecha;
        public Pasaje() { }
        public Pasaje(string origen, string destino, Pasajero pasajero, float precio, DateTime fecha)
        {
            this.origen = origen;
            this.destino = destino;
            this.pasajero = pasajero;
            this.precio = precio;
            this.fecha = fecha;
        }
        
        public static bool operator ==(Pasaje p1, Pasaje p2)
        {
            return (p1.Origen == p2.Origen && p1.Destino == p2.Destino && p1.Pasajero.Dni == p2.Pasajero.Dni && p1.Fecha == p2.Fecha);
        }

        public static bool operator !=(Pasaje p1, Pasaje p2)
        {
            return !(p1 == p2);
        }

        public abstract float PrecioFinal
        {
            get;
        }

        public Pasajero Pasajero { get => pasajero; set => pasajero = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Destino { get => destino; set => destino = value; }
        public float Precio { get => precio; set => precio = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Pasajero:{0} Origen:{1} Destino:{2} Precio:{3} Fecha:{4}", Pasajero, Origen, Destino, Precio, Fecha);
            return sb.ToString();
        }
    }
}
