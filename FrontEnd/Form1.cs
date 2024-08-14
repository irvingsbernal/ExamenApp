using StoredProcedures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var opcion = cbxOpcion.Checked ? 1 : 0;
            ClsExamen instanciaSp = new ClsExamen(opcion);
            instanciaSp.AgregarExamen(txtNombre.Text, txtDescripcion.Text);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var opcion = cbxOpcion.Checked ? 1 : 0;
            ClsExamen instanciaSp = new ClsExamen(opcion);
            instanciaSp.ActualizarExamen(int.Parse(txtidExamen.Text), txtNombre.Text, txtDescripcion.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var opcion = cbxOpcion.Checked ? 1 : 0;
            ClsExamen instanciaSp = new ClsExamen(opcion);
            instanciaSp.EliminarExamen(int.Parse(txtidExamen.Text));
        }


        public void cargardatagridview()
        {
            var opcion = cbxOpcion.Checked ? 1 : 0;
            ClsExamen instanciaSp = new ClsExamen(opcion);
            int? idExamen;
            if (string.IsNullOrEmpty(txtidExamen.Text))
            {
                idExamen = null;
            }
            else { idExamen = int.Parse(txtidExamen.Text); }

            List<BdiExamen> examenes = instanciaSp.ConsultarExamen(idExamen);

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("idExamen", typeof(string));
            dt2.Columns.Add("Nombre", typeof(string));
            dt2.Columns.Add("Descripcion", typeof(string));
            foreach (BdiExamen examen in examenes)
            {
                var row = dt2.NewRow();
                row["idExamen"] = examen.idExamen.ToString();
                row["nombre"] = examen.nombre;
                row["descripcion"] = examen.descripcion;
                dt2.Rows.Add(row);
            }

            dgExamenes.DataSource = dt2;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cargardatagridview();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
