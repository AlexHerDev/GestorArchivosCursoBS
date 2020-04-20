using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparador_Archivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string PideDirectorio(string descripcion)
        {
            string nombreCarpeta = null;
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = descripcion; 

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                nombreCarpeta = folderBrowserDialog1.SelectedPath;
            }

            return nombreCarpeta;
        }

        private void botonComparar_Click(object sender, EventArgs e)
        {
            string directorio1 = PideDirectorio("Seleccione directorio 1");
            string directorio2 = PideDirectorio("Seleccione directorio 2");

            Comparador cmp = new Comparador(directorio1, directorio2);
            cmp.ShowDialog();
        }
    }
}
