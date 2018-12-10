using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Exceptions;

namespace VistaForm
{
    public partial class FormLogin : Form
    {
        Usuario usuario;
        public FormLogin()
        {
            InitializeComponent();
            txtClave.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ALUMNO

            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {

                Usuario auxUsuario;
                Usuario aux;
                aux = new Usuario(txtUsuario.Text, txtClave.Text);
                List<Usuario> listaUsuarios = new List<Usuario>();
                
                    auxUsuario = usuarioDAO.Leer("Usuarios");
                    listaUsuarios.Add(auxUsuario);
                
                foreach(Usuario p in listaUsuarios)
                {
                    if(p.Nombre == aux.Nombre && p.Clave== aux.Clave)
                    {
                        usuario = aux;
                    }
                    else
                    {
                        MessageBox.Show("Usuario o clave Incorrecta", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }   
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar recuperar el usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (usuario != null)
            {
                this.Hide();
                FormAgencia f2 = new FormAgencia();
                f2.ShowDialog();
            }

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //ALUMNO

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            try
            {
                usuario = new Usuario(txtUsuario.Text, txtClave.Text);
                usuarioDAO.Guardar("usuarios", usuario);
                MessageBox.Show("Usuario registrado", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ClaveInvalidaException miException)
            {
                MessageBox.Show("La clave debe contener al menos 8 digitos!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception generico)
            {
                MessageBox.Show("Error al registrar el usuario", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //limpio los controles después del registro
            this.txtUsuario.Clear();
            this.txtClave.Clear();
            usuario = null;

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
