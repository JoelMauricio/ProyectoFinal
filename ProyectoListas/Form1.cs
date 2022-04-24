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
    public partial class Form1 : Form
    {
        ProyectoDS2022Entities db = new ProyectoDS2022Entities();
        public Form1()
        {
            InitializeComponent();
        }


        /*
private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
{

}
*/
        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TbCategorias tbCategorias = new TbCategorias();
            tbCategorias.MdiParent = this;
            tbCategorias.Show();
        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TbTareas tbTareas = new TbTareas();
            tbTareas.MdiParent = this;
            tbTareas.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            lista.MdiParent = this;
            lista.Show();
        }
    }
}
