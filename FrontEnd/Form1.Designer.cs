
namespace FrontEnd
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new System.Windows.Forms.TextBox();
            txtDescripcion = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnAgregar = new System.Windows.Forms.Button();
            btnActualizar = new System.Windows.Forms.Button();
            cbxOpcion = new System.Windows.Forms.CheckBox();
            txtidExamen = new System.Windows.Forms.TextBox();
            dgExamenes = new System.Windows.Forms.DataGridView();
            btnEliminar = new System.Windows.Forms.Button();
            btnConsultar = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgExamenes).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(102, 94);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new System.Drawing.Point(259, 94);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new System.Drawing.Size(100, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(102, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre Examen:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(259, 76);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 15);
            label2.TabIndex = 3;
            label2.Text = "Descripción:";
            label2.Click += label2_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new System.Drawing.Point(102, 136);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new System.Drawing.Point(259, 136);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new System.Drawing.Size(75, 23);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // cbxOpcion
            // 
            cbxOpcion.AutoSize = true;
            cbxOpcion.Location = new System.Drawing.Point(456, 97);
            cbxOpcion.Name = "cbxOpcion";
            cbxOpcion.Size = new System.Drawing.Size(127, 19);
            cbxOpcion.TabIndex = 6;
            cbxOpcion.Text = "Config (1 SP, 0 WS)";
            cbxOpcion.UseVisualStyleBackColor = true;
            // 
            // txtidExamen
            // 
            txtidExamen.Location = new System.Drawing.Point(365, 93);
            txtidExamen.Name = "txtidExamen";
            txtidExamen.Size = new System.Drawing.Size(64, 23);
            txtidExamen.TabIndex = 7;
            // 
            // dgExamenes
            // 
            dgExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgExamenes.Location = new System.Drawing.Point(78, 209);
            dgExamenes.Name = "dgExamenes";
            dgExamenes.RowTemplate.Height = 25;
            dgExamenes.Size = new System.Drawing.Size(412, 150);
            dgExamenes.TabIndex = 8;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new System.Drawing.Point(102, 180);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(75, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new System.Drawing.Point(259, 175);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new System.Drawing.Size(75, 28);
            btnConsultar.TabIndex = 10;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(365, 75);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(18, 15);
            label3.TabIndex = 11;
            label3.Text = "ID";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnConsultar);
            Controls.Add(btnEliminar);
            Controls.Add(dgExamenes);
            Controls.Add(txtidExamen);
            Controls.Add(cbxOpcion);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Examenes Bansi";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgExamenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.CheckBox cbxOpcion;
        private System.Windows.Forms.TextBox txtidExamen;
        private System.Windows.Forms.DataGridView dgExamenes;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label3;
    }
}

