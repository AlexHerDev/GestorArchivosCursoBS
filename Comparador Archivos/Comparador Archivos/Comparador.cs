using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparador_Archivos
{
    public partial class Comparador : Form, IComparador
    {
        private string directorio1;
        private string directorio2;
        //source, destination
        private List<(string, string)> candidatosCopiaFicheros;
        private List<(string, string)> candidatosCopiaDirectorios;
        //private ProgressBar pBar1;

        public Comparador(string directorio1, string directorio2)
        {
            InitializeComponent();
            this.candidatosCopiaFicheros = new List<(string, string)>(); 
            this.candidatosCopiaDirectorios = new List<(string, string)>(); 
            this.directorio1 = directorio1;
            this.directorio2 = directorio2;
            //checkedListBox1.Items.Add((SoloNombre(directorio1)));
            //Añadimos el nodo padre 
            treeView1.Nodes.Add(new TreeNode(SoloNombre(directorio1)));
            //treeView1.Nodes.Add(SoloNombre(directorio1));
            treeView2.Nodes.Add(SoloNombre(directorio2));
            //checkedListBox2.Items.Add((SoloNombre(directorio2)));
            Compara(directorio1, directorio2, SeleccionCriterio());
            visualiza(candidatosCopiaFicheros);
            visualiza(candidatosCopiaDirectorios);
            PintaArbol(directorio1, treeView1);
            
        }

        /**
        ***************** FUCIONES DEBUGG *****************************
        **/

        public void visualiza(List<(string, string)> cand)
        {
            Console.WriteLine("");

            Console.WriteLine("**************************************");
            foreach (var can in cand)
            {
                Console.WriteLine(can);
            }
        }

        public void visualizaArr(string[] AllDirectories)
        {
            Console.WriteLine("");

            Console.WriteLine("*****ARRRRRRRRRRRRRRRRRR**************");
            foreach (var can in AllDirectories)
            {
                Console.WriteLine(can);
            }
        }

        //*************************************************************

        public void PintaArbol(string directorioPadre, TreeView arbol)
        {
            try
            {
                //Obtenemos los ficheros del directorio actual
                string[] files1 = Directory.GetFiles(directorioPadre, "*.*", SearchOption.TopDirectoryOnly);
                string[] directories1 = Directory.GetDirectories(directorioPadre, "*.*", SearchOption.TopDirectoryOnly);

                int cont = 0;
                foreach (var dir1 in directories1)
                {
                    // treeView1.Nodes[dir1.IndexOf((char) cont)].Nodes.Add(
                    // new TreeNode(SoloNombre(dir1)));
                    arbol.Nodes[0].Nodes.Add(
                    new TreeNode(SoloNombre(dir1)));
                
                    string[] dr1 = Directory.GetDirectories(dir1, "*.*", SearchOption.TopDirectoryOnly);
                    string[] fl1 = Directory.GetFiles(dir1, "*.*", SearchOption.TopDirectoryOnly);
                    foreach (var f1 in fl1)
                    {
                        arbol.Nodes[0].Nodes[cont].Nodes.Add(
                        new TreeNode(SoloNombre(f1)));
                    }
                    cont++;
                }

                foreach (var fil1 in files1)
                {
                    arbol.Nodes[0].Nodes.Add(
                    new TreeNode(SoloNombre(fil1)));
                    cont++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void CopiaDirectorio(string sourcePath, string destinationPath, IProgress<int> progress, int max)
        {
            char cc = '\u005C';
            Directory.CreateDirectory(destinationPath + cc.ToString() + SoloNombre(sourcePath));

            destinationPath = destinationPath + cc.ToString() + SoloNombre(sourcePath);

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

            var directorios = Directory.GetFiles(sourcePath, "*.*",
                SearchOption.AllDirectories);

            //Copy all the files & Replaces any files with the same name
            int cont = 0; 
            foreach (string newPath in directorios)
            {
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
                progress.Report((cont + 1) * 100 / max);
                cont++;
            }
        }

        public void CopiaFichero(string sourcePath, string destinationPath, int v, int max, IProgress<int> progress)
        {
            char cc = '\u005C';
            destinationPath += cc.ToString() + SoloNombre(sourcePath); 
            File.Copy(sourcePath, destinationPath, true); //Lo reemplaza si existe
            progress.Report((v + 1) * 100 / max);
            //v++;
        }

        public string CadenaInversa(string texto)
        {
            int tam = texto.Length - 1;
            string nuevo = "";

            for (int i = tam; i >= 0; i--)
                nuevo += texto[i].ToString();

            return nuevo;
        }

        public string SoloNombre(string directorio)
        {
            //if (directorio != null)
           
            string nombre = "";
            char caracter;
            int longitud = directorio.Length - 1;
            char stop = '\u005C';

            string seleccionado = "";
            while (seleccionado != stop.ToString())
            {
                caracter = directorio[longitud];
                
                if(caracter != stop)
                    nombre += caracter;
                
                seleccionado = caracter.ToString();
                longitud--;
            }

            return CadenaInversa(nombre); 
        }

        public int SeleccionCriterio()
        {
            var alternativas = new List<(int, string)>
            {
                  (1, "Fecha, nombre y tamaño"),
                  (2, "Nombre y tamaño"),
                  (3, "Solo por nombre")
            };

            ElegirCriterio ec = new ElegirCriterio(alternativas);
            ec.ShowDialog();

            return ec.DameAlternativa();
        }

        public double ObtenerTamanioDir(string directory)
        {
            double tam = 0;

            try
            {
                //Obtenemos los ficheros del directorio actual
                string[] allfiles = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly);
                foreach (var file in allfiles)
                {
                    FileInfo info = new FileInfo(file);
                    tam += info.Length;
                }

                //Obtenemos los directorios del directorio actual 
                string[] AllDirectories = Directory.GetDirectories(directory, "*.*", SearchOption.AllDirectories);

                foreach (var dire in AllDirectories)
                {
                    //Para cada directorio obtenemos sus archivos 
                    allfiles = Directory.GetFiles(dire, "*.*", SearchOption.TopDirectoryOnly);
                    foreach (var file in allfiles)
                    {
                        FileInfo info = new FileInfo(file);
                        tam += info.Length; 
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            return tam; 
        }

        public bool ComparaFicheros(string fir1, string fir2, int criterio)
        {
            bool result = false;

            string nombre1 = SoloNombre(fir1);
            string nombre2 = SoloNombre(fir2);
            switch (criterio)
            {
                case 1:
                    try
                    {
                        if (nombre1 == nombre2)
                        {
                            //También se podría utilziar:
                            //DateTime modification = File.GetLastWriteTime(fir1);
                            DateTime dt1 = File.GetCreationTime(fir1);
                            DateTime dt2 = File.GetCreationTime(fir2);

                            if (dt1 == dt2)
                            {
                                FileInfo info1 = new FileInfo(fir1);
                                FileInfo info2 = new FileInfo(fir2);
                                double tam1 = info1.Length;
                                double tam2 = info2.Length;

                                if (tam1 == tam2) result = true;
                                else break; 
                            }
                            else
                                break; 
                        }
                        else
                            break; 
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                    break;
                case 2:
                    try
                    {
                        if (nombre1 == nombre2)
                        {
                            FileInfo info1 = new FileInfo(fir1);
                            FileInfo info2 = new FileInfo(fir2);
                            double tam1 = info1.Length;
                            double tam2 = info2.Length;

                            if (tam1 == tam2) result = true;
                            else break;
                        }
                        else
                            break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                    break;
                case 3:
                    if (nombre1 == nombre2) result = true;
                    break;
            } 
            return result; 
        }

        public bool ComparaDirectorios(string dir1, string dir2, int criterio)
        {
            bool result = false;
           
            string nombre1 = SoloNombre(dir1);
            string nombre2 = SoloNombre(dir2);

            switch (criterio)
            {
                case 1:
                    try
                    {
                        if (nombre1 == nombre2)
                        {
                            //También se podría utilziar: 
                            //Directory.GetLastWriteTime(dir1);
                            DateTime dt1 = Directory.GetCreationTime(dir1);
                            DateTime dt2 = Directory.GetCreationTime(dir2);

                            if (dt1 == dt2)
                            {
                                double tam1 = ObtenerTamanioDir(dir1);
                                double tam2 = ObtenerTamanioDir(dir2);

                                if (tam1 == tam2) result = true;
                                else break; 
                            }
                            else
                                break; 
                        }
                        else
                            break; 
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }

                    break;

                case 2:
                    try
                    {
                        if (nombre1 == nombre2)
                        {
                            double tam1 = ObtenerTamanioDir(dir1);
                            double tam2 = ObtenerTamanioDir(dir2);

                            if (tam1 == tam2) result = true;
                            else break; 
                        }
                        else
                            break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                    break;
                case 3:
                    if (nombre1 == nombre2) result = true;
                    break;
            }

            return result;
        }

        public void SeleccionaCopiaDeFicheros(string directorio1, string directorio2, int criterio)
        {
            string[] fils1 = Directory.GetFiles(directorio1, "*.*", SearchOption.TopDirectoryOnly);
            string[] fils2 = Directory.GetFiles(directorio2, "*.*", SearchOption.TopDirectoryOnly);

            bool copia = true;

            foreach (var fil1 in fils1)
            {
                foreach (var fil2 in fils2)
                {
                    if (SoloNombre(fil1) == SoloNombre(fil2))
                    {
                        if (!ComparaFicheros(fil1, fil2, criterio))
                        {
                            candidatosCopiaFicheros.Add((fil1, directorio2));  //TODO: AQUI SE DEBERIA DE CAMBIAR EL NOMBRE SI NO SE REEMPLAZA 
                        } else
                        {
                            copia = false;
                        }
                    }
                }
                if (copia)
                {
                    candidatosCopiaFicheros.Add((fil1, directorio2));
                }
                copia = true;
            }
        }

        public void Compara(string directorio1, string directorio2, int criterio)
        {
           
            try
            {
                string[] dirs1 = Directory.GetDirectories(directorio1, "*.*", SearchOption.TopDirectoryOnly);
                //string[] fils1 = Directory.GetFiles(directorio1, "*.*", SearchOption.AllDirectories);

                string[] dirs2 = Directory.GetDirectories(directorio2, "*.*", SearchOption.TopDirectoryOnly);
                //string[] fils2 = Directory.GetFiles(directorio2, "*.*", SearchOption.AllDirectories);

                //Nivel 0
                SeleccionaCopiaDeFicheros(directorio1, directorio2, criterio); 

                bool copia = true;

                if (dirs2.Length == 0)   
                {
                    foreach (var dir1 in dirs1)
                    {
                        candidatosCopiaDirectorios.Add((dir1, directorio2));
                    }
                }
                else      
                {
                    foreach (var dir1 in dirs1)
                    {
                        foreach (var dir2 in dirs2)
                        {
                            if (SoloNombre(dir1) == SoloNombre(dir2))
                            {
                                copia = false;
                                Compara(dir1, dir2, criterio);
                            }
                        }
                        if (copia)
                        {
                            candidatosCopiaDirectorios.Add((dir1, directorio2));
                        }
                        copia = true; 
                    }    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private int calculaTotalCopiar()
        {
            int res = candidatosCopiaFicheros.Count;
            string[] tot;

            foreach (var candDir in candidatosCopiaDirectorios)
            {
                try
                {
                    tot = Directory.GetFiles(candDir.Item1, "*.*", SearchOption.AllDirectories);
                    res += tot.Length;
                } catch(Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }

            return res;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Set Maximum to the total number of files to copy.
            int maximum = calculaTotalCopiar();

            Console.WriteLine("VALOR MAXIMO: {0}", maximum);

            // Display the ProgressBar control.
            pBar1.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            pBar1.Minimum = 1;
       
            // Set the initial value of the ProgressBar.
            pBar1.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            pBar1.Step = 1;

            var progress = new Progress<int>(v =>
            {
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                pBar1.Value = v;
            });

            if (candidatosCopiaDirectorios.Count == 0 && candidatosCopiaFicheros.Count == 0)
            {
                MessageBox.Show("No hay nada que copiar.");
            }
            else
            {
                // Run operation in another thread
                int valorReal = maximum;

                foreach (var candDir in candidatosCopiaDirectorios)
                {
                    await Task.Run(() => CopiaDirectorio(candDir.Item1, candDir.Item2, progress, maximum));
                }

                foreach (var candFich in candidatosCopiaFicheros)
                {
                    if (candidatosCopiaDirectorios.Count == 0)
                    {
                        await Task.Run(() => CopiaFichero(candFich.Item1, candFich.Item2, maximum - valorReal, maximum, progress));
                        valorReal--;
                    }
                    else
                    {
                        await Task.Run(() => CopiaFichero(candFich.Item1, candFich.Item2, maximum, pBar1.Value, progress));
                        valorReal--;
                    }
                }
            }
        }

        private void generarLog_Click(object sender, EventArgs e)
        {
            FileLog lg = new FileLog();
            lg.EscribeLog(candidatosCopiaDirectorios, "Directorios copiados");
            lg.EscribeLog(candidatosCopiaFicheros, "Ficheros copiados");

            MessageBox.Show("Logs creados");
        }
    }
}
