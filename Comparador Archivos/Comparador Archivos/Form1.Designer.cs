namespace Comparador_Archivos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonComparar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonComparar
            // 
            this.botonComparar.Location = new System.Drawing.Point(115, 92);
            this.botonComparar.Name = "botonComparar";
            this.botonComparar.Size = new System.Drawing.Size(163, 54);
            this.botonComparar.TabIndex = 0;
            this.botonComparar.Text = "Comparar y copiar";
            this.botonComparar.UseVisualStyleBackColor = true;
            this.botonComparar.Click += new System.EventHandler(this.botonComparar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "GESTOR ARCHIVOS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Opción 2 (no implementada)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 54);
            this.button2.TabIndex = 3;
            this.button2.Text = "Opción 3 (no implementada)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 54);
            this.button3.TabIndex = 4;
            this.button3.Text = "Opción 4 (no implementada)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonComparar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonComparar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

