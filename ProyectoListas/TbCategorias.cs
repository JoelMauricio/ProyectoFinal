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
    public partial class TbCategorias : Form
    {
        ProyectoDS2022Entities db = new ProyectoDS2022Entities();
        public bool Agregando { get; set; }
        public TbCategorias()
        {
            InitializeComponent();

            Agregando = false;

            GetRegistros();
        }

        private void GetRegistros(string busquedatxt = "")
        {
            var categorias = db.Categorias.ToList();

            if (!string.IsNullOrEmpty(busquedatxt))
            {
                categorias = db.Categorias.Where(x => x.Nombre.Contains(busquedatxt)).ToList();
            }

            dgvCategorias.DataSource = categorias.ToList();
            dgvCategorias.Columns[2].Visible = false;
        }

        private void GetRegistrosId(int id)
        {
            var categorias = db.Categorias.FirstOrDefault(x => x.Id == id);
            if (categorias != null)
            {
                Agregando = false;
                txtId.Text = categorias.Id.ToString();
                txtNombre.Text = categorias.Nombre;
                LbTareas(id);

                gbDatos.Enabled = true;
                btAgregar.Enabled = false;
                btEditar.Enabled = true;
                btEliminar.Enabled = true;

            }
        }

        private void LbTareas(int Id)
        {
            var datos = db.Tareas.Where(x => x.IdCategoría == Id).ToList();
            if(datos.Count > 0)
            {
                lbTareas.DisplayMember = "Nombre";
                lbTareas.DataSource = datos;
            }
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCategorias.Rows[e.RowIndex];
            var ID = row.Cells[0].Value.GetHashCode();

            GetRegistrosId(ID);
        }

        private void Guardar()
        {
            var categoria = new Categorias
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text
            };

            using (var ctx = new ProyectoDS2022Entities())
            {
                ctx.Entry(categoria).State = Agregando ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                ctx.SaveChanges();

                GetRegistros();
                Limpiar();

                btAgregar.Enabled = true;
                gbDatos.Enabled = false;
                btEditar.Enabled = false;

                MessageBox.Show($"Categoria {(Agregando ? "Agregada" : "Actualizada")}", "DESARROLLO DE SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            lbTareas.DataBindings.Clear();
            

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

            txtId.Text = (db.Categorias.Count() + 1).ToString();
            
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
            DialogResult dr = MessageBox.Show("Estas seguro que deseas eliminar esta categoría.", "DESARROLLO DE SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                var categoria = db.Categorias.FirstOrDefault(x=> x.Id.ToString() == txtId.Text);
                if (categoria != null)
                {
                    db.Categorias.Remove(categoria);

                    var rCategoria = db.SaveChanges() > 0;
                    if (rCategoria)
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
