using System.Windows.Forms;
using Entidades;
using System;
using Exceptions;
using Entidades;
using Archivos;

namespace VistaForm
{
    public partial class FormAgencia : Form
    {
        private Agencia agencia;

        public FormAgencia()
        {
            InitializeComponent();
            agencia = new Agencia("Agencia UTN");
            string[] items = new string[] { "Micro", "Avión" };
            this.cmbTipoPasaje.DataSource = items;
            this.cmbTipoPasaje.SelectedIndex = 0;
            this.nudEscalas.Enabled = false;


            this.txtNombre.Text = "Nombre";
            this.txtApellido.Text = "Apellido";
            this.txtDni.Text = "33444555";
            this.txtOrigen.Text = "Buenos Aires";
            this.txtDestino.Text = "Cordoba";
            cmbTipoServicio.DataSource = Enum.GetValues(typeof(Servicio));
        }

        private void btnEmitirPasaje_Click(object sender, System.EventArgs e)
        {
            Pasajero unPasajero = new Pasajero(txtNombre.Text, txtApellido.Text, txtDni.Text);
            string tipoPasaje = cmbTipoPasaje.Text;
            switch(tipoPasaje)
            {
                case "Micro":
                    PasajeMicro pasajeMicro = new PasajeMicro(txtOrigen.Text, txtDestino.Text, unPasajero, Convert.ToSingle(txtPrecio.Text), Convert.ToDateTime(dtpFechaPartida.Text),(Entidades.Servicio)cmbTipoServicio.SelectedValue);
                    agencia.PasajesVendidos.Add((Pasaje)pasajeMicro);
                    break;
                case "Avión":
                    PasajeAvion pasajeAvion = new PasajeAvion(txtOrigen.Text, txtDestino.Text, unPasajero, Convert.ToSingle(txtPrecio.Text), Convert.ToDateTime(dtpFechaPartida.Text),Convert.ToInt32(nudEscalas.Value) );
                    agencia.PasajesVendidos.Add((Pasaje)pasajeAvion);
                    break;
            }
           
        }

        private void btnMostrar_Click(object sender, System.EventArgs e)
        {
            rtbMostrar.Text=this.agencia.ToString();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            Xml<Agencia> serializar = new Xml<Agencia>();
            try
            {
                serializar.Guardar("Agencia.xml", this.agencia);
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al serializar","Error.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cmbTipoPasaje_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cmbTipoPasaje.SelectedIndex == 0)
            {
                this.nudEscalas.Enabled = false;
                this.nudEscalas.Value = 0;
                this.cmbTipoServicio.Enabled = true;
            }
            else
            {
                this.nudEscalas.Enabled = true;
                this.cmbTipoServicio.Enabled = false;
            }
        }

        private void FormAgencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        private void FormAgencia_Load(object sender, System.EventArgs e)
        {
            this.agencia.Informar += MostrarMensaje;
        }
    }
}
