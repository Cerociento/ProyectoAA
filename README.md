﻿# ProyectoAA

**~Cerociento 24/01/2017~**

*Añadida informacion en nivel
*Arreglos de script final de nivel
*Hace dias se hicieron cambios en como se representa el daño


          **Segunda subida 15:40**
 

*Arreglo daño: 
     Creado Script Alma por seguridad.
     Retocado objeto "Alma".

*Retoques en script "CargarGuardar":
       Ya guarda el tiempo de cada nivel y el tiempo total.

*Añadido boton "Reinicio" en los menús de pausa.
*Añadida representacion del ultimo nivel y el tiempo total en "Menu Inicio".



---------------------------------------------------------------------


**~Fran 22/01/2017~**

*Hecho Script que muestra estadísticas al final de cada fase. 
   Muertes y tiempo transcurrido. 

*Corregidas las cajas que se instancian en los montones de cajas.
  

---------------------------------------------------------------------

**~Fran 22/01/2017~**

*Hecho Script que muestra estadísticas al final de cada fase. Muertes y tiempo transcurrido. Corregidas las cajas que se instancian en los montones de cajas.
                         
---------------------------------------------------------------------

**~Fran 20/01/2017~**

*Pequeña corrección. Añadido un script para que los monos no atraviesen el suelo al subir en el ascensor. Ahora, el suelo aparece cuando ya han subido.
                         
---------------------------------------------------------------------


**~Cerociento 15/01/2017~**

*Diversos retoques y mejoras.

*Completada union de niveles.

*Creacion de script de guardado en cada checkpoint.
            
            **Solo para edicion (F1 Guarda, F2 Carga, F3 Borra)**
           -Guarda:
                         *Ultimo checkpoint.
                         *Veces descubierto.
                         *Ultimo nivel
                         *Coleccionables recogidos.
                         
---------------------------------------------------------------------

**~Fran 11/01/2017~** 

* En proceso de pruebas de Diseño de Sonido. Sonido añadido a:
* -Personajes (pasos y salto)
* -Enemigos (pasos y alarmas)
* -Cámaras (funcionamiento y alarmas)
* -Trampa de pinchos (Activación y muerte)
* -Lava (Muerte)
* -Botones para las puertas (Activación)
* -Cajas (Instanciado y envío de las mismas)
* -Coleccionables (Recogida)
* -Menú Principal (Música de fondo, interacción con los botones)
* -Pausa (Activación e interacción con los botones)


---------------------------------------------------------------------
**~Fran 08/01/2017~**

* En proceso de creacion de niveles.
* Nivel 3 en fase de testeo. Casi definitivo.

---------------------------------------------------------------------

**~Cerociento 07/01/2017~**

* En proceso de creacion de niveles.
* Nivel 1 completo a falta de retoques e inclusion de nuevos modelos.
* Modificada camara de seguridad.

---------------------------------------------------------------------


**~Fran 07/01/2017~**

* En proceso de creacion de niveles.
* Nivel 2 casi completado. En proceso de testeo y retoque.

---------------------------------------------------------------------


**~Cerociento 06/01/2017~**

* En proceso de creacion de niveles.
* Scripts retocados para hacerlos funcionales con los nuevos modelos.

---------------------------------------------------------------------


**~Cerociento 13/12/2016~**
 
    Retoque de tutorial.

---------------------------------------------------------------------


**~Cerociento 11/12/2016~**
  
    Añadido movimiento vertical de cámara.

----------------------------------------------------------------------------------

**~Cerociento 11/12/2016~**

  Reorganización del proyecto.

  Reestructuracion de niveles y scripts para un buen funcionamiento.

--------------------------------------------------------------------------------------

**-Fran 10/12/2016-**

