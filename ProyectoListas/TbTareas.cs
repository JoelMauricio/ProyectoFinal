using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoListas
{
    public partial class TbTareas : Form
    {
        ProyectoDS2022Entities db = new ProyectoDS2022Entities();
        public bool Agregando { get; set; }
        public TbTareas()
        {
            InitializeComponent();

            Agregando = false;

            CbCategorias();
            GetRegistros();
        }

        private void GetRegistros(string busquedatxt = "")
        {
            var tareas = db.Tareas.ToList();

            if (!string.IsNullOrEmpty(busquedatxt))
            {
                tareas = db.Tareas.Where(x => x.Nombre.Contains(busquedatxt)).ToList();
            }

            dgvTareas.DataSource = tareas.ToList();
            dgvTareas.Columns[3].Visible = false;
        }
        private void GetRegistrosId(int id)
        {
            var tareas = db.Tareas.FirstOrDefault(x => x.Id == id);
            if (tareas != null)
            {
                Agregando = false;
                txtId.Text = tareas.Id.ToString();
                txtNombre.Text = tareas.Nombre;
                cbCategorias.SelectedValue = id;

                gbDatos.Enabled = true;
                btAgregar.Enabled = false;
                btEditar.Enabled = true;
                btEliminar.Enabled = true;
            }
        }

        private void CbCategorias()
        {
            var datos = db.Categorias.ToList();
            if (datos.Count > 0)
            {
                cbCategorias.ValueMember = "Id";
                cbCategorias.DisplayMember = "Nombre";
                cbCategorias.DataSource = datos;
            }
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTareas.Rows[e.RowIndex];
            var ID = row.Cells[0].Value.GetHashCode();

            GetRegistrosId(ID);
        }

        private void Guardar()
        {
            var tarea = new Tareas
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                IdCategoría = int.Parse(cbCategorias.SelectedValue.ToString())
            };

            using (var ctx = new ProyectoDS2022Entities())
            {
                ctx.Entry(tarea).State = Agregando ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                ctx.SaveChanges();

                GetRegistros();
                Limpiar();

                btAgregar.Enabled = true;
                gbDatos.Enabled = false;
                btEditar.Enabled = false;

                MessageBox.Show($"Tarea {(Agregando ? "Agregada" : "Actualizada")}", "DESARROLLO DE SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            cbCategorias.SelectedIndex = 0;

            gbDatos.Enabled = false;
            btEditar.Enabled = false;
            btAgregar.Enabled = true;
            btEliminar.Enabled = false;
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            gbDatos.Enabled = true;
            btEditar.Enabled = true;
            btAgregar.Enabled = false;
            Agregando = true;

            txtId.Text = (db.Tareas.Count() + 1).ToString();
            
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            GetRegistros(txtBuscador.Text);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            txtBuscador.Clear();
            GetRegistros();
            Limpiar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Estas seguro que deseas eliminar esta tarea.", "DESARROLLO DE SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                var tarea = db.Tareas.FirstOrDefault(x => x.Id.ToString() == txtId.Text);
                if (tarea != null)
                {
                    db.Tareas.Remove(tarea);

                    var rTarea = db.SaveChanges() > 0;
                    if (rTarea)
                    {
                        GetRegistros();
                        Limpiar();

                        btAgregar.Enabled = true;
                        gbDatos.Enabled = false;
                        btEditar.Enabled = false;
                        btEliminar.Enabled = false;
                        Agregando = false;
                    }
                }
            }
        }
    }
}
