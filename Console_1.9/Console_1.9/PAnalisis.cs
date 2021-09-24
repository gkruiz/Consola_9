using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console_1._9
{
    class PAnalisis
    {


        //arbol
        

        int root = 0;
        String rutactual;
        String original;
        Stack rutas = new Stack();
        int contapila = 0;

        //sirve para comandos cargados son listas
        ArrayList archivoComando = new ArrayList();
        ArrayList nombre = new ArrayList();
        //errores
        ArrayList ErrorLinea = new ArrayList();

        ArrayList parainforme2 = new ArrayList();//temporal borrar despues
        ArrayList ErrorArchivo2 = new ArrayList();//guarda solo de ingresa manual
        ArrayList Informe2 = new ArrayList();//temporal borrar despues



        ArrayList parainforme = new ArrayList();//temporal borrar despues
        ArrayList ErrorArchivo = new ArrayList();//temporal borrar despues
        ArrayList Informe = new ArrayList();//temporal borrar despues


        int tipoerror = 0;//ver tipo de fase que se maneja al generar html
        //arbol direc--------------------------
        ArrayList arbolR = new ArrayList();
        //bitacora
        ArrayList BITACORA = new ArrayList();
        //archivos rerportes
        ArrayList Reporte = new ArrayList();
        

        ArrayList RUTACTUAL;

       
        Diagrama asd ;

        public PAnalisis() {
            if (root == 0)
            {
                RUTACTUAL = new ArrayList();
                RUTACTUAL.Add("Root");
                string raiz = @"C:\Users\KRUIZ9\Desktop\Root";
                

                DirectoryInfo di = Directory.CreateDirectory(raiz);
                rutactual = (String)raiz;
                original = (String)raiz;
                
            }
            else
            {

            }
            asd = new Diagrama();
        
        }

        public String Inicio(String cadena) { 
        //cadena nula
            String ingresa = cadena.Trim();
            String dudaerror = "no";

            if ((String.IsNullOrEmpty(ingresa)) || (ingresa.Length == 0) || (ingresa.Equals("")))
            {
                //Console.WriteLine("CADENA NULAO SABER");
            }
            else {


                String s = Error(ingresa,0);

                if (s == "no")
                {

                    ArrayList instrucciones = separa(ingresa);
                    String te= ((String)instrucciones[0]).ToLower();
                    Reservada(instrucciones);

                    Console.WriteLine(te+"!!!!!!!!!!!!!!!");
                    Informe2.Add(instrucciones);
                    infor(instrucciones, 0);
                    bitacora();
                    

                    if(te.Equals("acercade")){

                        dudaerror = "acercade";
                    }else{


                    }
                    
                   
                }
                else
                {



                    dudaerror = s;

                }
                Console.WriteLine("///"+arbolR.Count);
                //////bueno
               
               if(asd.Visible){
                   String con= "";
                   for(int i=0;i<RUTACTUAL.Count;i++){
                       con = con + RUTACTUAL[i] + "/";
                   
                   }
                   asd.label1.Text = con;


                   asd.treeView1.Nodes.Clear();
                   asd.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            NODOS1( 0)});
                   
                   asd.treeView1.ExpandAll();

               }else{
                   
                   
                   asd = new Diagrama();
                   asd.treeView1.Nodes.Clear();
                   String con = "";
                   for (int i = 0; i < RUTACTUAL.Count; i++)
                   {
                       con = con + RUTACTUAL[i]+"/";

                   }
                   asd.label1.Text = con;

                   asd.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            NODOS1( 0)});
                   asd.treeView1.ExpandAll();
                   asd.Show();

               
               }
                
            }

            
            html(ErrorArchivo2, "Salida Consola", parainforme2);

            return dudaerror;
        }
        public String Inicio2(String cadena,int fila)
        {
            //cadena nula
            String ingresa = cadena.Trim();
            String dudaerror = "no";

            if ((String.IsNullOrEmpty(ingresa)) || (ingresa.Length == 0) || (ingresa.Equals("")))
            {
                //Console.WriteLine("CADENA NULAO SABER");,
            }
            else
            {


                String s = Error(ingresa,fila);

                if (s == "no")
                {

                    ArrayList instrucciones = separa(ingresa);
                    Reservada(instrucciones);
                    Informe.Add(instrucciones);
                    //for(int i=0;i<instrucciones.Count;i++){

                    //    Informe.Add(instrucciones[i]);
                    //}
                    infor(instrucciones,fila);
                    bitacora();
                }
                else
                {


                }
                Console.WriteLine("///" + arbolR.Count);
                //////bueno

                

            }

            return dudaerror;
        }




        //nodos

        private ArrayList enlista(ArrayList array,int index) {
            //el index debe ser el NIVEL mas 1 de donde esta
            //ejemplo nivel 0 index=1
            //nivel 1 index 2


            ArrayList nod = new ArrayList();
            Console.WriteLine(index+"Index a analizar");
            //Console.WriteLine(RUTACTUAL.Count + "Tamano de Ruta actual");
            //Console.WriteLine(RUTACTUAL.Count + "Tamano de array nod1");


            if(array.Count.Equals(0)){
            //si esta vacio el array no hace nada
            }else{








                for (int i = 0; i < array.Count; i++)
                {

                    ArrayList temp = temp = (ArrayList)array[i];//ruta [Root][NOSE][] RUTA QUE SACA DE LA LISTA DE RUTAS    

                    

                    //RUTATEMPORAL  NIVELque trae
                    if ((temp.Count-1)<index)
                    {
                        //si es menor no hace nada porque n puede analizar lo que le sigue

                    }
                    else
                    {
                                    Console.WriteLine("PASO tamano de ruta mayor que index");
                                    //index analiza su valor real en array
                                    //tamano de rutatemporal analiza hasta uno menos

                                
                                    //comprueba si esta vacio el array a enviar
                                    if (nod.Count == 0)
                                    {
                                        Console.WriteLine(temp[index]);
                                            //del Rutatemporal guardo el contenido dela casilla index en array nod
                                        nod.Add(temp[index]);
                                    }
                                    else
                                    {

                                        Console.WriteLine("/tamano--" + nod.Count);


                                                    int fijo = nod.Count;


                                        //si ya tuviera guardado mas de algun item

                                                    for (int j = 0; j < fijo; j++)
                                                    {
                                                        Console.WriteLine("//" + j);
                                                        //comparo la casilla de rutatemporal con el contenido de nod arraya enviar
                                                                    if (temp[index].Equals(nod[j]))
                                                                    {
                                                                        //si encuentra que ya hay uno se sale del ciclo
                                                                        break;
                                                                    }
                                                                    else
                                                                    {

                                                                                if (j == (nod.Count - 1))
                                                                                {
                                                                                    nod.Add(temp[index]);
                                                                                }
                                                                                else
                                                                                {

                                                                                }
                                                                    }

                                                    }


                                    }


                    }




                }







            
            }




            Console.WriteLine(nod.Count + "entrega ENLISTA");
           // Console.WriteLine(RUTACTUAL.Count + "Tamano de array nod2");



            return nod;
        
        }
        private ArrayList Rama(int index) {
            //recibe el nivel mas 1 en el que esta
            //si la cadena es mayor se envia 
            //si es igual tiene que ver

            ArrayList Narbol = new ArrayList();//array a enviar
            ArrayList rutaCarpeta = (ArrayList)RUTACTUAL.Clone();

            


                for (int i = 0; i < arbolR.Count; i++)
                {
                    ArrayList temporal = (ArrayList)arbolR[i];

               //     Console.WriteLine("busca en :" + index + "rutactactual" + RUTACTUAL.Count);
                    //temporal es la ruta que saca de la lista de rutas
                    //devuelve rutas array si solo si es mayor porque son los nodos que le siguien
                                    if (temporal.Count >= index)
                                        {
                                                for (int j = 0; j < index; j++)
                                                {
                                                    //rutacapeta string
                                                    //temporal strings
                                                    //array rutya actual es igual a la ruta en la que estoy acualmente va de posicion enposicion
                                                                if (temporal[j].Equals(rutaCarpeta[j]))
                                                                {
                                                                                if (j == (index - 1))
                                                                                {
                                                                                    // Narbol.Add(temporal[RUTACTUAL.Count]);
                                                                                    Narbol.Add(temporal);
                                                                                }
                                                                                else
                                                                                {

                                                                                }
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                }

                                }
                                else if (temporal.Count == rutaCarpeta.Count)
                                {
                                    //ver cuando son iguales

                                    //crearcarpeta Juan  ---> Root | Juan tamano =2
                                    //tamano ruta actual =1

                                    //abrirc Juan  ---> Root | Juan tamano =2
                                    //tamano ruta actual =2


                                }
                                else
                                {
                                }

                }
                //fin for




                Console.WriteLine(Narbol.Count+"entrega NARBOL");

            return Narbol;

        
        
        }

        private TreeNode NODOS1(int nivel)
        {
            System.Windows.Forms.TreeNode treeNode3 = null;
            System.Windows.Forms.TreeNode treeNode1 = null;
            System.Windows.Forms.TreeNode treeNode2 = null;


            Console.WriteLine("NIVEL------------------------------------------------------//" + nivel);
          //  Console.WriteLine("rta-----------------------------------------------//" + RUTACTUAL.Count);

            if (RUTACTUAL.Count == 1)
            {
                treeNode3 = new System.Windows.Forms.TreeNode("Root");
                treeNode3.SelectedImageIndex = 2; 


                treeNode3.ImageIndex = 2;

                ArrayList uso = enlista((ArrayList)arbolR.Clone(),1);
                //Console.WriteLine("TAMANO DE USO //"+uso.Count);
                for(int i=0;i<uso.Count;i++){

                    treeNode1 = new System.Windows.Forms.TreeNode((String)uso[i]);
                    

                    String usox=(String)uso[i];
                    if(usox.Length>=5){

                        Console.WriteLine("TA------" + usox[usox.Length - 4]);
                        if((usox[usox.Length-4]).Equals('.')){

                            Console.WriteLine("TAlllll------" + usox[usox.Length - 4]);
                            treeNode1.SelectedImageIndex = 0;
                            treeNode1.ImageIndex = 0;
                        }else{

                            treeNode1.SelectedImageIndex = 1;
                            treeNode1.ImageIndex = 1;
                        }
                    }else{
                        treeNode1.SelectedImageIndex = 1;
                        treeNode1.ImageIndex = 1;
                    }




                   


                treeNode3.Nodes.Add(treeNode1);
                }
                
            }
            else {
                if(nivel==0){
                    treeNode3 = new System.Windows.Forms.TreeNode("Root");
                    treeNode3.SelectedImageIndex = 1;


                    treeNode3.ImageIndex = 1;





                    ArrayList uso = enlista((ArrayList)arbolR.Clone(), 1);
               //     Console.WriteLine("TAMANO DE USO nivel en cero//" + uso.Count);
                    for (int i = 0; i < uso.Count; i++)
                    {

                        String a1 = (String)uso[i];
                        String a2 = (String)RUTACTUAL[nivel+1];
                     //   Console.WriteLine("/////en cero/////////"+a1);
                      //  Console.WriteLine("/////en cero/////////"+a2);
                        if (a1.Equals(a2))
                        {

                            TreeNode dsd = NODOS1(nivel + 1);
                            treeNode3.Nodes.Add(dsd);
                        }
                        else
                        {





                            treeNode1 = new System.Windows.Forms.TreeNode((String)uso[i]);


                            String usox = (String)uso[i];
                            if (usox.Length >= 5)
                            {

                                Console.WriteLine("TA------" + usox[usox.Length - 4]);
                                if ((usox[usox.Length - 4]).Equals('.'))
                                {

                                    Console.WriteLine("TAlllll------" + usox[usox.Length - 4]);
                                    treeNode1.SelectedImageIndex = 0;
                                    treeNode1.ImageIndex = 0;
                                }
                                else
                                {

                                    treeNode1.SelectedImageIndex = 1;
                                    treeNode1.ImageIndex = 1;
                                }
                            }
                            else
                            {
                                treeNode1.SelectedImageIndex = 1;
                                treeNode1.ImageIndex = 1;
                            }














                            treeNode3.Nodes.Add(treeNode1);
                        }
                        
                    }
                    

                }else{
                        //Console.WriteLine("INICIO PARA FASE UNO: " + RUTACTUAL[nivel]);
                        treeNode3 = new System.Windows.Forms.TreeNode((String)RUTACTUAL[nivel]);
                        treeNode3.SelectedImageIndex = 1;


                        treeNode3.ImageIndex = 1;


                    ArrayList posibl = null;


                    try
                        {
                            posibl = Rama(nivel+1);
                        }catch(Exception sew){
                            posibl =new ArrayList();                  
                        }
                    //Console.WriteLine("PASO DESPUES POSIBL aqui");
                    ArrayList uso = null;
                    try
                    {
                        uso = enlista(posibl, nivel+1);
                    }
                    catch (Exception sew)
                    {
                        uso = new ArrayList();
                    }
                 
                   // Console.WriteLine("TAMANO DE USO nivel en cero//" + uso.Count);
                    for (int i = 0; i < uso.Count; i++)
                    {
                        if (RUTACTUAL.Count==(nivel+1))
                        {
                            treeNode1 = new System.Windows.Forms.TreeNode((String)uso[i]);


                            treeNode3.SelectedImageIndex = 2;
                            treeNode3.ImageIndex = 2;


                            String usox = (String)uso[i];
                            if (usox.Length >= 5)
                            {

                                Console.WriteLine("TA------" + usox[usox.Length - 4]);
                                if ((usox[usox.Length - 4]).Equals('.'))
                                {

                                    Console.WriteLine("TAlllll------" + usox[usox.Length - 4]);
                                    treeNode1.SelectedImageIndex = 0;
                                    treeNode1.ImageIndex = 0;
                                }
                                else
                                {

                                    treeNode1.SelectedImageIndex = 1;
                                    treeNode1.ImageIndex = 1;
                                }
                            }
                            else
                            {
                                treeNode1.SelectedImageIndex = 1;
                                treeNode1.ImageIndex = 1;
                            }

                            treeNode3.Nodes.Add(treeNode1);





                        }else{


                            String a1 = (String)uso[i];
                            String a2 = (String)RUTACTUAL[nivel + 1];
                          //  Console.WriteLine("//////////////" + a1);
                         //   Console.WriteLine("/////////////" + a2);
                            if (a1.Equals(a2))
                            {

                                TreeNode dsd = NODOS1(nivel + 1);
                                treeNode3.Nodes.Add(dsd);
                            }
                            else
                            {
                                treeNode1 = new System.Windows.Forms.TreeNode((String)uso[i]);

                                String usox = (String)uso[i];
                                if (usox.Length >= 5)
                                {

                                    Console.WriteLine("TA------" + usox[usox.Length - 4]);
                                    if ((usox[usox.Length - 4]).Equals('.'))
                                    {

                                        Console.WriteLine("TAlllll------" + usox[usox.Length - 4]);
                                        treeNode1.SelectedImageIndex = 0;
                                        treeNode1.ImageIndex = 0;
                                    }
                                    else
                                    {

                                        treeNode1.SelectedImageIndex = 1;
                                        treeNode1.ImageIndex = 1;
                                    }
                                }
                                else
                                {
                                    treeNode1.SelectedImageIndex = 1;
                                    treeNode1.ImageIndex = 1;
                                }

                                treeNode3.Nodes.Add(treeNode1);
                            }


                        
                        }


                        
                    }



                }



            
            }

            return treeNode3 ;
        }
        //nodos



        //devuelve erores ruta sencilla
        private String Error(String cadena,int fila)
        {
            String err = "no";
            Console.WriteLine(cadena+"***inicial");
            //primera fase signo desconocido
            String error1 = automata(cadena, 0, "no",fila);
            Console.WriteLine(error1+"asdfasdf");


            ArrayList envi = new ArrayList();
            if (error1.Equals("si"))
            {
               Console.WriteLine("Error signo desconocido");
               Console.WriteLine(cadena);
               err = "Error signo desconocido";
           }else{
               //segunda fase error de palabra reservada

               ArrayList instrucciones = separa(cadena);
               String error2 = ErrorReservada(instrucciones);
               if (error2.Equals("si"))
               {
                   err = "Palabra no reservada";
                   Console.WriteLine("Palabra no reservada");
                   Console.WriteLine(cadena);


                   if(tipoerror==1){
                       envi.Add(fila);
                       envi.Add(cadena);
                       envi.Add(err);
                   
                   }else{
                   
                   
                   }
                   



               }else{
               //Tercera fase error de palabra reservada tamano datos
                   String error3 = TamaReservada(instrucciones);

                   if (error3.Equals("si"))
               {
                   err = "Tamaño Reservada Incorrecto";
                   Console.WriteLine("Tamaño Reservada Incorrecto");
                   if (tipoerror == 1)
                   {
                       envi.Add(fila);
                       envi.Add(cadena);
                       envi.Add(err);

                   }
                   else
                   {


                   }


               }else{

                   //cuarta fase identificadores
                   String error4 = ErrorIden(instrucciones);

                   if (error4.Equals("si"))
                   {
                       Console.WriteLine("Ruta o ID erroneo");
                       err = "Ruta o ID erroneo";

                       if (tipoerror == 1)
                       {
                           envi.Add(fila);
                           envi.Add(cadena);
                           envi.Add(err);

                       }
                       else
                       {


                       }
                   }
                   else
                   {
                       
                   }

                }


               }
           
           }

           return err;
        }
        private String ErrorReservada(ArrayList reser)
        {

            String duda = "no";

            String reserva = (String)reser[0];
            String temp = reserva.ToLower();

            Console.WriteLine("reservada: " + temp);
            switch (temp)
            {

                case "crearcarpeta":

                    break;
                case "renombrarc":

                   
                    break;
                case "verreportes":


                    break;
                case "abrirc":
                    
                    break;

                case "regresar":
                    
                    break;

                case "eliminarc":
                    
                    break;

                case "creararchivo":
                    
                    break;

                case "abrirarchivo":
                    
                    break;

                case "renombrara":
                    
                    break;

                case "mover":
                    
                    break;

                case "copiar":
                    
                    break;

                case "eliminara":
                   
                    break;
                case "cargar":
                    
                    break;
                case "ejecutar":
                    
                    break;
                case "manualusuario":
                    
                    break;
                case "manualtecnico":
                   
                    break;
                case "acercade":
                    
                    break;
                default:
                    Console.WriteLine("no es palabra reservada");
                    duda = "si";
                    //guarda error reservada
                    break;
            }

            return duda;
        }
        private String TamaReservada(ArrayList reser)
        {
            //creac();
            int tamano = reser.Count;
            String duda = "no";

            String reserva = (String)reser[0];
            String temp = reserva.ToLower();



            Console.WriteLine("reservada: " + temp);
            switch (temp)
            {

                case "crearcarpeta":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                        
                    }

                    break;

                case "verreportes":
                    if (tamano == 1)
                    {

                    }
                    else
                    {
                        duda = "si";

                    }

                    break;

                case "renombrarc":

                    if (tamano == 3)
                    {
                       
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;
                case "abrirc":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "regresar":
                    if (tamano == 1)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "eliminarc":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                   
                    break;

                case "creararchivo":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "abrirarchivo":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "renombrara":
                    if (tamano == 3)
                    {
                       
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "mover":
                    if (tamano == 3)
                    {
                       
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "copiar":
                    if (tamano == 3)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;

                case "eliminara":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;
                case "cargar":
                    if (tamano == 3)
                    {
                       
                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;
                case "ejecutar":
                    if (tamano == 2)
                    {
                        
                    }
                    else
                    {
                        duda = "si";
                    }
                   
                    break;
                case "manualusuario":
                    if (tamano == 1)
                    {

                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;
                case "manualtecnico":
                    if (tamano == 1)
                    {

                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;
                case "acercade":
                    if (tamano == 1)
                    {

                    }
                    else
                    {
                        duda = "si";
                    }
                    
                    break;
                default:
                    Console.WriteLine("no es palabra reservada");

                    //guarda error reservada
                    break;



            }

            return duda;
        }
        private String ErrorIden(ArrayList reser)
        {

            String duda = "no";

            String reserva = (String)reser[0];
            String temp = reserva.ToLower();
             String a1="" ;
             String a2 = "";
             String a3 = "";
             String a4 = "";
                 
            //try {
            //    a1 = AIdentificador((String)reser[1], 0, "no");
            //}catch(Exception asdf){
            //}

            //try
            //{
               //a2 = AIdentificador((String)reser[2], 0, "no");
            //}
            //catch (Exception asdfs)
            //{
            //}

            //try
            //{
            //     a3 = ARutasimple((String)reser[2], 0, 0, "no");
            //}
            //catch (Exception asdfd)
            //{
            //}
            //try
            //{
            //   a4 = ARutaGrande((String)reser[1], 0, 0, "no");
            //}
            //catch (Exception asdfw)
            //{
            //}
            
            



           
            
            //(String cadena, int posicion,int diago,String dudas)
            
            Console.WriteLine("reservada: " + temp);
            switch (temp)
            {

                case "crearcarpeta":
                    duda=AIdentificador((String)reser[1],0,"no");
                    break;
                case "renombrarc":
                    

                    if((a1=="si")||(a2=="si")){
                        duda = "si";
                    }else{
                        
                    }

                    break;
                case "abrirc":
                    duda = AIdentificador((String)reser[1], 0, "no");
                    break;

                case "verreportes":

                    break;

                case "eliminarc":
                    duda = AIdentificador((String)reser[1], 0, "no");
                    break;

                case "creararchivo":
                    duda = AIdentificador((String)reser[1], 0, "no");
                    break;

                case "abrirarchivo":
                    duda = AIdentificador((String)reser[1], 0, "no");
                    break;

                case "renombrara":


                    if ((AIdentificador((String)reser[1], 0, "no") == "si") || (AIdentificador((String)reser[2], 0, "no") == "si"))
                    {
                        duda = "si";
                    }else{
                        
                    }
                    break;

                case "mover":
                    Console.WriteLine(reser[1] + "////" + reser[2]);
                    if (((AIdentificador((String)reser[1], 0, "no") == "si") || (ARutasimple((String)reser[2], 0, 0, "no") == "si")))
                    {
                        duda = "si";
                    }
                    else
                    {

                    }

                    
                    break;

                case "copiar":

                    if (((AIdentificador((String)reser[1], 0, "no") == "si") || (ARutasimple((String)reser[2], 0, 0, "no") == "si")))
                    {
                        duda = "si";
                    }
                    else
                    {

                    }
                    
                    break;

                case "eliminara":
                    duda = AIdentificador((String)reser[1], 0, "no");
                    break;
                case "cargar":
                    Console.WriteLine(reser[1]+"********************************");
                    if ((ARutasimple((String)reser[1], 0, 0, "no") == "si") || (AIdentificador((String)reser[2], 0, "no") == "si"))
                    {
                        duda = "si";
                    }
                    else
                    {

                    }

                    break;
                case "ejecutar":
                    duda = AIdentificador((String)reser[1], 0, "no");
                    break;
                case "manualusuario":

                    break;
                case "manualtecnico":

                    break;
                case "acercade":

                    break;
                case "regresar":

                    break;
                default:
                    Console.WriteLine("no es palabra reservada");
                    duda = "si";
                    //guarda error reservada
                    break;
            }

            return duda;
        }
        private String AIdentificador(String cadena, int posicion, String dudas)
        {

            String duda;
            if (posicion == 0)
            {
                duda = "no";
            }
            else
            {
                duda = dudas;
            }
           // Console.WriteLine("ENTRO IDENTIFICADOR ERROR" + posicion + "///");
            int resta = cadena.Length - 1;

           // Console.WriteLine("ENTRO IDENTIFICADOR ERROR" + posicion + "///" + cadena + "//" + resta);

            if (posicion > (resta))
            {
                //guarda errores si hubiera
                Console.WriteLine("entro final");
            }
            else
            {


                //Console.WriteLine("entro pro");


                String letra = Convert.ToString(cadena[posicion]);
                String tipore = tipo(letra);



                //if((posicion==0)&&(tipore!="letra")){
                //    Console.WriteLine("Error no es identificador");

                //    duda = "si";

                //}else{
                switch (tipore)
                {
                    case "letra":
                        duda = AIdentificador(cadena, posicion + 1, dudas);
                        break;
                    case "numero":
                        duda = AIdentificador(cadena, posicion + 1, dudas);
                        break;
                    case "guion":
                        duda = AIdentificador(cadena, posicion + 1, dudas);
                        break;
                    default:
                        Console.WriteLine("Error Signo desconocido");
                        duda = AIdentificador(cadena, posicion + 1, "si");//sellama otra vez para ver mas errores de signos contemplados pero no para este
                        break;

                }


                //}




            }
            return duda;

        }
        //private String ARutaGrande(String cadena, int posicion, int diago, String dudas)
        //{//debe rretorna los errores
        //    String duda;
        //    if (posicion == 0)
        //    {
        //        duda = "no";
        //    }
        //    else
        //    {
        //        duda = dudas;
        //    }


        //    try
        //    {
        //        Console.WriteLine("valua" + cadena[posicion] + "es>" + duda);
        //    }
        //    catch (Exception werwer)
        //    {


        //    }


        //    if (posicion > (cadena.Length - 1))
        //    {
        //        //guarda errores si hubiera C:\Users\KRUIZ9\Desktop\comandos.txt
        //    }
        //    else if (posicion == 0)
        //    {

        //        String letra = Convert.ToString(cadena[0]);
        //        String tipore = tipo(letra);
        //        if (letra == "C")
        //        {
        //            duda = ARutaGrande(cadena, posicion + 1, diago, dudas);
        //        }
        //        else
        //        {
        //            duda = ARutaGrande(cadena, posicion + 1, diago, "si");
        //        }
        //    }
        //    else if (posicion == 1)
        //    {
        //        String letra = Convert.ToString(cadena[1]);
        //        String tipore = tipo(letra);
        //        if (letra == ":")
        //        {
        //            duda = ARutaGrande(cadena, posicion + 1, diago, dudas);
        //        }
        //        else
        //        {
        //            duda = ARutaGrande(cadena, posicion + 1, diago, "si");
        //        }
        //    }
        //    else if (posicion == 2)
        //    {
        //        String letra = Convert.ToString(cadena[2]);
        //        String tipore = tipo(letra);
        //        if (letra == "\\")
        //        {


        //            if (diago == 1)
        //            {

        //                //ARutasimple(cadena, posicion++, diago);
        //                //gudarda eeror de diagonal anterior porque solo con que haya un error ya no analiza mas de mismo
        //                if (posicion != (cadena.Length - 1))
        //                {


        //                    // no hace nada porque con un error se guarda al finalizar esto
        //                    duda = duda = ARutaGrande(cadena, posicion + 1, diago, dudas);

        //                }
        //                else
        //                {

        //                    duda = duda = ARutaGrande(cadena, posicion + 1, diago, dudas);
        //                }


        //            }
        //            else
        //            {

        //                if (posicion != (cadena.Length - 1))
        //                {
        //                    String sigui = Convert.ToString(cadena[posicion + 1]);
        //                    if (sigui != "\\")
        //                    {
        //                        duda = duda = ARutaGrande(cadena, posicion + 1, diago, dudas);
        //                    }
        //                    else
        //                    {

        //                        duda = duda = ARutaGrande(cadena, posicion + 1, 1, "si");

        //                        Console.WriteLine("Se hallo mas diagonales");
        //                    }


        //                }
        //                else
        //                {
        //                    duda = "si";

        //                    //no hace nada pero igual error 0
        //                }





        //            }






        //        }
        //        else
        //        {
        //            duda = ARutaGrande(cadena, posicion + 1, 1, "si");
        //        }


        //    }
        //    else
        //    {
        //        String letra = Convert.ToString(cadena[posicion]);
        //        String tipore = tipo(letra);

        //        duda = ARutasimple(cadena, posicion, diago, dudas);





        //    }

        //    return duda;
        //}
        private String ARutasimple(String cadena, int posicion, int diago, String dudas)
        {//debe rretorna los errores

            String duda;
            if (posicion == 0)
            {
                duda = "no";
            }
            else
            {
                duda = dudas;
            }



            try
            {
                Console.WriteLine("valua en otro " + cadena[posicion] + "es>" + duda);
            }
            catch (Exception wewerwer)
            {


            }


            if (posicion > (cadena.Length - 1))
            {
                //guarda errores si hubiera
            }
            else
            {
                String letra = Convert.ToString(cadena[posicion]);
                String tipore = tipo(letra);

                String letra2 = Convert.ToString(cadena[0]);
                String tipore2 = tipo(letra2);

                if ((tipore2 == "letra") || (tipore2 == "numero") || (tipore2 == "guion"))
                {

                switch (tipore)
                {
                    case "letra":
                        duda = ARutasimple(cadena, posicion + 1, diago, dudas);
                        break;
                    case "numero":
                        //if(posicion==0){
                        duda = ARutasimple(cadena, posicion + 1, diago, dudas);
                        //}else{
                        //    if ((Convert.ToString(cadena[posicion - 1])) == "\\")
                        //    {
                        //        duda = "si";
                        //        duda = ARutasimple(cadena, posicion + 1, diago, "si");
                        //    }
                        //    else
                        //    {
                        //        duda = ARutasimple(cadena, posicion + 1, diago, dudas);
                        //    }

                        //}




                        break;
                    case "guion":
                        duda = ARutasimple(cadena, posicion + 1, diago, dudas);
                        break;
                    //case "punto":


                    //    if (posicion != (cadena.Length - 1))
                    //    {
                    //        String tip =tipo( Convert.ToString(cadena[posicion - 1]));
                    //        String tip2 = tipo(Convert.ToString(cadena[posicion + 1]));
                    //        if (((tip == "letra") || (tip == "numero") || (tip == "guion")) && (tip2 == "letra"))
                    //        {

                    //            duda = ARutasimple(cadena, posicion + 1, diago, dudas);
                    //        }else{
                    //            duda = ARutasimple(cadena, posicion + 1, diago, "si");
                    //        }
                    //    }
                    //    else { 



                    //    }

                    //    break;
                    case "diagonal":
                        if (diago == 1)
                        {

                            //ARutasimple(cadena, posicion++, diago);
                            //gudarda eeror de diagonal anterior porque solo con que haya un error ya no analiza mas de mismo
                            if (posicion != (cadena.Length - 1))
                            {


                                // no hace nada porque con un error se guarda al finalizar esto
                                duda = ARutasimple(cadena, posicion + 1, 1, dudas);

                            }
                            else
                            {

                                duda = ARutasimple(cadena, posicion + 1, 1, "si");
                            }


                        }
                        else
                        {

                            if (posicion != (cadena.Length - 1))
                            {
                                String sigui = Convert.ToString(cadena[posicion + 1]);
                                if (sigui != "\\")
                                {
                                    duda = ARutasimple(cadena, posicion + 1, diago, dudas);
                                }
                                else
                                {

                                    duda = ARutasimple(cadena, posicion + 1, 1, "si");

                                    Console.WriteLine("Se hallo mas diagonales");
                                }


                            }
                            else
                            {
                                duda = "si";

                                //no hace nada pero igual error 0
                            }





                        }




                        break;
                    default:
                        Console.WriteLine("Error Signo desconocido");
                        duda = ARutasimple(cadena, posicion + 1, diago, "si");//sellama otra vez para ver mas errores de signos contemplados pero no para este
                        break;

                }

                }
                else
                {
                    duda = "si";

                }




            }

            return duda;
        }

        //errorres-----------------------------------a


        




        //regresa error
        private String automata(String cadena, int contador,String dudas,int fila)
        {
            int fil;
            String duda;
            if (tipoerror == 0)
            {
                fil = 999;
            }else{
                fil = fila;
            }


           
            


            if(contador==0){
                duda = "no";
            }else{
                duda = dudas;
            }
            

            


            if(contador>(cadena.Length-1)){

            }else{
                String caracter = Convert.ToString(cadena[contador]);
                String tipos = tipo(caracter);
            
            switch(tipos){
            
                case"letra":
                    duda = automata(cadena, contador + 1, dudas, fil); 
                    break;
                case "numero":
                    duda = automata(cadena, contador + 1, dudas, fil); 
                    break;
                case "guion":
                    duda = automata(cadena, contador + 1, dudas, fil); 
                    break;
                case "espacio":
                    duda = automata(cadena, contador + 1, dudas, fil); 
                    break;
                case "diagonal":
                    duda = automata(cadena, contador + 1, dudas, fil);
                    break;
                //case "punto":
                //    duda = automata(cadena, contador + 1, dudas, fil);
                //    break;
                //case "dospuntos":
                //    duda = automata(cadena, contador + 1, dudas, fil);
                //    break;
                default:
                    duda = "si";
                    ArrayList data = new ArrayList();

                    data.Add(caracter);//char
                    data.Add(fil);//fila
                    data.Add(contador);//columna
                    data.Add("Desconocido");
                    Console.WriteLine("Dis error-----------------------------+-+-+-+-+-+-" + data);
                    //ver si es eror linea o archivo
                    //errores.Add(data);
                    if (tipoerror==1)
                    {
                        ErrorArchivo.Add(data);
                    
                    }else{

                        ErrorArchivo2.Add(data);
                    }



                    duda = automata(cadena, contador + 1, duda, fil);
                    Console.WriteLine("Error en lineaaaaaa"+duda);
                    break;
            }



            }
            //Console.WriteLine("regresa" + duda);

            return duda;
        
        }

        private String tipo(String cara) {
            String regresa = "Error";

          String[]  letras = new String[] { "Á", "É", "Í", "Ó", "Ú", "á", "é", "í", "ó", "ú", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", };
          String[] numeros = new String[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


          for (int i = 0; i < letras.Length; i++)
          {
              if (cara.Equals(letras[i]))
              {
                  regresa = "letra";
                  break;
              }
              else
              {
              }
          }

          for (int i = 0; i < numeros.Length; i++)
          {
              if (cara.Equals(numeros[i]))
              {
                  regresa = "numero";
                  break;
              }
              else
              {
              }
          }

          
              if (cara.Equals("_"))
              {
                  regresa = "guion";
                  
              }
              else
              {
              }

              if (cara.Equals(" "))
              {
                  regresa = "espacio";

              }
              else
              {
              }

              if (cara.Equals("\\"))
              {
                  regresa = "diagonal";

              }
              else
              {
              }

              if (cara.Equals("."))
              {
                  regresa = "punto";

              }
              else
              {
              }
              if (cara.Equals(":"))
              {
                  regresa = "dospuntos";

              }
              else
              {
              }

              return regresa;

        
        }

        private void Reservada(ArrayList reser) {
            //creac();
            int tamano = reser.Count;


            String reserva= (String)reser[0];
            String temp = reserva.ToLower();



            Console.WriteLine("reservada: "+temp);
        switch(temp){
        
            case "crearcarpeta":
                if (tamano == 2)
                {
                    creacarpeta(reser);
                }
                else {
                    Console.WriteLine("Argumento no valido");
                }

                Console.WriteLine("crearcarpeta");
                break;
            case "renombrarc":

                if (tamano == 3)
                {
                    renombrar(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("renombrarc");
                break;
            case "abrirc":
                if (tamano == 2)
                {
                    abrirc(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("abrirc");
                break;

            case "regresar":
                if (tamano == 1)
                {
                    regresar();
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("regresar");
                break;

            case "eliminarc":
                if (tamano == 2)
                {
                    eliminarc(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("eliminarc");
                break;

            case "creararchivo":
                if (tamano == 2)
                {
                    crearchivo(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("creararchivo");
                break;

            case "abrirarchivo":
                if (tamano == 2)
                {
                    abrirarchivo(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("abrirarchivo");
                break;

            case "renombrara":
                if (tamano == 3)
                {
                    renombrarar(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("renombrara");
                break;

            case "mover":
                if (tamano == 3)
                {
                    mover(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("mover");
                break;

            case "copiar":
                if (tamano == 3)
                {
                    copiar(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("copiar");
                break;

            case "eliminara":
                if (tamano == 2)
                {
                    eliminar(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("eliminara");
                break;
            case "cargar":
                if (tamano == 3)
                {
                    CargarRuta(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("cargar");
                break;
            case "ejecutar":
                if (tamano == 2)
                {
                    Ejecutar(reser);
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("ejecutar");
                break;
            case "manualusuario":
                if (tamano == 1)
                {
                    Process.Start("Manual de Usuario.pdf");
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("manualusuario");
                break;
            case "manualtecnico":
                if (tamano == 1)
                {
                    Process.Start("Manual Tecnico.pdf");
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("manualtecnico");
                break;
            case "acercade":
                if (tamano == 1)
                {

                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("acercade");
                break;

            case "verreportes":
                if (tamano == 1)
                {


                    reportes();
                }
                else
                {
                    Console.WriteLine("Argumento no valido");
                }
                Console.WriteLine("acercade");
                break;
            default:
                Console.WriteLine("no es palabra reservada");

                //guarda error reservada
                break;


        
        }
        
        
        }

        private ArrayList separa(String cadena) {
            ArrayList envi = new ArrayList();
            String concatena = "";


            for (int i = 0; i < cadena.Length; i++)
            {

                String charr= Convert.ToString(cadena[i]);

                if(charr.Equals(" ")){
                    //verr puede dar erro no reconozca ""
                    if(concatena.Equals("")){
                    }else{
                        envi.Add(concatena);
                        concatena = "";

                    }
                }else{
                    concatena = concatena + charr;
                
                }

                if (i == (cadena.Length - 1))
                {
                    if (concatena.Equals(""))
                    {
                    }
                    else
                    {
                        envi.Add(concatena);
                        concatena = "";

                    }

                }
                else { 
                
                
                }
            }



            return envi;
        }





        //inicio de funciones
        private void creacarpeta(ArrayList array) {



            string path = @""+ rutactual+"\\"+ array[1];
            Console.WriteLine(path);
            try
            {
              
                if (Directory.Exists(path))
                {
                    Console.WriteLine("La carpeta ya exite");
                    return;
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("La carpeta fue creada con exito.", Directory.GetCreationTime(path));

                    ArrayList temp = null;
                    temp = (ArrayList)RUTACTUAL.Clone();
                    temp.Add(array[1]);
                    arbolR.Add(temp);
                }
                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                //Console.WriteLine("The process failed: {0}", e.ToString());
            }
        
        
        }

        private void renombrar(ArrayList array)
        {

           
            
           // string path = @"C:\Users\KRUIZ9\Desktop\Root\" + array[1];


            String anterior = (String)@""+rutactual+"\\"+array[1];
            String siguiente = (String)@"" + rutactual + "\\" + array[2];


            if (Directory.Exists(anterior))
                
            {
                Console.WriteLine("existe");
                Directory.Move(anterior, siguiente);


                ArrayList Narbol = new ArrayList();
                ArrayList rutaCarpeta = (ArrayList)RUTACTUAL.Clone();
                rutaCarpeta.Add(array[1]);//agrego nombre carpeta a editar


                for(int i=0;i<arbolR.Count;i++){
                ArrayList temporal = (ArrayList)arbolR[i];

                    for(int j=0;j<rutaCarpeta.Count;j++){
                    
                    
                           if(temporal.Count>=rutaCarpeta.Count){
                
                                    if(temporal[j].Equals(rutaCarpeta[j])){
                
                                                if(j==(rutaCarpeta.Count-1)){
                                                    ArrayList restoR = new ArrayList();
                                                    restoR = (ArrayList)RUTACTUAL.Clone();
                                                    restoR.Add(array[2]);
                                                                for (int k = j+1; k < temporal.Count; k++)
                                                                {
                                                                    restoR.Add(temporal[k]);

                                                                }
                                                                Narbol.Add(restoR);
                                                }else{
                                                }
                                    }else{
                                        Narbol.Add(temporal);
                                        //pero lo guarda
                                        break;
                                    }


                
                            }else{
                                Narbol.Add(temporal);
                            //lo guarda
                            }
                    }
                }
                //fin for

                arbolR = (ArrayList)Narbol.Clone();


            }
            else {
                Console.WriteLine("no existe");
            
            }
        
        }

        private void abrirc(ArrayList array)
        {

           
            String abre = (String)@"" + rutactual +"\\"+ array[1];
            

            if (Directory.Exists(abre))
            {
                rutas.Push(array[1]);
                rutactual = abre;
                contapila++;
                Console.WriteLine("existe");

                RUTACTUAL.Add(array[1]);
            }
            else
            {
                Console.WriteLine("no existe");

            }
        
        }

        private void regresar() {
            String rutacon = original;

           
            if(contapila==0){
                rutactual = original;
            
            }else{
                Stack temp = new Stack();
                int conta = 0;
               // Console.WriteLine(rutas.Count+"tama;o de pila");
                while(!(rutas.Count==0)){
                    Console.WriteLine("ENGRO EN PRIMERO");
                    if(conta==0){
                        rutas.Pop();
                    }else{

                        String tempp = (String)rutas.Pop();
                        temp.Push(tempp);
                        
                    } 
                    conta++;
                }
                Console.WriteLine(temp.Count + "tama;o de pila");
                while (!(temp.Count == 0))
                {
                    Console.WriteLine("itero????????");
                    Stack temp2 = new Stack();
                    
                        String temppc = (String)temp.Pop();
                        rutacon =rutacon+ "\\" + temppc;
                        temp2.Push(temppc);
                        rutas = (Stack)temp2.Clone();
                    
                }
                Console.WriteLine(rutactual+"ruta que tiene inicio");

                rutactual = rutacon;
                Console.WriteLine(rutacon + "ruta que tiene despues");
                contapila--;



                ArrayList tempx = new ArrayList();

                if (RUTACTUAL.Count == 1)
                {

                }
                else
                {

                    for (int i = 0; i < RUTACTUAL.Count - 1; i++)
                    {

                        Console.WriteLine(RUTACTUAL[i] + "/mete");
                        tempx.Add(RUTACTUAL[i]);

                    }
                    RUTACTUAL = tempx;
                }
            }
        
        
        }

        private void eliminarc(ArrayList array)
        {
            String eli = (String)@"" + rutactual + "\\" + array[1];
            Console.WriteLine("saca:"+eli);

            String rutaerr = (String)rutactual.Clone();
            if(Directory.Exists(eli)){
                Directory.Delete(eli, true);
                Console.WriteLine("SE elimino");





                ArrayList Narbol = new ArrayList();
                ArrayList rutaCarpeta = (ArrayList)RUTACTUAL.Clone();
                rutaCarpeta.Add(array[1]);//agrego nombre carpeta a editar


                for (int i = 0; i < arbolR.Count; i++)
                {
                    ArrayList temporal = (ArrayList)arbolR[i];

                    for (int j = 0; j < rutaCarpeta.Count; j++)
                    {


                        if (temporal.Count >= rutaCarpeta.Count)
                        {

                            if (temporal[j].Equals(rutaCarpeta[j]))
                            {

                                if (j == (rutaCarpeta.Count - 1))
                                {
                                    //ArrayList restoR = new ArrayList();
                                    //restoR = (ArrayList)RUTACTUAL.Clone();
                                    //restoR.Add(array[2]);
                                    //for (int k = j + 1; k < temporal.Count; k++)
                                    //{
                                    //    restoR.Add(temporal[k]);

                                    //}
                                    //Narbol.Add(restoR);
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                Narbol.Add(temporal);
                                //pero lo guarda
                                break;
                            }



                        }
                        else
                        {
                            Narbol.Add(temporal);
                            break;
                            //lo guarda
                        }
                    }
                }
                //fin for

                arbolR = (ArrayList)Narbol.Clone();







                String rutacon = original;

                if (contapila == 0)
                {
                    rutactual = original;

                }
                else
                {
                    Stack temp = new Stack();
                    int conta = 0;
                    // Console.WriteLine(rutas.Count+"tama;o de pila");
                    while (!(rutas.Count == 0))
                    {
                        Console.WriteLine("ENGRO EN PRIMERO");
                        if (conta == 0)
                        {
                            rutas.Pop();
                        }
                        else
                        {

                            String tempp = (String)rutas.Pop();
                            temp.Push(tempp);

                        }
                        conta++;
                    }
                    Console.WriteLine(temp.Count + "tama;o de pila");
                    while (!(temp.Count == 0))
                    {
                        Console.WriteLine("itero????????");
                        Stack temp2 = new Stack();

                        String temppc = (String)temp.Pop();
                        rutacon = rutacon + "\\" + temppc;
                        temp2.Push(temppc);
                        rutas = (Stack)temp2.Clone();

                    }
                    Console.WriteLine(rutactual + "ruta que tiene inicio");

                    rutactual = rutacon;
                    Console.WriteLine(rutacon + "ruta que tiene despues");
                    contapila--;



                    ArrayList tempx = new ArrayList();

                    if (RUTACTUAL.Count == 1)
                    {

                    }
                    else
                    {

                        for (int i = 0; i < RUTACTUAL.Count - 1; i++)
                        {

                            Console.WriteLine(RUTACTUAL[i] + "/mete");
                            tempx.Add(RUTACTUAL[i]);

                        }
                        RUTACTUAL = tempx;
                    }
                }
            }else{
                rutactual = rutaerr;
                Console.WriteLine("ERROR al elimino");
            }



        }

        //funciones para archivos----------------

        private void crearchivo(ArrayList array) {

            String crea = (String)@"" + rutactual + "\\" + array[1] + ".lfp";

            Console.WriteLine("saca:"+crea);
            if(!Directory.Exists(crea)){

                StreamWriter file = File.AppendText(crea);
                
                //sw.WriteLine(...escribir aquí el contenido del fichero...);
                file.Dispose();
                //String extension = ".lfp"; 
                
                //FileInfo f = new FileInfo(crea);
                //f.MoveTo(Path.ChangeExtension(crea, ".Jpeg"));



                ArrayList temp=null;
                temp = (ArrayList)RUTACTUAL.Clone();
                temp.Add(array[1] + ".lfp");
                arbolR.Add(temp);

                




                Console.WriteLine("SE creo archivo");
            }else{
                Console.WriteLine("ERROR al crear");
            }

     

        
        
        }

        private void abrirarchivo(ArrayList array)
        {
            //editado
            String crea = (String)@"" + rutactual + "\\" + array[1]+".lfp" ;



            Console.WriteLine("RUTA:"+crea);
            if (File.Exists(crea))
            {

                Editor edita = new Editor();
                edita.Setruta(crea);
                edita.Show();
                Console.WriteLine("SE edito archivo");
            }
            else
            {
                Console.WriteLine("ERROR al editar");
            }
        }

        private void renombrarar(ArrayList array)
        {



            // string path = @"C:\Users\KRUIZ9\Desktop\Root\" + array[1];


            String anterior = (String)@"" + rutactual + "\\" + array[1]+".lfp";
            String siguiente = (String)@"" + rutactual + "\\" + array[2] + ".lfp";


            if (File.Exists(anterior))
            {
                Console.WriteLine("existe");
                File.Move(anterior, siguiente);




                //prueba no hay garantia
                ArrayList tempor = new ArrayList();
                ArrayList temp = null;
                ArrayList temp2 = null;
                //a buscar
                temp = (ArrayList)RUTACTUAL.Clone();
                temp.Add(array[1] + ".lfp");

                
                for (int i = 0; i < arbolR.Count;i++ )
                {
                    ArrayList compa =(ArrayList)arbolR[i];
                    if ((compa.Count)==temp.Count)
                    {

                        for (int j = 0; j < temp.Count; j++)
                        {

                            if (temp[j].Equals(compa[j]))
                            {
                            }
                            else
                            {
                                tempor.Add(arbolR[i]);
                                break;
                                
                            }

                            

                        }
                    
                    }else{
                        tempor.Add(arbolR[i]);
                    }

                    if (i == (arbolR.Count - 1))
                    {
                        temp2 = (ArrayList)RUTACTUAL.Clone();
                        temp2.Add(array[2] + ".lfp");
                        tempor.Add(temp2);
                        arbolR = tempor;
                    }
                    else
                    {


                    }

                }

                //fin posible

            }
            else
            {
                Console.WriteLine("no existe");

            }

        }

        private void mover(ArrayList array) { 
        string rutsz = @"C:\Users\KRUIZ9\Desktop\";
             String crea = (String)@"" + rutactual + "\\" + array[1]+".lfp" ;//ruta original archivo 

             String destino = (String)@"" + rutsz + array[2] + "\\" + array[1] + ".lfp";

             String directos = (String)@"" + rutsz + array[2] ;

            Console.WriteLine("RUTA:"+crea);
            if (File.Exists(crea))
            {




                if (Directory.Exists(directos))
                {
                    Console.WriteLine("RUTA22:" + destino);
                    File.Move(crea, destino);

                    Console.WriteLine("SE edito archivo");









                    //inicia analisis para nueva
                    ArrayList ruta = new ArrayList();
                    String ayu = (String)array[2];
                    String concate = "";

                    for (int i = 0; i < ayu.Length; i++)
                    {
                        String cara = Convert.ToString(ayu[i]);
                        if (cara.Equals("\\"))
                        {
                            ruta.Add(concate);
                            concate = "";
                        }
                        else
                        {

                            concate = concate + cara;
                        }

                        if (i == (ayu.Length - 1))
                        {
                            if (!"".Equals(concate))
                            {
                                ruta.Add(concate);
                                concate = "";
                            }
                            else
                            {

                            }

                        }
                        else
                        {

                        }

                    }



                    ArrayList tempor = new ArrayList();
                    ArrayList temp = null;
                    ArrayList temp2 = null;
                    //a buscar
                    temp = (ArrayList)RUTACTUAL.Clone();
                    temp.Add(array[1] + ".lfp");


                    for (int i = 0; i < arbolR.Count; i++)
                    {
                        ArrayList compa = (ArrayList)arbolR[i];
                        if ((compa.Count) == temp.Count)
                        {

                            for (int j = 0; j < temp.Count; j++)
                            {

                                if (temp[j].Equals(compa[j]))
                                {
                                }
                                else
                                {
                                    tempor.Add(arbolR[i]);
                                    break;

                                }



                            }

                        }
                        else
                        {
                            tempor.Add(arbolR[i]);
                        }

                        if (i == (arbolR.Count - 1))
                        {
                            temp2 = (ArrayList)ruta.Clone();
                            temp2.Add(array[1] + ".lfp");
                            Console.WriteLine("RUTAFINAL:" + temp2);
                            tempor.Add(temp2);
                            arbolR = tempor;
                        }
                        else
                        {


                        }

                    }






                }else{
                
                }
                




            }
            else
            {
                Console.WriteLine("ERROR ruta o algo");
            }




            
        
        
        }

        private void copiar(ArrayList array)
        {
            string rutsz = @"C:\Users\KRUIZ9\Desktop\";
            String crea = (String)@"" + rutactual + "\\" + array[1] + ".lfp";//ruta original archivo 

            String destino = (String)@"" + rutsz + array[2] + "\\" + array[1]+".lfp";

            String directos = (String)@"" + rutsz + array[2] ;

            Console.WriteLine("RUTA:" + crea);
            if (File.Exists(crea))
            {
                
                

                    if (File.Exists(destino))
                    {

                        Console.WriteLine("entro para que NONONONONmodifique++++++++++++");
                }else{


                    if (Directory.Exists(directos))
                    {

                        Console.WriteLine("entro para que modifique++++++++++++");

                        ArrayList ruta = new ArrayList();
                        String ayu = (String)array[2];
                        String concate = "";

                        for (int i = 0; i <= ayu.Length - 1; i++)
                        {
                            String cara = Convert.ToString(ayu[i]);
                            if (cara.Equals("\\"))
                            {
                                ruta.Add(concate);
                                concate = "";
                            }
                            else
                            {

                                concate = concate + cara;
                            }

                            if (i == (ayu.Length - 1))
                            {
                                if (!"".Equals(concate))
                                {
                                    ruta.Add(concate);
                                    concate = "";
                                }
                                else
                                {

                                }

                            }
                            else
                            {

                            }

                        }






                        ruta.Add(array[1] + ".lfp");

                        //for (int i = 0; i <= ayu.Length - 1; i++)
                        //{

                        //    Console.WriteLine("RUTAFINAL:" + ruta[i]);
                        //}
                        arbolR.Add(ruta);
                        Console.WriteLine("RUTA22:" + destino);
                        File.Copy(crea, destino);
                        Console.WriteLine("SE edito archivo");

                    }
                    else { 
                    
                    
                    
                    
                    }



                    

                
                }


                    

            }
            else
            {
                Console.WriteLine("ERROR ruta o algo");
            }



        }

        private void eliminar(ArrayList array)
        {
            


            String eli = (String)@"" + rutactual + "\\" + array[1]+".lfp";
            Console.WriteLine("saca:" + eli);
            if (File.Exists(eli))
            {
                File.Delete(eli);
                Console.WriteLine("SE elimino");


                ArrayList tempor = new ArrayList();
                ArrayList temp = null;
                ArrayList temp2 = null;
                //a buscar
                temp = (ArrayList)RUTACTUAL.Clone();
                temp.Add(array[1] + ".lfp");


                for (int i = 0; i < arbolR.Count; i++)
                {
                    ArrayList compa = (ArrayList)arbolR[i];
                    if ((compa.Count) == temp.Count)
                    {

                        for (int j = 0; j < temp.Count; j++)
                        {

                            if (temp[j].Equals(compa[j]))
                            {
                            }
                            else
                            {
                                tempor.Add(arbolR[i]);
                                break;

                            }



                        }

                    }
                    else
                    {
                        tempor.Add(arbolR[i]);
                    }

                    if (i == (arbolR.Count - 1))
                    {
                        
                        arbolR = tempor;
                    }
                    else
                    {


                    }

                }


            }
            else
            {
                Console.WriteLine("ERROR al elimino");
            }
        }


        //archivo grande----------------------

        private void CargarRuta(ArrayList array)
        {

            String crea = (String)array[1]+".txt";
            String rus = @"C:\Users\KRUIZ9\Desktop\";
            String eli = (String)rus+array[1]+".lfp";


            Console.WriteLine("RUTA:" + eli);
            if (File.Exists(eli))
            {

                FileInfo f = new FileInfo(eli);
                String exori = f.Extension;
                f.MoveTo(Path.ChangeExtension(eli, ".txt"));

                String nue = f.FullName;


                String line; 
                //try
                //{
                    ArrayList tempo = new ArrayList();
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(nue);
                    line = sr.ReadLine();
                    String espa = line.Trim();


                    int con = 0;
                    while ((espa != null) || (con <= 5))
                    {

                        if (espa == null)
                        {
                            con++;


                        }
                        else
                        {
                            if ((String.IsNullOrEmpty(espa)) || (espa.Equals("")))
                            {
                            }
                            else
                            {
                                Console.WriteLine(espa);
                                tempo.Add(espa);
                            }

                        }

                        Console.WriteLine("ter"+con);

                        espa = sr.ReadLine();
                    }


                    sr.Close();


                    FileInfo f2 = new FileInfo(nue);
                    f2.MoveTo(Path.ChangeExtension(nue, exori));



                    Console.WriteLine("tamatempo "+tempo.Count);
                    archivoComando.Add(tempo);//mete lista comandos
                    Console.WriteLine("asdf " + array[2]);
                    nombre.Add(array[2]);


                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Exception: " + e.Message);
                //}


            }
            else
            {
                Console.WriteLine("ERROR al nose encontro");
            }





        
        
        }


        private void Ejecutar(ArrayList array)
        {
            tipoerror = 1;
            String nom = "asd";
            //cuidado 2 ejecutar
            for (int i = 0; i < nombre.Count;i++ )
            {
                if(nombre[i].Equals(array[1])){
                    nom = (String)nombre[i];
                    ArrayList tempo = (ArrayList)archivoComando[i];
                    for (int j = 0; j < tempo.Count; j++)
                    {

                        Inicio2((String)tempo[j],j);


                    }


                    

                    Console.WriteLine("Encontro++++++++++++++++++++++++++++++++++++++++++++++++");
                }else{

                    Console.WriteLine("no esta+++++++++++++++++++++++++++++++++++++++++++++++++++++");
                
                }

            }


            if (asd.Visible)
            {
                String con = "";
                for (int i = 0; i < RUTACTUAL.Count; i++)
                {
                    con = con + RUTACTUAL[i] + "/";

                }
                asd.label1.Text = con;
                asd.treeView1.Nodes.Clear();
                asd.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            NODOS1( 0)});

                asd.treeView1.ExpandAll();

            }
            else
            {
                asd = new Diagrama();
                asd.treeView1.Nodes.Clear();
                String con = "";
                for (int i = 0; i < RUTACTUAL.Count; i++)
                {
                    con = con + RUTACTUAL[i] + "/";

                }
                asd.label1.Text = con;
                asd.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            NODOS1( 0)});
                asd.treeView1.ExpandAll();
                asd.Show();


            }


            //falta otro tipo error

            html(ErrorArchivo, nom, parainforme);
            parainforme = new ArrayList();
            ErrorArchivo = new ArrayList();
            
            Informe = new ArrayList();
            tipoerror = 0;
        
        }



        //fin



        private void infor(ArrayList instruc, int fila) {


            for (int i = 0; i < instruc.Count;i++ )
            {


          
            String saca = (String)instruc[i];

            




            String temp = saca.ToLower();//ver no usar este sino saca
            ArrayList regresa = new ArrayList();
            Console.WriteLine("reservada: ------------------------------------>" + temp);

            ArrayList BITACO = new ArrayList();


            String asdf = "Reservada";
            switch (temp)
            {

                case "crearcarpeta":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    Console.WriteLine("asdffffffffffffffffffffffffffffffffffffs"+regresa.Count);
                    break;
                case "renombrarc":

                   regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre



                    break;
                case "abrirc":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);


                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    if (RUTACTUAL.Count==1)
                    {

                        BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre
                    }else{
                        BITACO.Add(RUTACTUAL[RUTACTUAL.Count - 2]);//Padre
                    }
                    


                    break;
                case "verreportes":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);


                    BITACO.Add("------");//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    //if (RUTACTUAL.Count == 1)
                    //{

                        BITACO.Add(RUTACTUAL[RUTACTUAL.Count - 1]);//Padre
                    //}
                    //else
                    //{
                    //    BITACO.Add(RUTACTUAL[RUTACTUAL.Count - 2]);//Padre
                    //}



                    break;

                case "regresar":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);


                    BITACO.Add("------");//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    break;

                case "eliminarc":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    break;

                case "creararchivo":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre


                    break;

                case "abrirarchivo":

                   regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);


                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre


                    break;

                case "renombrara":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);


                    BITACO.Add(instruc[2]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre



                    break;

                case "mover":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre


                    break;

                case "copiar":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    break;

                case "eliminara":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);


                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    break;
                case "cargar":

                   regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);
                    Console.WriteLine("PASO POR CARGAR +----------------------------------");


                    BITACO.Add(instruc[2]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    break;
                case "ejecutar":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add(instruc[1]);//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre


                    break;
                case "manualusuario":

                  regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add("-----");//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre


                    break;
                case "manualtecnico":

                   regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add("------");//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre


                    break;
                case "acercade":

                    regresa.Add(saca);
                    regresa.Add(fila);
                    regresa.Add(asdf);

                    BITACO.Add("-----");//nombre
                    BITACO.Add(instruc[0]);//Actividad
                    BITACO.Add(RUTACTUAL[RUTACTUAL.Count-1]);//Padre

                    break;
                default:
                    String tipo = "";
                    //o es nombre o ruta 
                    for (int j = 0; j < temp.Length; j++)
                    {
                        String d = Convert.ToString(temp[j]);
                        if ((d.Equals("\\")) || (d.Equals(":")))
                        {
                            tipo = "ruta";
                            break;
                        }else{

                            tipo = "nombre";
                        }


                    }




                    if (tipo.Equals("ruta"))
                    {
                        ARUTA(saca,fila);
                    }
                    else {
                        regresa.Add(saca);
                        regresa.Add(fila);
                        regresa.Add("Indentificador");

                        Console.WriteLine("PASO POR ideni +----------------------------------");

                    
                    }







                    break;
            }//fiinal  switch




            if (regresa.Count == 0)
            {

            }
            else
            {
                Console.WriteLine("//////////////////////// tamano" + regresa.Count);
                if (tipoerror == 0)
                {
                    parainforme2.Add((ArrayList)regresa.Clone());
                    BITACORA.Add(BITACO);

                    Console.WriteLine("mete -----------" + regresa.Count+"//////en "+tipoerror);
                    regresa.Clear();
                }
                else
                {
                    parainforme.Add((ArrayList)regresa.Clone());
                    BITACORA.Add(BITACO);
                    Console.WriteLine("mete -----------" + regresa.Count + "//////en " + tipoerror);
                    regresa.Clear();
                }
                ArrayList teps = (ArrayList)parainforme2[0];

                Console.WriteLine("tiene en lista//////en "+parainforme2.Count);
                Console.WriteLine("primro:" + teps[0] + "seg:" + teps[1] + "pterc;" + teps[2]);
            }




            





            }

        }


        public void ARUTA(String cadenas,int fila) {

            ArrayList regresa = new ArrayList();
            String cons = "";

            String temp = cadenas.Trim();
            

            for (int j = 0; j < temp.Length; j++)
            {

                String d = Convert.ToString(temp[j]);

                Console.WriteLine(j+"---------------------------------   analiza" + d+"******");
                Console.WriteLine("concatena:" + cons + "**");
                if ((d.Equals("\\"))){
                    if (!"".Equals(cons)) {
                        regresa.Add(cons);
                        regresa.Add(fila);
                        regresa.Add("Identificador");

                        if (tipoerror == 0){
                            parainforme2.Add(regresa);
                            regresa = new ArrayList();
                        }else{
                            parainforme.Add(regresa);
                            regresa = new ArrayList();
                        }
                        cons = "";
                    } else { 
                        
                    }

                    regresa.Add("\\");
                    regresa.Add(fila);
                    regresa.Add("Diagonal");

                  
                }
                else if ((d.Equals(":"))){
                    if (!"".Equals(cons))
                    {
                        regresa.Add(cons);
                        regresa.Add(fila);
                        regresa.Add("Identificador");
                        if (tipoerror == 0){
                            parainforme2.Add(regresa);
                            regresa = new ArrayList();
                        }else{
                            parainforme.Add(regresa);
                            regresa = new ArrayList();
                        }
                        cons = "";
                    }else{
                        
                    }

                    regresa.Add(":");
                    regresa.Add(fila);
                    regresa.Add("DosPuntos");
                }else if(d.Equals(" ")){

                    Console.WriteLine("entro espacio" + cons);
                }
                else
                {
                    Console.WriteLine("valron conca" + cons);
                    cons = cons + d;

                }

                if(j==(temp.Length-1)){
                    if (!"".Equals(cons))
                    {
                        regresa.Add(cons);
                        regresa.Add(fila);
                        regresa.Add("Identificador");
                        if (tipoerror == 0)
                        {
                            parainforme2.Add(regresa);
                            regresa = new ArrayList();
                        }
                        else
                        {
                            parainforme.Add(regresa);
                            regresa = new ArrayList();
                        }
                    }
                    else
                    {

                    }
                
                }else{
                
                }


                if(regresa.Count==0){
                
                }else{
                    if (tipoerror == 0)
                    {
                        parainforme2.Add(regresa);
                        regresa = new ArrayList();
                    }
                    else
                    {
                        parainforme.Add(regresa);
                        regresa = new ArrayList();
                    }
                }
                

            }







        
        }





        public void html(ArrayList array,String nombre,ArrayList array2)
        {


            int contador = 0;
            //--------------------------

            String ruta = @"C:\Users\KRUIZ9\Desktop\" + nombre + ".html";

            if (nombre.Equals("Salida Consola"))
            {
            
                if(Reporte.Count==0){
                    Reporte.Add(ruta);
                }else{
                
                }

            }else{
                Reporte.Add(ruta);
            }


                StreamWriter sw = new StreamWriter(ruta);




                //String estilo = " table {width: 100%;border: 1px solid #000;}th, td { width: 25%; text-align: left;vertical-align: top; border: 1px solid #000;   border-collapse: collapse;  padding: 0.3em;   caption-side: bottom;}caption {   padding: 0.3em;   color: #fff;    background: #000;}th {   background: #eee;}";


                String estilo = "table{position:absolute; border: 1px solid #000;border-collapse: collapse;font-family:century gothic';}";

                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<style type='text/css'>");
                sw.WriteLine(estilo);
                sw.WriteLine("</style>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<div id=data>");


                sw.WriteLine("<table class='egt' border=1px style='margin-left:250px;font-family:century gothic'>");
                sw.WriteLine("<tr><td colspan=5 align=center> " + nombre +  "</td></tr>");
                sw.WriteLine("<tr>");



                sw.WriteLine("<th scope='row'>#</th>");
                sw.WriteLine("<th>Char</th>");
                sw.WriteLine("<th>Fila</th>");
                sw.WriteLine("<th>Columna</th>");
                sw.WriteLine("<th>Descripcion</th>");

                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");

                //data.Add(caracter);//char
                //data.Add(fil);//fila
                //data.Add(contador);//columna



                for (int i = 0; i < array.Count; i++)
                {
                    ArrayList temp = (ArrayList)array[i];
                    Console.WriteLine(temp[0] + "------------++++++++++++++++++++");
                    

                   
                        //tipo / token/ posiccionn o id seria i

                        sw.WriteLine("<th>" + contador + "</th>");
                        sw.WriteLine("<td>" + temp[0] + "</td>");
                        sw.WriteLine("<td>" + temp[1] + "</td>");
                        sw.WriteLine("<td>" + temp[2] + "</td>");
                        sw.WriteLine("<td>" + temp[3] + "</td>");
                        sw.WriteLine("</tr>");
                        sw.WriteLine("<tr>");
                        contador++;
                        
                    
                }
                sw.WriteLine("</tr>");
                sw.WriteLine("</table>");








            //este no trae jala nada mas arry=iba
                //regresa.Add(saca);
                //regresa.Add(fila);
                //regresa.Add("Indentificador");




                sw.WriteLine("<table class='egt' border=1px style='margin-left:700px;font-family:century gothic'>");
                sw.WriteLine("<tr><td colspan=4 align=center>"+nombre+"</td></tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th scope='row'>#</th>");
                sw.WriteLine("<th>Lexema</th>");
                sw.WriteLine("<th>Fila</th>");
                sw.WriteLine("<th>Token</th>");

                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                contador = 0;

            
                //for (int i = 0; i < parainforme.Count; i++)
                for (int i = 0; i < array2.Count; i++)
                {
                   // String temp = (String)array[i];
                    //Console.WriteLine(temp[0] + "------------++++++++++++++++++++");

                    ArrayList tabla2 = (ArrayList)array2[i];

                        if(tabla2.Count==0){
                        
                        
                        }else{

                            sw.WriteLine("<td>" + i + "</td>");
                            sw.WriteLine("<td>" + tabla2[0] + "</td>");
                            sw.WriteLine("<td>" + tabla2[1] + "</td>");
                            sw.WriteLine("<td>" + tabla2[2] + "</td>");
                            sw.WriteLine("</tr>");
                            sw.WriteLine("<tr>");
                            contador++;
                        
                        }
                                
                  
                   
                }
                sw.WriteLine("</tr>");
                sw.WriteLine("</table>");















                sw.WriteLine("</div>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");


                sw.Close();





            





            //----------------------------------




        }







        public void bitacora() { 
        //paso x aquiiiiiiiii99999999 veces
        
        

            String nombre= "Root\\Bitacora";
         String ruta = @"C:\Users\KRUIZ9\Desktop\" + nombre + ".csv";

                StreamWriter sw = new StreamWriter(ruta);


                //BITACORA.Add(BITACO);
                sw.WriteLine("Nombre,Actividad,Carpeta Padre");
                for (int i = 0; i < BITACORA.Count;i++ )
                {

                    ArrayList TEMP = (ArrayList)BITACORA[i];

                    if (TEMP.Count==0){
                   
                    
                    
                    }else{
                    sw.WriteLine(TEMP[0] + "," + TEMP[1] + "," + TEMP[2]);
                    }
                        

                    


                }
                


                sw.Close();





        }



        private void reportes() {

            for (int i = 0; i < Reporte.Count; i++) {

                Process.Start((String)Reporte[i]);
            }
           
        
        
        
        }










    }




}
