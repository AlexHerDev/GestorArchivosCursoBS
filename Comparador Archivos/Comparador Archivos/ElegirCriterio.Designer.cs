namespace Comparador_Archivos
{
    partial class ElegirCriterio
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
            this.EleccionCriterioList = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elija el criterio de comparación";
            // 
            // EleccionCriterioList
            // 
            this.EleccionCriterioList.CheckOnClick = true;
            this.EleccionCriterioList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EleccionCriterioList.FormattingEnabled = true;
            this.EleccionCriterioList.Location = new System.Drawing.Point(70, 93);
            this.EleccionCriterioList.Name = "EleccionCriterioList";
            this.EleccionCriterioList.Size = new System.Drawing.Size(250, 256);
            this.EleccionCriterioList.TabIndex = 2;
            this.EleccionCriterioList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.EleccionCriterioList_ItemCheck);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button1.Location = new System.Drawing.Point(131, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ElegirCriterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EleccionCriterioList);
            this.Controls.Add(this.label1);
            this.Name = "ElegirCriterio";
            this.Text = "ElegirCriterio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox EleccionCriterioList;
        private System.Windows.Forms.Button button1;
    }
}