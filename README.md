# Consola_9


El siguiente programa tiene como finalidad el simular la creacion de un arbol de directorios por medio de consola, con ella se podra crear , modificar y eliminar estos ,tambien se puede visualizar lo que es el arbol de directorios generado desde la consola , tambien se pueden ver los archivos creados con extension lfp donde este se podra editar 

### 1.) Inicio

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG1.png" width="600px">

Al iniciar se encontrara con una ventana que tiene esta forma, en esta ventana se mostrara y se escribirán los comandos a ejecutar, algunos de los comandos que se pueden ejecutar son, abrirc, crearcarpeta, creararchivo, eliminara etc., los comandos se escribirán en la parte donde se ve la última línea Root/KGERB>


### 2.) Listado de comandos
<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG1.png" width="600px">


La consola cuenta con los siguientes comandos:

##### CrearCarpeta nombre
Este comando creara una nueva carpeta.


##### RenombrarC nomAnterior nomNuevo
Este comando renombrara una carpeta

##### AbrirC nombre
Este comando abre una carpeta creada

##### Regresar
Regresa a la carpeta padre, si está en la raíz no regresa se queda en la misma

##### EliminarC nombre
Se encarga de eliminar una carpeta y su contenido.

##### CrearArchivo nombre
Este comando creara un nuevo archivo con extensión lfp

##### AbrirArchivo nombre
Este comando abre el archivo lfp guardado en alguna carpeta de root.

##### RenombrarA nomAnterior nomNuevo
Este comando sirve para renombrar un archivo generado

##### Mover archivo "ruta"
Se encarga de mover un archivo a la ruta que se le ingresa

##### Copiar archivo "ruta
Se encarga de generar un archivo, en la ruta especificada

##### Eliminar nombre
Este comando elimina un archivo de los directorios

##### Cargar "ruta" nombre
Se encarga de guardar una lista de comandos en memoria

##### Ejecutar nombre
Ejecuta la lista de comandos que se había guardado en memoria.

##### Manual Usuario
Abre el presente manual

##### ManualTecnico
Abre el manual técnico de este programa

##### AcercaDe
Muestra la información del programador

##### VerReportes
Muestra los archivos HTML generados.


### 3.) Arbol de directorios
<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG2.png" width="600px">

En esta ventana se mostrara el árbol de directorios, se podrá ver cómo están conformadas las carpetas, cuando se abre una carpeta esta automáticamente se desplegara si tuviese algún contenido, todas las carpeta tiene su origen en la carpeta Root 

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG3.png" width="300px">

Aquí se muestra como la carpeta carpeta_1 está alojada dentro de la carpeta Root

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG4.png" width="300px">

De igual manera cuando se cree un nuevo archivo, dependiendo la ubicación en la que este, creara el directorio, se mostrara como un icono blanco como se muestra en la figura de arriba

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG5.png" width="200px">

Cuando se abre una carpeta automáticamente se mostrara en la parte inferior la posición actual en la que estamos como se muestra en la imagen


<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG6.png" width="600px">

Cuando un comando no se reconozca, se mostrara el tipo de error que encontró y se le mostrara en consola, otra funcionalidad de la consola es que al tocar la tecla subir o bajar automáticamente mostrara la lista de comandos que se han escrito con anterioridad

### 4.) Editor de Texto

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG7.png" width="600px">

En esta ventana se mostrara el contenido del archivo lfp que se abra, se podrá editar y agregar y eliminar cualquier contenido del texto que se desee, al finalizar los cambios se procede a dar

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG8.png" width="300px">

click en guardar:
y el texto se guardara satisfactoriamente en la ruta original


### 5.) Bitacora

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG9.png" width="300px">

La bitácora es un archivo .csv que guarda el identificador de la carpeta archivo u objeto que se esté tratando, en actividad se guardara el comando que se ejecutó, y por último se guardara la carpeta padre en donde está alojado actualmente, cuando se ejecuta el comando

<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG10.png" width="300px">

### 6.) Archivo de Salida
<img src="https://raw.githubusercontent.com/gkruiz/Consola_9/refs/heads/main/Imagenes/IMG11.png" width="600px">

Este archivo HTML se mostrara en el navegador , en donde se podrá apreciar la lista de lexemas y su respectivo token, así también la lista de errores léxicos durante la ejecución, cuando un carácter no se reconozca se guardara en errores , su descripción será desconocido








