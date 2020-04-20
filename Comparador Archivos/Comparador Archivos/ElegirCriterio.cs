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
    public partial class ElegirCriterio : Form
    {
        List<(int, string)> opciones;
        string eleccion; 

        public ElegirCriterio(List<(int, string)> opciones)
        {
            InitializeComponent();
            this.opciones = opciones;
            this.eleccion = null; 
            AniadeOpciones(opciones);
        }

        public int DameAlternativa()
        {
            int elec = -1; 
            foreach (var opcion in opciones)
                if(opcion.Item2 == this.eleccion)
                    elec = opcion.Item1;
            
            return elec;  
        }

        public void AniadeOpciones(List<(int, string)> opciones)
        {
            foreach (var opcion in opciones)
                EleccionCriterioList.Items.Add(opcion.Item2);
        }

        private void EleccionCriterioList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < EleccionCriterioList.Items.Count; ++ix)
                if (ix != e.Index) EleccionCriterioList.SetItemChecked(ix, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.eleccion = EleccionCriterioList.CheckedItems[0].ToString();
            this.Close();
        }
    }
}
