# ProyectoAA


-Fran 10/12/2016-

Añadidos en la carpeta 'Fran101216':

    Coleccionables:
      Un script 'Coleccionables' que se añade a los objetos que van a coleccionarse. Al pasar por encima de ellos
      o a una distancia cercana, el objeto se destruye y sube en 1 el contador de coleccionables recogidos.
     
      Un script 'ColeccionablesCuenta' lleva la cuenta de los coleccionables recogidos junto a una imagen y un texto.
      Esta cuenta es sólo visible desde el menú de pausa.
     
     
    Campo de Visión e IA:
      El Script 'FieldOfViewRetocado' irá unido a enemigos. Funciona con un OverlapSphere. Tiene una distancia y ángulo de
      visión retocables. Si un jugador se encuentra en éste campo de visión, reaparecerá en otra posición (hay que retocar
      el script para que esa posición sea un checkpoint. De momento, lo manda a otra posición del mapa, por probar). Además, 
      añade 1 al contador de veces que el jugador ha perdido (información mostrada en el menú de pausa). Para ser visto
      el jugador debe pasar un determinado tiempo en visión. Si sale antes de que se cumpla ese tiempo, el tiempo se reinicia, 
      dándole un pequeño tiempo de reacción para no ser cazado fácilmente.
     
      El Script 'FieldOfViewRetocadoEditor' sirve para poder dibujar, en escena, el área de visión.
     
      El Script 'vecesMuerto' lleva la cuenta de cuántas veces ha perdido (siendo visto o dañado) el jugador.
      Hay que retocar algunos scripts para añadir cuentas a éste.
     
      El Script 'pruebaPatrulla' hace que los enemigos patrullen por una ruta determinada por nosotros. Usa un
      NavMesh y un NavMeshAgent.
     
     
    Menú y Pausa:
      El Script 'MenuPruebas' conecta los botones del menú principal con sus correspondientes escenas. También se utiliza 
      para los botones del menú de Pausa.

      El Script 'Pausa' pausa el juego y muestra un pequeño menú. Nos informa sobre las veces que hemos perdido, los
      coleccionables recolectados, nos da acceso al menú principal o a salir del programa, y muestra qué personajes 
      tenemos seleccionado. Hay que retocar los scripts de personajes para acceder a este y hacer que funcione correctamente.
      Por el momento, funciona en el nivel de prueba ('PruebaPC') cambiando uno de los campos serializables del Script.


---------------------------------------------------------------------------------------------------------------------------


~Cerociento 10/12/2016~

Añadidos:
     
     Botones: 
           "E" para interactuar (coger/soltar o pulsar botones/tirar de palancas)
           "Espacio" para habilidad unica (Saltar o Esconderse)
           "A/W/S/D" mover al personaje.
           "Flechas izq/der" rotar cámara.

     Coger/Soltar cajas: 
            Coge cajas (marrones) de un montón de cajas al pulsar "E".
            Este montón de cajas da un numero determinado de cajas y después se destruye.
            Se sueltan al pulsar "E" de nuevo.

     Enviar cajas: 
            Al soltar cajas en un lunar determinado,las manda a donde quiera.
             
            Creado prefab llamado "Envío de cajas", a este se le pasa las direcciones. 
            Distingue entre cajas grandes y pequeñas, así podemos decirle que y donde lo queremos. 

     Esconderse:
            Se esconde si lleva una caja especial (amarilla) y pulsa espacio.
            Al pulsar,esta se destruye y el personaje se queda escondido durante x tiempo.

     Checkpoints: 
            Creado prefab “checkpoint” para guardar progreso del jugador.
 
     Daño láser y trampas (lava,ácido...):
            Ya no mueres. Así evitamos la perdida de ritmo excesiva.
            Al cruzar por un láser o caer en una trampa, lo devuelve al ultimo checkpoint.

     Revisada IA no humana (cámaras,drones...):
            Ya no pierdes. Así evitamos la perdida de ritmo excesiva.
            Al detectarte te devuelve al ultimo checkpoint.

-------------------------------------------------------------------------------------------

~Cerociento  9/12/2016~

En el proyecto que he subido a github es el del otro dia,con añadidos. Hay una escena mas para pruebas.

En esta escena, hay lineas negras en el suelo. Estas lineas son paredes que se pueden levantar a antojo para probar cosas y tener un nivel de prueba "personalizable".

Tambien hay varias carpetas nuevas. Una llamada Prueba  y otra Pruebas 2. En la primera estan las cosas de la primera vez, en la segunda estan las cosas nuevas o las cosas antiguas retocadas y funcionales.

