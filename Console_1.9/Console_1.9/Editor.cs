using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console_1._9
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        String ruta = "";
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            escribe();

        }
        public void Setruta(String ruta) {


            this.ruta = ruta;


            if (File.Exists(ruta))
            {
                Console.WriteLine(ruta);
                FileInfo f = new FileInfo(ruta);
                String exori = f.Extension;
                f.MoveTo(Path.ChangeExtension(ruta, ".txt"));
                
                Console.WriteLine(exori+"---------------");
                String nue = f.FullName;

                String line; try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(@"" + nue);
                    line = sr.ReadLine();
                    int num = 0;
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        if (num == 0)
                        {
                            textBox1.Text += line;
                            num = 1;
                        }
                        else
                        {
                            textBox1.Text += "\r\n" + line;
                        }


                        line = sr.ReadLine();
                    }


                    sr.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }



                FileInfo f2 = new FileInfo(nue);
                f2.MoveTo(Path.ChangeExtension(nue, exori));


            }
            else
            {
                Console.WriteLine("No existe documento");
            }





           

        
        }

        private void escribe() { 
        
            if(File.Exists(ruta)){

                //File.Delete(ruta);

               

                Console.WriteLine(ruta);
                FileInfo f = new FileInfo(ruta);
                String exori = f.Extension;
                f.MoveTo(Path.ChangeExtension(ruta, ".txt"));

                String nue = f.FullName;

                Console.WriteLine(nue);
            StreamWriter file = new StreamWriter(nue);
            //StringCollection lines = new StringCollection();
            int lineCount = textBox1.Lines.Count();
            String liew = "";





            for (int line = 0; line < lineCount; line++)
            {
                liew = textBox1.Lines[line];
                Console.WriteLine(liew);
                file.WriteLine(liew);   
            }
            file.Close();



            FileInfo f2 = new FileInfo(nue);
            f2.MoveTo(Path.ChangeExtension(nue, exori));


            }else{
            Console.WriteLine("No existe documento");
            }


        
        
        
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        


    }
}
