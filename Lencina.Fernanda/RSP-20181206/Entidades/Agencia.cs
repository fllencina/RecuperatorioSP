using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoMensaje(string mensaje);
    
    public class Agencia
    {
        public event DelegadoMensaje Informar;
        private string nombre;
        private List<Pasaje> pasajesVendidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Pasaje> PasajesVendidos { get => pasajesVendidos; set => pasajesVendidos = value; }

        private Agencia()
        {
            pasajesVendidos = new List<Pasaje>();
        }

        public Agencia(string nombre)
        {
            this.Nombre = nombre;
        }

        public static bool operator ==(Agencia a, Pasaje p)
        {
            foreach(Pasaje t in a.pasajesVendidos)
            {
                if(t==p)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Agencia a, Pasaje p)
        {
            return !(a==p);
        }

        public static Agencia operator +(Agencia a, Pasaje p)
        {
            if (!(a == p))
            {
                a.pasajesVendidos.Add(p);
                a.Informar.Invoke("Pasaje emitido Correctamente");
            }
            else
            {
                a.Informar.Invoke("El pasaje ya fue emitido con anterioridad");
            }
            return a;
        }

        public float CalcularGanancia()
        {
            float ganancia=0;
            foreach(Pasaje p in this.pasajesVendidos)
            {
                ganancia += p.PrecioFinal;
            }
            return ganancia;
        }

        public static explicit operator string(Agencia a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Agencia: " + a.Nombre);
            sb.AppendLine("Pasajes vendidos:");
            foreach (Pasaje p in a.PasajesVendidos)
            {
                sb.AppendLine(p.Mostrar());
            }
            sb.AppendLine("Ganancia: " + a.CalcularGanancia());

            return sb.ToString();
        }
    }
}
