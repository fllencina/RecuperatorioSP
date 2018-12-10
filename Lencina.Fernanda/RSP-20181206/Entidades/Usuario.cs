using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Entidades
{
    public class Usuario
    {
        private string nombre;
        private string clave;

        public Usuario(string nombre, string clave)
        {
            this.nombre = nombre;
            this.Clave = clave;
        }

        public string Nombre { get => nombre; }
        public string Clave
        {
            get
            {
                return clave;
            }
            set
            {
                //ALUMNO
                int caracteres = value.Count();
                if(caracteres>7)
                {
                    clave = value;
                }
                else
                {
                    throw new ClaveInvalidaException("La clave debe contener al menos 8 digitos");
                }
                
            }
        }
    }
}
