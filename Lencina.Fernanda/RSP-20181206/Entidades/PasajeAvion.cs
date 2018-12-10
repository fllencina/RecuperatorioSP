using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PasajeAvion: Pasaje
    {
        int cantidadEscalas;

        public PasajeAvion()
        { }
        public PasajeAvion(string origen, string destino, Pasajero pasajero, float precio, DateTime fecha,int cantidadEscalas):base(origen,destino,pasajero,precio,fecha)
        {
            this.cantidadEscalas = cantidadEscalas;
        }
        public override float PrecioFinal
        {
            get
            {
                float retorno;
                switch(this.cantidadEscalas)
                {
                    case 1:
                        retorno= Convert.ToSingle( this.Precio / 1.10);
                        break;
                    case 2:
                        retorno= Convert.ToSingle(this.Precio/ 1.20);
                        break;
                    default:
                        retorno= Convert.ToSingle(this.Precio / 1.30);
                        break;
                }
                return retorno;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}Cantidad de escalas:{1} Precio final:{2}",base.Mostrar(),this.cantidadEscalas,this.PrecioFinal);
            return sb.ToString();
        }
    }
}
