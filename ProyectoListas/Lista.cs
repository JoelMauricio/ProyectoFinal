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
    public partial class Lista : Form
    {
        ProyectoDS2022Entities db = new ProyectoDS2022Entities();

        public Lista()
        {
            InitializeComponent();

            AgregarNodos();
        }

        private void AgregarNodos()
        {
            var listas = db.Categorias.ToList();
            var Sublistas = db.Tareas.ToList();
            foreach (var item in listas)
            {
                TreeNode nodo = new TreeNode();
                nodo = tvListas.Nodes.Add(item.Nombre.ToString());
                foreach (var items in Sublistas)
                {
                    if(items.IdCategoría == item.Id)
                    {
                        /*TreeNode subnodo = new TreeNode();
                        subnodo = tvListas.Nodes.Add(items.Nombre.ToString());
                        nodo.Nodes.Add(subnodo.ToString());*/
                        nodo.Nodes.Add(items.Nombre.ToString());
                    }
                }
            }
        }

        private void Nodo_Click(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            tvListas.Nodes.Clear();
            AgregarNodos();
        }
    }
}
