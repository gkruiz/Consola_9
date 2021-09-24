using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console_1._9
{
    public partial class Form1 : Form
    {
        PAnalisis anali;

        ArrayList bitacora;
        public static ArrayList codes;

        ArrayList acerca = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            bitacora = new ArrayList();
            codes = new ArrayList();
            anali = new PAnalisis();
            bitacora.Add("Universidad De San Carlos de Guatemala [Version 9.6.9900]");
            bitacora.Add("(C)2018 Facultad de Ingenieria en Ciencias y Sistemas. All rights reserved.");
            bitacora.Add(" ");

            acerca.Add("KEVIN GOLWER ENRIQUE RUIZ BARBALES ");
            acerca.Add("-------------201603009--------------");
            acerca.Add("lenguajes formales y de programacion");
            
            


            


            //bitacora.Add("Root\\KGERB> ");
            //bitacora.Add("asdfasdfasd");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void EventoEnter(object sender, KeyEventArgs e)
        {
           
        }
        int movi = 0;
        int intento = 0;
        
        private void Evento1(object sender, KeyEventArgs e)
        {

            //Console.WriteLine("hace" + e.KeyCode + "sss");


            try
            {
                String a = Convert.ToString(e.KeyCode);
                if (a.Equals("Return"))
                {
                    String cade = textBox2.Text.Trim();
                    Ventanas(cade);


                    this.textBox2.Text = "";

                    //Console.WriteLine("ingresa:"+cade+"FIN");

                    //Console.WriteLine("hace" + e.KeyCode + "sss");
                    intento = 0;
                    movi = 0;
                    //textBox2.Text = textBox2.Text.Replace("\r\n", "a").Replace("\n", "b").Replace("\r", "c").Replace("\n\r", "c");

                }
                else if (a.Equals("Up"))
                {
                    //Console.WriteLine("arriballlllllllllll");
                    if (movi >= 0)
                    {
                        if (intento == 0)
                        {
                            movi = codes.Count;
                            movi--;
                            intento = 1;
                        }
                        else
                        {
                            if (movi >= codes.Count)
                            {
                                movi = codes.Count - 1;
                            }
                            else
                            {}
                        }
                        textBox2.Text = (String)codes[movi];
                       //Console.WriteLine("arriballlllllllllll" + codes[movi]);
                        movi--;
                    }
                    else
                    {movi = 0;}
                }
                else if (a.Equals("Down"))
                {
                    if (movi < codes.Count)
                    {
                        if (intento == 0)
                        {
                            intento = 1;
                            textBox2.Text = (String)codes[movi];
                            movi++;
                        }
                        else
                        {
                            if (movi <= -1)
                            {movi = 0;}
                            else
                            {}
                            textBox2.Text = (String)codes[movi];
                            movi++;
                        }
                    }
                    else
                    {
                        movi = codes.Count - 1;
                    }
                }
                    }catch(Exception asdf){
            }

            
        }

        private void evento2(object sender, KeyPressEventArgs e)
        {
            

        }

        int conta = 0;
        int contalinea = 4;




        int cr = 0;
        

        public void Ventanas(String cadena) {
            int requerido = 310;
            int tamano = textBox1.Height;

            
            //if (tamano >= requerido)
            
            String cade = cadena.Trim();
            String err = anali.Inicio(cade);

            if (cade.Equals("") || (String.IsNullOrEmpty(cade)))
            {



                
            }
            else {
                if(err.Equals("acercade")){
                    textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    textBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                }else{

                    textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(53)))));
                    textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
                    
                    textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(53)))));
                    textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
                    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(53)))));
                    
                }

                codes.Add(cade);
                


               // Console.WriteLine(cade+"ingreso o nose");
            }



            Console.Write(err+"----------------------------------------------------------");

            if (tamano >= requerido)
            {

                if (err == "no") {
                    cr = 0;
                    bitacora.Add(cade);
                    cambia();
                    textBox2.Clear();
                    contalinea++;
                
                
                }

                else if (err == "acercade")
                {
                    if (cr < acerca.Count)
                    {


                        //bitacora.Add(cade);
                        bitacora.Add("        " + acerca[cr]);
                        cambia();
                        textBox2.Clear();
                        contalinea++;

                        cr++;



                        Ventanas(cadena);

                    }
                    else
                    {


                    }

                }
                else {
                    cr = 0;
                    bitacora.Add(err);
                    cambia();
                    textBox2.Clear();
                    contalinea++;
                
                }
                //textBox1.Text += textBox2.Text +"\n";


                

            }
            else {

                
                




                //*************************************************************************************ver cy¿dado
                String tesp = textBox2.Text.Trim();
                if ((conta ==0))
                {


                    if (err == "no")
                    {

                        

                        bitacora.Add(cade);
                        textBox1.Text += tesp;
                        textBox1.Text += "\r\n" + "Root\\KGERB> ";
                        textBox1.Height = textBox1.Height + 16;
                        textBox2.Location = new System.Drawing.Point(93, textBox1.Height - 25);
                        textBox2.Text = "";
                        textBox2.Clear();
                        cr = 0;


                    }
                    else if (err == "acercade")
                    {
                        if (cr < acerca.Count)
                        {

                            bitacora.Add("        " + acerca[cr]);
                            textBox1.Text += "        " + acerca[cr];
                            textBox1.Text += "\r\n" + "Root\\KGERB> ";
                            textBox1.Height = textBox1.Height + 16;
                            textBox2.Location = new System.Drawing.Point(93, textBox1.Height - 25);
                            textBox2.Text = "";
                            textBox2.Clear();
                            cr++;
                            Ventanas(cadena);

                        }
                        else
                        {

                            cr = 0;
                        }
                    }
                    else
                    {
                        bitacora.Add(err);
                        textBox1.Text += err;
                        textBox1.Text += "\r\n" + "Root\\KGERB> ";
                        textBox1.Height = textBox1.Height + 16;
                        textBox2.Location = new System.Drawing.Point(93, textBox1.Height - 25);
                        textBox2.Text = "";
                        textBox2.Clear();
                        cr = 0;
                    }

                    conta = 1;

                }
                else {


                    if (err == "no")
                    {

                        bitacora.Add(cade);
                        textBox1.Text += tesp;
                        textBox1.Text += "\r\n" + "Root\\KGERB> ";
                        textBox1.Height = textBox1.Height + 16;
                        textBox2.Location = new System.Drawing.Point(93, textBox1.Height - 25);
                        textBox2.Text = "";
                        textBox2.Clear();
                        cr = 0;
                    }
                    else if (err == "acercade")
                    {

                        if(cr<acerca.Count){
                            bitacora.Add("        " + acerca[cr]);
                            textBox1.Text += acerca[cr];
                            textBox1.Text += "\r\n" + "Root\\KGERB> ";
                            textBox1.Height = textBox1.Height + 16;
                            textBox2.Location = new System.Drawing.Point(93, textBox1.Height - 25);
                            textBox2.Text = "";
                            textBox2.Clear();
                            cr++;
                            Ventanas(cadena);
                            
                        }else{

                            cr = 0;
                        }
                        


                    }
                    else
                    {
                        



                        bitacora.Add(err);
                        textBox1.Text += err;
                        textBox1.Text += "\r\n" + "Root\\KGERB> ";
                        textBox1.Height = textBox1.Height + 16;
                        textBox2.Location = new System.Drawing.Point(93, textBox1.Height - 25);
                        textBox2.Text = "";
                        textBox2.Clear();
                        cr = 0;
                    }





                    contalinea++;
                
                }



              //  Console.WriteLine(contalinea+"contador liineas");

                
            }

            


        }



        int linealee = 0;

        private void cambia() {
           
            
               // Console.WriteLine("ENTRO PARA 19, ");
                linealee++;
                textBox1.Clear();
                Console.WriteLine(bitacora.Count);
                //textBox1.Location = new System.Drawing.Point(-1, - 4);


                //leer los ultimos 18
                int resta = bitacora.Count - 18;
               // Console.WriteLine(resta+"saleeeeeeeeee");
                for (int i = bitacora.Count-18; i < bitacora.Count; i++)
                {
                   // Console.WriteLine("linealle"+linealee+"i "+i);
                    String tempo = (String)bitacora[i];
                  //  Console.WriteLine("a ingresar:" +tempo+"////");

                    if ((i == resta))
                    {

                        if ((i == 0) || (i == 1) || (i == 2))
                        {
                            textBox1.Text += tempo;
                        }
                        else {
                            textBox1.Text = "Root\\KGERB> " + tempo;
                        }  
                    }
                    else {
                        if ((i == 0) || (i == 1) || (i == 2))
                        {
                             textBox1.Text += "\r\n" + tempo;
                        }
                        else
                        {
                            textBox1.Text += "\r\n" + "Root\\KGERB> " + tempo;
                        }
                    }
                }

                textBox1.Text += "\r\n" + "Root\\KGERB> ";
            
        
        
        }

        

       //             this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(27)))), ((int)(((byte)(53)))));
       //     this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
    }


}
