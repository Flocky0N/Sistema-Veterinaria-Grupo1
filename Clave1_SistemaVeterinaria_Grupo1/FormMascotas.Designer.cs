
namespace Clave1_SistemaVeterinaria_Grupo1
{
    partial class FormMascotas
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtNombreMascota = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtEspecie = new System.Windows.Forms.TextBox();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.txtIdDueño = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la mascota:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(90, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Agregar Mascota";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Especie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Raza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Id del dueño";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha de registro";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(293, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // txtNombreMascota
            // 
            this.txtNombreMascota.Location = new System.Drawing.Point(194, 50);
            this.txtNombreMascota.Name = "txtNombreMascota";
            this.txtNombreMascota.Size = new System.Drawing.Size(173, 20);
            this.txtNombreMascota.TabIndex = 7;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(194, 209);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 8;
            // 
            // txtEspecie
            // 
            this.txtEspecie.Location = new System.Drawing.Point(194, 97);
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.Size = new System.Drawing.Size(173, 20);
            this.txtEspecie.TabIndex = 9;
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(194, 139);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(173, 20);
            this.txtRaza.TabIndex = 10;
            // 
            // txtIdDueño
            // 
            this.txtIdDueño.Location = new System.Drawing.Point(194, 174);
            this.txtIdDueño.Name = "txtIdDueño";
            this.txtIdDueño.Size = new System.Drawing.Size(173, 20);
            this.txtIdDueño.TabIndex = 11;
            // 
            // FormMascotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 358);
            this.Controls.Add(this.txtIdDueño);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.txtEspecie);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtNombreMascota);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "FormMascotas";
            this.Text = "FormMascotas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNombreMascota;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtEspecie;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.TextBox txtIdDueño;
    }
}