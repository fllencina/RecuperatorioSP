namespace Entidades
{
    public class Pasajero
    {
        private string nombre;
        private string apellido;
        private string dni;

        public Pasajero(string nombre, string apellido, string dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public Pasajero() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dni { get => dni; set => dni = value; }

        public override string ToString()
        {
            return string.Format("Nombre: {0} {1} Dni: {2}", Nombre, Apellido, Dni);
        }
    }
}
