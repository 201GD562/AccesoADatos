using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AccesoADatos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        SQLiteConnection conexion;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Articulo a = new Articulo();
            a.Id = (int)nmrId.Value;
            a.Descripcion = txtDescripcion.Text;
            GestorDeDatos.InsertarArticulo(conexion, a);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo a = (Articulo)lstArticulos.SelectedItem;
            GestorDeDatos.Eliminar(conexion, a);
        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            GestorDeDatos.CrearTabla(conexion);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var datos = GestorDeDatos.CargarArticulos(conexion);
            lstArticulos.DataSource = null;
            lstArticulos.DataSource = datos;
            lstArticulos.DisplayMember = "Descripcion";
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            conexion = GestorDeDatos.EstablecerConexion();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorDeDatos.CerrarConexion(conexion);
        }
    }
}
