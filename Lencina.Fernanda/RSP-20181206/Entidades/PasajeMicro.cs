using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Servicio
    {
        Comun, 
        SemiCama,
        Ejecutivo
    }
    public class PasajeMicro: Pasaje
    {
        Servicio tipoServicio;
        public PasajeMicro()
        { }
        public PasajeMicro(string origen, string destino, Pasajero pasajero, float precio, DateTime fecha,Servicio tipoServicio) : base(origen, destino, pasajero, precio, fecha)
        {
            this.tipoServicio = tipoServicio;
        }
        public override float PrecioFinal
        {
            get
            {
                float retorno;
                switch (this.tipoServicio)
                {
                    case Servicio.SemiCama:
                        retorno = Convert.ToSingle(this.Precio * 1.10);
                        break;
                    
                    case Servicio.Ejecutivo:
                        retorno = Convert.ToSingle(this.Precio * 1.20);
                        break;
                    default:
                        retorno = this.Precio;
                        break;

                }
                return retorno;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} Tipo servicio:{1} Precio final:{2}", base.Mostrar(), this.tipoServicio,this.PrecioFinal);
            return sb.ToString();
        }
    }
}