* Añadidos en la carpeta 'Fran101216':

   * Coleccionables:
   
      Un script 'Coleccionables' que se añade a los objetos que van a coleccionarse. 
      Al pasar por encima de ellos o a una distancia cercana, el objeto se destruye y 
      sube en 1 el contador de coleccionables recogidos.
     
      Un script 'ColeccionablesCuenta' lleva la cuenta de los coleccionables recogidos 
      junto a una imagen y un texto. Esta cuenta es sólo visible desde el menú de pausa.
     
     
   * Campo de Visión e IA:

      El Script 'FieldOfViewRetocado' irá unido a enemigos. Funciona con un OverlapSphere. 
      Tiene una distancia y ángulo de visión retocables. Si un jugador se encuentra en éste 
      campo de visión, reaparecerá en otra posición (hay que retocar el script para que esa 
      posición sea un checkpoint. De momento, lo manda a otra posición del mapa, por probar). 
      Además,  añade 1 al contador de veces que el jugador ha perdido (información mostrada en 
      el menú de pausa). Para ser visto el jugador debe pasar un determinado tiempo en visión. 
      Si sale antes de que se cumpla ese tiempo, el tiempo se reinicia,  dándole un pequeño 
      tiempo de reacción para no ser cazado fácilmente.
     
      El Script 'FieldOfViewRetocadoEditor' sirve para poder dibujar, en escena, el área de visión.
     
      El Script 'vecesMuerto' lleva la cuenta de cuántas veces ha perdido (siendo visto o dañado) 
      el jugador. Hay que retocar algunos scripts para añadir cuentas a éste.
     
      El Script 'pruebaPatrulla' hace que los enemigos patrullen por una ruta determinada por
      nosotros. Usa un NavMesh y un NavMeshAgent.
     
     
   * Menú y Pausa:
   
      El Script 'MenuPruebas' conecta los botones del menú principal con sus correspondientes 
      escenas. También se utiliza  para los botones del menú de Pausa.

      El Script 'Pausa' pausa el juego y muestra un pequeño menú. Nos informa sobre las veces
      que hemos perdido, los coleccionables recolectados, nos da acceso al menú principal 
      o a salir del programa, y muestra qué personajes tenemos seleccionado. Hay que retocar
      los scripts de personajes para acceder a este y hacer que funcione correctamente.
      Por el momento, funciona en el nivel de prueba ('PruebaPC') cambiando uno de los 
      campos serializables del Script.


---------------------------------------------------------------------------------------------------------------------------


**~Cerociento 10/12/2016~**

* Añadidos:
     
    * Botones: 
    
           "E" para interactuar (coger/soltar o pulsar botones/tirar de palancas)
           "Espacio" para habilidad unica (Saltar o Esconderse)
           "A/W/S/D" mover al personaje.
           "Flechas izq/der" rotar cámara.

    * Coger/Soltar cajas: 
    
            Coge cajas (marrones) de un montón de cajas al pulsar "E".
            Este montón de cajas da un numero determinado de cajas y después se destruye.
            Se sueltan al pulsar "E" de nuevo.

    * Enviar cajas: 
    
            Al soltar cajas en un lunar determinado,las manda a donde quiera.             
            Creado prefab llamado "Envío de cajas", a este se le pasa las direcciones. 
            Distingue entre cajas grandes y pequeñas, así podemos decirle que y donde lo queremos. 

    * Esconderse:
    
            Se esconde si lleva una caja especial (amarilla) y pulsa espacio.
            Al pulsar,esta se destruye y el personaje se queda escondido durante x tiempo.

    * Checkpoints: 
    
            Creado prefab “checkpoint” para guardar progreso del jugador.
 
    * Daño láser y trampas (lava,ácido...):
    
            Ya no mueres. Así evitamos la perdida de ritmo excesiva.
            Al cruzar por un láser o caer en una trampa, lo devuelve al ultimo checkpoint.

    * Revisada IA no humana (cámaras,drones...):
    
            Ya no pierdes. Así evitamos la perdida de ritmo excesiva.
            Al detectarte te devuelve al ultimo checkpoint.

-------------------------------------------------------------------------------------------

**~Cerociento  9/12/2016~**

En el proyecto que he subido a github es el del otro dia,con añadidos. Hay una escena mas para pruebas.

En esta escena, hay lineas negras en el suelo. Estas lineas son paredes que se pueden levantar a antojo para probar cosas y tener un nivel de prueba "personalizable".

Tambien hay varias carpetas nuevas. Una llamada Prueba  y otra Pruebas 2. En la primera estan las cosas de la primera vez, en la segunda estan las cosas nuevas o las cosas antiguas retocadas y funcionales.

