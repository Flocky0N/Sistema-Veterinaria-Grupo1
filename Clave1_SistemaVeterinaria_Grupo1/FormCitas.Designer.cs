﻿
namespace Clave1_SistemaVeterinaria_Grupo1
{
    partial class FormCitas
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDMascota = new System.Windows.Forms.TextBox();
            this.dtpfechahora = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvCita = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtestadoMascota = new System.Windows.Forms.TextBox();
            this.dgvCitasRegistros = new System.Windows.Forms.DataGridView();
            this.txtIDCita = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Cliente  ";
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.Location = new System.Drawing.Point(351, 53);
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.Size = new System.Drawing.Size(125, 20);
            this.txtIDCliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID Mascota  ";
            // 
            // txtIDMascota
            // 
            this.txtIDMascota.Location = new System.Drawing.Point(351, 120);
            this.txtIDMascota.Name = "txtIDMascota";
            this.txtIDMascota.Size = new System.Drawing.Size(125, 20);
            this.txtIDMascota.TabIndex = 4;
            // 
            // dtpfechahora
            // 
            this.dtpfechahora.Location = new System.Drawing.Point(351, 20);
            this.dtpfechahora.Name = "dtpfechahora";
            this.dtpfechahora.Size = new System.Drawing.Size(200, 20);
            this.dtpfechahora.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de la cita";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(22, 192);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 34);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar Cita";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(658, 306);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 34);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar Cita";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvCita
            // 
            this.dgvCita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCita.Location = new System.Drawing.Point(572, 27);
            this.dgvCita.Name = "dgvCita";
            this.dgvCita.Size = new System.Drawing.Size(261, 113);
            this.dgvCita.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clave1_SistemaVeterinaria_Grupo1.Properties.Resources.cita;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Estado de la mascota:   ";
            // 
            // txtestadoMascota
            // 
            this.txtestadoMascota.Location = new System.Drawing.Point(351, 84);
            this.txtestadoMascota.Name = "txtestadoMascota";
            this.txtestadoMascota.Size = new System.Drawing.Size(200, 20);
            this.txtestadoMascota.TabIndex = 18;
            // 
            // dgvCitasRegistros
            // 
            this.dgvCitasRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitasRegistros.Location = new System.Drawing.Point(22, 256);
            this.dgvCitasRegistros.Name = "dgvCitasRegistros";
            this.dgvCitasRegistros.Size = new System.Drawing.Size(618, 155);
            this.dgvCitasRegistros.TabIndex = 19;
            // 
            // txtIDCita
            // 
            this.txtIDCita.Location = new System.Drawing.Point(658, 346);
            this.txtIDCita.Name = "txtIDCita";
            this.txtIDCita.Size = new System.Drawing.Size(100, 20);
            this.txtIDCita.TabIndex = 20;
            // 
            // FormCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 423);
            this.Controls.Add(this.txtIDCita);
            this.Controls.Add(this.dgvCitasRegistros);
            this.Controls.Add(this.txtestadoMascota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvCita);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpfechahora);
            this.Controls.Add(this.txtIDMascota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDCliente);
            this.Controls.Add(this.label1);
            this.Name = "FormCitas";
            this.Text = "FormCitas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDMascota;
        private System.Windows.Forms.DateTimePicker dtpfechahora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvCita;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtestadoMascota;
        private System.Windows.Forms.DataGridView dgvCitasRegistros;
        private System.Windows.Forms.TextBox txtIDCita;
    }
}