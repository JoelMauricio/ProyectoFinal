namespace ProyectoListas
{
    partial class Lista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvListas = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.btActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvListas
            // 
            this.tvListas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvListas.Location = new System.Drawing.Point(36, 54);
            this.tvListas.Name = "tvListas";
            this.tvListas.Size = new System.Drawing.Size(196, 323);
            this.tvListas.TabIndex = 0;
            this.tvListas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Nodo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tus Listas";
            // 
            // btActualizar
            // 
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.Location = new System.Drawing.Point(176, 15);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(75, 23);
            this.btActualizar.TabIndex = 2;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(263, 388);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvListas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Lista";
            this.ShowIcon = false;
            this.Text = "Lista";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvListas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btActualizar;
    }
}