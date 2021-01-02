# Project Ogmia
##### *Kilonova Studios -- Diciembre de 2020*

*Para una mejor visualización del Documento de Diseño de Juego, por favor lea su versión PDF, adjuntada en la raíz del proyecto*

Índice
======

[1. Introducción 5](#introducción)

[1.1. Elevator Pitch. 5](#elevator-pitch.)

[1.2. Concepto de juego. 5](#concepto-de-juego.)

[2. Género 5](#género)

[3. Plataformas 5](#plataformas)

[4. Alcance del proyecto 6](#alcance-del-proyecto)

[5. Experiencia de juego objetivo 6](#experiencia-de-juego-objetivo)

[6. Narrativa y personajes 6](#narrativa-y-personajes)

[6.1. Sinopsis 6](#sinopsis)

[6.2. Trasfondo general 7](#trasfondo-general)

[6.3. Personajes 7](#personajes)

[6.4. Historia y trama del juego 8](#historia-y-trama-del-juego)

[6.4.1. Tutorial / Introducción 8](#tutorial-introducción)

[6.4.2. Desarrollo de la trama durante el juego
8](#desarrollo-de-la-trama-durante-el-juego)

[6.4.3. Desenlace de la historia / Finales del juego
9](#desenlace-de-la-historia-finales-del-juego)

[7. Interfaz 10](#interfaz)

[7.1. Splash Screen 10](#splash-screen)

[7.2. Menú principal (Pantalla de Título)
11](#menú-principal-pantalla-de-título)

[7.3. Menú de opciones 12](#menú-de-opciones)

[7.4. Menú de selección de dificultad
13](#menú-de-selección-de-dificultad)

[7.5. In Game HUD 14](#in-game-hud)

[7.6. Menú de pausa 16](#menú-de-pausa)

[7.7. Pantalla de Game Over 17](#pantalla-de-game-over)

[7.8. Pantalla de créditos 18](#pantalla-de-créditos)

[7.9. Pantalla final 19](#pantalla-final)

[8. Controles 20](#controles)

[8.1. Controles en PC 20](#controles-en-pc)

[8.1.1. Mando y ratón 20](#mando-y-ratón)

[8.1.2. Mando 20](#mando)

[8.2. Controles en móvil 20](#controles-en-móvil)

[9. Estilo visual 21](#estilo-visual)

[9.1. Modelos y animaciones de personajes
21](#modelos-y-animaciones-de-personajes)

[9.2. Modelado de escenarios y props
21](#modelado-de-escenarios-y-props)

[9.3. Assets propios 22](#assets-propios)

[10. Mecánicas 22](#mecánicas)

[10.1. Mecánicas núcleo 22](#mecánicas-núcleo)

[10.1.1. Recolección de trozos de amuleto
22](#recolección-de-trozos-de-amuleto)

[10.1.2. Movimiento y exploración 23](#movimiento-y-exploración)

[10.1.3. Combate 23](#combate)

[10.1.4. Obstáculos y trampas 23](#obstáculos-y-trampas)

[10.2. Mecánicas auxiliares 24](#mecánicas-auxiliares)

[10.2.1. Desarrollo de personaje 24](#desarrollo-de-personaje)

[10.2.2. Interacción con el entorno / exploración narrativa
24](#interacción-con-el-entorno-exploración-narrativa)

[10.2.3. Obtención de nuevas armas 25](#obtención-de-nuevas-armas)

[10.2.4. Guardado de partida 25](#guardado-de-partida)

[10.2.5. Mecánica de muerte y pérdida de progreso
25](#mecánica-de-muerte-y-pérdida-de-progreso)

[11. Niveles 26](#niveles)

[11.1. Macroestructura de niveles 26](#macroestructura-de-niveles)

[11.2. Estructura individual de niveles
26](#estructura-individual-de-niveles)

[11.2.1. Tutorial 26](#tutorial-1)

[11.2.2. Sueño de Medianoche 28](#sueño-de-medianoche)

[11.2.3. Estructura de las mazmorras 30](#estructura-de-las-mazmorras)

[12. Enemigos 34](#enemigos)

[12.1. Enemigos 'melee' 34](#enemigos-melee)

[12.1.1. Esqueleto maltrecho 34](#esqueleto-maltrecho)

[12.1.2. Esqueleto recluta 34](#esqueleto-recluta)

[12.1.3. Goblin común 35](#goblin-común)

[12.1.4. Goblin soldado 35](#goblin-soldado)

[12.1.5. Goblin pícaro 35](#goblin-pícaro)

[12.1.6. Esqueleto soldado 36](#esqueleto-soldado)

[12.1.7. Esqueleto caballero 36](#esqueleto-caballero)

[12.2. Enemigos a distancia 36](#enemigos-a-distancia)

[12.2.1. Esqueleto cobarde 36](#esqueleto-cobarde)

[12.2.2. Goblin chamán 37](#goblin-chamán)

[12.2.3. Goblin bruja 37](#goblin-bruja)

[12.2.4. Espíritu vengativo 37](#espíritu-vengativo)

[12.3. Enemigos especiales / bosses 38](#enemigos-especiales-bosses)

[12.3.1. Jefe de la primera mazmorra 38](#jefe-de-la-primera-mazmorra)

[12.3.2. Jefe de la segunda mazmorra 38](#jefe-de-la-segunda-mazmorra)

[12.3.3. Jefe de la tercera mazmorra 38](#jefe-de-la-tercera-mazmorra)

[13. Flujo de juego 39](#flujo-de-juego)

[14. Hoja de ruta del desarrollo 41](#hoja-de-ruta-del-desarrollo)

[14.1. PRIMER HITO: Prototipo Funcional (21 Diciembre)
41](#primer-hito-prototipo-funcional-21-diciembre)

[14.2. SEGUNDO HITO: Alpha (30 Diciembre)
41](#segundo-hito-alpha-30-diciembre)

[14.3. TERCER HITO: Beta (6 Enero) 41](#tercer-hito-beta-6-enero)

[14.4. CUARTO HITO: Playtesting & prelanzamiento (10-12 Enero)
41](#cuarto-hito-playtesting-prelanzamiento-10-12-enero)

[14.5. QUINTO HITO: Lanzamiento (11-13 Enero)
41](#quinto-hito-lanzamiento-11-13-enero)

[14.1. HITO FINAL: Presentación (20 Enero)
41](#hito-final-presentación-20-enero)

[15. Modelo de negocio a largo plazo
41](#modelo-de-negocio-a-largo-plazo)

[15.1. Fidelización 41](#fidelización)

[15.2. Freemium 42](#freemium)

[16. Canvas 42](#canvas)

[17. Monetización 43](#monetización)

[17.1. Microtransacciones 43](#microtransacciones)

[17.2. DLCs / expansiones 43](#dlcs-expansiones)

[17.3. Publicidad integrada 43](#publicidad-integrada)

[18. Marketing 44](#marketing)

[18.1. Lanzamientos audiovisuales 44](#lanzamientos-audiovisuales)

[18.2. Blogs y RRSS especializadas 44](#blogs-y-rrss-especializadas)

[18.3. Autopromoción 44](#autopromoción)

[18.4. Word of mouth 44](#word-of-mouth)

[19. Referencias y anexos 45](#referencias-y-anexos)

Introducción
============

Éste es el documento de diseño de juego (GDD por sus siglas inglesas)
para el juego desarrollado por *Kilonova Studios* para el proyecto de
juego web Unity3D de la asignatura de 'Juegos para Web y Redes Sociales'
del cuarto año de la carrera de Diseño y Desarrollo de Videojuegos,
identificado como 'Proyecto Tartarus'. A continuación, se describirán
todos los aspectos del juego, desde su concepto hasta sus detalles de
implementación. Téngase en mente que este es un documento en constante
evolución, y, por lo tanto, [todo lo aquí escrito está sujeto a
cambios]{.ul}:

 {#section .list-paragraph}

Elevator Pitch.
---------------

*\[Moonraider\]* es un dungeon crawler con un combate hack n' slash
compacto, una estética 3D low poly, una narrativa envolvente y un fuerte
componente de exploración y descubrimiento donde el jugador deberá
pelear para encontrar las piezas de un amuleto que le permitirán romper
un sello antiguo y encontrar a la entidad que todo lo conoce.

Concepto de juego.
------------------

*\[Moonraider\]* es un dungeon crawler donde prima la exploración y el
combate. El objetivo del jugador es explorar el mazmorras y encontrar en
ellas las piezas que completarán el amuleto que porta el jugador. Podrá
conseguirlas principalmente por exploración y por combate. Cada nivel
contendrá dos piezas de dicho amuleto, obteniéndose una por combate y
otra por exploración en cada mazmorra; tras encontrar ambas, el jugador
podrá descender al siguiente nivel. Con dos piezas por nivel y tres
niveles, obtenemos un total de seis piezas a recolectar para superar el
juego.

Por otro lado, el punto central de la experiencia y desarrollo de juego
será el espacio conocido como \[Sueño de Medianoche\], un nexo desde
donde el jugador puede partir a las distintas mazmorras y al que siempre
volverá. Una vez haya reunido todas las piezas y entre una vez más en
comunión con la luna en el Sueño de Medianoche, podrá encontrarse con la
hechicera cuyo cabello y ojos son del color de la manzana... y así
alcanzar el final del juego.

Sería posible y recomendable introducir una toma de decisión secreta
justo en el momento anterior al encuentro con la hechicera, o durante
éste, que permita tener dos finales, sin que quede claro cuál de ellos
es el final 'bueno' o el final 'canon'

Género
======

*\[Moonraider\]* es un dungeon crawler con tintes 'souls-like' en su
combate, estética low poly y ambientación de fantasía oscura/mitológica.

Plataformas
===========

*\[Moonraider\]* es un juego web, disponible para jugar en:

-   Chrome.

-   Firefox.

-   Móvil (Android).

Alcance del proyecto
====================

El alcance de este juego es, primordialmente, el del contexto de la
asignatura 'Juegos para Web y Redes Sociales', pero no está limitado
éste. Nuestro objetivo como equipo es crear el mejor juego posible; un
producto de calidad que llame la atención del jurado profesional y nos
permita empezar a darnos a conocer como profesionales en la industria.
Queremos que nuestro producto hable por nosotros mismos en el mercado.

En lo referente al beneficio económico, no esperamos percibir
remuneración alguna por este proyecto, más allá de alguna donación
voluntaria de los jugadores que así lo deseen. Por otro lado, sí que
estamos dispuestos a invertir dinero en el desarrollo, comprando assets,
invirtiendo en publicidad, o invirtiendo dinero en la marca del estudio
(camisetas, tarjetas de negocios, etc).

Experiencia de juego objetivo
=============================

La experiencia de juego objetivo es la siguiente:

*El jugador se enfrentará a solas a un entorno tan misterioso como
hostil, progresando en una búsqueda infatigable del conocimiento que le
acabará llevando a la lucidez y la locura al mismo tiempo... pagando un
precio muy alto sin saberlo.*

La experiencia de combate intrépido y la exploración de un mundo
intrigante absorberán al jugador en esta experiencia de juego a través
de la consolidada fórmula del dungeon crawler que establecieron juegos
como *'The Binding of Isaac'*, pintándolo con tintes de la saga souls en
el combate y exploración del lore del mundo. De esta manera, los temas
principales que explora este juego son:

*"Conocer la verdad absoluta conlleva un precio"*

*"Saberlo todo equivale a no ser nada"*

A través de esta narrativa, se espera dejar al jugador el siguiente
mensaje final:

*"Hallar la verdad y el conocimiento no tiene sentido si uno se olvida
de todo lo demás"*

Narrativa y personajes
======================

Sinopsis
--------

*'En una tierra lejana, un viajero errante encuentra la llave del
conocimiento. Con ella, podrá encontrar a la hechicera cuyo cabello y
ojos son del color de la manzana y obtener de ella todo el conocimiento
de este mundo. Sin embargo, esta llave no está completa, y sólo
adentrándose en el \[Abismo\] podrá encontrar las piezas que le faltan
para completarla y romper el sello de la hechicera.*

*Encandilado por la idea del conocimiento absoluto, el viajero deja
atrás todo lo que conoce y se adentra en el \[Abismo\] en busca de
respuestas'.*

Trasfondo general
-----------------

Los acontecimientos de \[Moonraider\] toman lugar en un mundo de
fantasía oscura sin nombre, donde todo lo que importa son los
acontecimientos que le suceden al protagonista: un viajero harapiento
que viaja por el mundo en busca de conocimiento un día se encuentra un
amuleto especial en el interior de unas ruinas; en cuanto lo ve, nota su
llamada, y el amuleto le atrae como el fuego a la polilla. El aventurero
se cuelga la reliquia al cuello, y a partir de ese momento pasa a ser
"El buscador de conocimiento".

El resto de la historia se desarrolla entorno al "Sueño de Medianoche",
un espacio entre la mente y la materia que representa el viaje de un
individuo (el protagonista) hacia el conocimiento absoluto,
evolucionando a la vez que se exploran mazmorras (cada una con
fragmentos de historias relacionadas con el tema del juego, generando un
'lore emergente') y se obtienen esquirlas del amuleto.

Las mazmorras exploradas por el jugador en su búsqueda de las esquirlas
serán ruinas abandonadas de estética medievo-fantástica infestadas de
trampas y monstruos hostiles (orcos, esqueletos vivientes, fantasmas,
etc). Su conexión con el resto del mundo no será relevante, pero sí lo
serán para el trasfondo y establecimiento del tema del juego la
exploración y las pequeñas historias que contendrá cada mazmorra.

Personajes
----------

A continuación, se describen los personajes del juego:

-   **'El viajero':**

El protagonista de la historia, y el avatar del jugador dentro de ésta.
No se sabe mucho de su pasado; de hecho, lo único que se sabe de él es
que es un viajero que ha vagado por el mundo en busca de conocimiento.
Una vez encuentra el Amuleto de Ogmia, su sueño se encuentra dentro del
alcance de su mano, pero en el proceso es posible que descubra que el
conocimiento absoluto no es lo que él realmente pensaba que era.

-   **'La hechicera de cabello y ojos rojos como la manzana':**

La hechicera conocida como "Ogmia", que hace un contrato con el viajero
en el momento en que toca el Amuleto de Ogmia. Su figura es también
misteriosa, y sólo se sabe de ella que es la encarnación del
'conocimiento absoluto', lo que le da un estatus omnipotente. Sus ojos y
su cabello son rojizos como los de una manzana, y siempre viste un
vestido ceremonial de color negro.

Al final de la historia se podrá descubrir que en realidad, "Ogmia" es
un ente superior que representa el conocimiento colectivo de toda la
humanidad... pero la pobre chica pelirroja que lo posee no es más que
una prisionera de su propio cuerpo, al que hace mucho tiempo ya se le
negó la libertad del individualismo humano.

-   **Personajes enemigos**

Los habitantes de las mazmorras que explorará el jugador son criaturas
hostiles que matarán a todo el que invada los territorios del abismo.
Representan los obstáculos en el camino a la obtención del conocimiento,
y entre éstos hay orcos, esqueletos, fantasmas... etc.

Historia y trama del juego
--------------------------

A continuación, se describirá la trama completa del juego siguiendo la
estructura clásica de planteamiento, nudo y desenlace, partiendo de la
información presentada en el apartado de 'trasfondo general':

### Tutorial / Introducción

Como ya se estableció en la sección de 'trasfondo general', la historia
comienza cuando un harapiento viajero encuentra el \[Amuleto de
Ogmia[^1]\] y a través de éste el protagonista hace un juramento tácito
para buscar el conocimiento y completar el amuleto.

En ese mismo momento, el amuleto le transporta a un espacio entre la
mente y la materia conocido como "El Sueño de la Medianoche", donde la
'hechicera de color y ojos rojos como la manzana' aparece ante él; ella
misma se identifica a sí misma como "el conocimiento del mundo entero",
como si se tratase de un ente colectivo superior a la comprensión de lo
que un solo ser humano puede llegar a entender. La mujer tienta al
protagonista con la idea de perseguir el conocimiento que ella posee, y
le dice que, si desea obtener la respuesta a todas las preguntas, debe
buscar y pelear por obtener el conocimiento absoluto completando el
amuleto fracturado que lleva colgado al cuello.

El protagonista, encandilado por la idea de conocer todo aquello que hay
en el mundo, acepta el contrato. A partir de ese momento, se le
encomienda la misión de 'descender' a los abismos para buscar el
conocimiento, que se canaliza en las esquirlas que se necesitan para
completar el \[Amuleto de Ogmia\].

### Desarrollo de la trama durante el juego

Mediante conexiones esotéricas entre el Sueño de Medianoche y los
"abismos", el protagonista viaja hasta mazmorras infestadas de peligros
que debe superar para encontrar las esquirlas del conocimiento. Durante
su periplo por estas mazmorras, encontrará retazos de historias de otras
personas que vivieron y murieron allí, todas relacionadas de alguna
manera con la historia del conocimiento humano y el tema del juego.

Cada vez que el protagonista encuentra una esquirla, ésta se integra en
el Amuleto de Ogmia, completándolo poco a poco; de hecho, con cada nueva
esquirla devuelta al amuleto, el Sueño de Medianoche crece y evoluciona,
a la vez que el propio protagonista, que se hace más fuerte y obtiene
nuevas habilidades con cada nueva esquirla encontrada.

La evolución del Sueño de Medianoche (que podría introducir nuevos
personajes dentro de sí para aportar a este desarrollo) vendrá medida
por las fases de la luna del sueño, que comenzará en luna nueva al
principio del juego y se completará con la luna llena al encontrar todas
las esquirlas. Esta metáfora del conocimiento y la aproximación a lo
divino, junto a las pequeñas historias y conocimiento encontrados en las
mazmorras del abismo, irán creando una historia "emergente" que hablará
sobre cómo la búsqueda del conocimiento es un enigma tan antiguo como el
propio mundo, y sobre todo, un enigma que un ser humano nunca será capaz
de solucionar por sí sólo... sólo algo que supera la individualidad
puede sostener la omnipresencia necesaria para sostener todo el
conocimiento del mundo.

### Desenlace de la historia / Finales del juego

Una vez el jugador encuentre la última esquirla del conocimiento, el
Amuleto de Ogmia estará completo, de manera que cuando regrese por
última vez al Sueño de Medianoche se enfrentará al desenlace final del
juego:

En el Sueño de Medianoche completo, el Amuleto de Ogmia ascenderá al
cielo, y desde la luna llena roja y resplandeciente descenderá una vez
más la hechicera de cabello y ojos rojos como la manzana, que esta vez
se presentará como "Ogmia". Entonces, la hechicera le ofrece por fin el
conocimiento absoluto al protagonista, invitándole a "dejar atrás las
cadenas del individuo para convertirse en el receptáculo del saber",
dejando entrever que, si el protagonista acepta la oferta, se unirá al
conocimiento colectivo del mundo, perdiendo su "yo" en la espesura de la
omnisciencia.

En este momento final, frente a la luna llena y la hechicera "Ogmia", el
jugador/protagonista se enfrenta a la decisión final:

*"¿Abandonarás tu identidad como individuo para obtener el conocimiento
absoluto?"*

-   Si el jugador escoge que **sí**, entonces se verá en una cutscene
    como el protagonista asciende hasta donde está la hechicera, que le
    abraza con una expresión de alivio... para cerrar los ojos y dejar
    que su cuerpo inerte caiga al vacío. Entonces, el protagonista se
    quita la venda, y en sus ojos aparece el mismo resplandor rojizo que
    tenían los de la hechicera, dando a tender que su voluntad ya no
    existe, y ahora él es el siguiente "Ogmia", el recipiente divino del
    conocimiento absoluto.

-   Si el jugador escoge que **no**, entonces el rostro de la hechicera
    se torna en ira, gritándole al protagonista que "debe cumplir con el
    contrato para liberarla de su carga" de una vez por todas, dando a
    entender que la hechicera no soporta más, como individuo, sostener
    el conocimiento absoluto del mundo.

Es en este escenario donde tiene sentido introducir una batalla de
'final boss', si el tiempo de desarrollo lo permite, donde la hechicera
intenta 'obligar' al protagonista a quitarle la vida, transmitiendo la
"maldición" del conocimiento a un nuevo receptáculo. Si el jugador
pierde, se puede recargar el último checkpoint, pero si gana, se alcanza
la cutscene de este final alternativo:

Al ganar la batalla, el cuerpo inerte de la hechicera cae al suelo con
una sonrisa de alivio en su rostro. El Amuleto de Ogmia se destruye por
completo y el conocimiento 'se pierde' en la luz de la luna de
medianoche. Con la ruptura del contrato, el Sueño de Medianoche se
desmorona mientras el protagonista, aún con la venda puesta, 'sigue su
camino' en la vida como individuo, rechazando la idea de abandonar su
identidad, y haciendo reflexiones finales acerca de cómo la verdadera
libertad no es la omnipotencia, sino la elección que hace cada ser
humano al elegir su sueño, o dicho de otra manera... la libertad de cada
ser humano para escoger sus propias cadenas.

Finalmente, tras la última cutscene de cada final respectivo, se
muestran los créditos y el informe de batalla final, si se desea
incorporar uno (poco prioritario). Sería oportuno dar una ilustración
representativa del final escogido tras los créditos.

No se han dado etiquetas de "final bueno" o "final malo" en este caso,
porque se desea dar cierta ambigüedad a los finales, de manera que ambos
sean válidos, y cuál sea el bueno y cuál sea el malo resida en la
reflexión que haga el jugador respecto a la historia.

Interfaz
========

![](media/image1.png){width="7.7243055555555555in"
height="2.1166666666666667in"}En esta sección se presentarán, pantalla
por pantalla, los esquemas de diseño y funcionalidad de las distintas
interfaces de \[Moonraider\]. Como base para guiar toda la experiencia
de usuario, se usará el siguiente **diagrama de flujo:**

**Se recomienda consultar su versión online en este
[link.](https://viewer.diagrams.net/?highlight=0000ff&edit=_blank&layers=1&nav=1#G1k21dp6bS7LtlYZgREibkSZg23XaQODSn)**

Splash Screen
-------------

![](media/image2.jpeg){width="4.743164916885389in" height="2.65in"}

La 'splash screen' introducirá el logo del estudio al jugador, antes de
iniciar el juego. Se aprovechará esta pantalla, además, como pantalla de
carga si esto fuera necesario.

Una vez presentado el nombre del estudio, y cualquier otra información
que se quiera dar de forma inmediata al jugador, se transita de forma
automática a la pantalla de menú principal.

Menú principal (Pantalla de Título)
-----------------------------------

![](media/image3.jpeg){width="4.939285870516185in" height="2.775in"}

La pantalla de menú principal de \[Moonraider\]. Su objetivo no sólo es
dar los accesos al juego, al menú de opciones o a los créditos, ya que
más importante todavía es que **cause una buena primera impresión en el
jugador**, ya que esta pantalla de título es lo primero que va a ver un
jugador nuevo. Por lo tanto, esta pantalla de menú debe servir como
**gancho** para la experiencia de juego.

Para conseguirlo, se plantea crear un menú con fondo en tres dimensiones
que muestre a la hechicera de cabello y ojos rojos sentada en su trono,
o en alguna posición similar, con la luna llena de fondo. Esto introduce
aspectos importantes de la narrativa y genera intriga en el jugador, ya
que se trataría de una iconografía bastante fuerte.

Alternativamente, se puede ofrecer un fondo de menú más o menos
discreto, pero que refleje el punto del juego donde se encuentra el
jugador. Esto no sirve tanto como gancho, sino como 'customización' de
la experiencia del jugador. Un buen ejemplo de esta práctica es el
famoso videojuego 'Half-life 2'

Otras alternativas más sencillas que estas primeras incluyen utilizar el
Amuleto de Ogmia como fondo, o alguna composición donde se muestre a la
hechicera, pero de forma más sencilla.

En términos funcionales, el menú principal tiene los siguientes botones:

-   **CONTINUE:** esta opción aparece **sólo** si el juego detecta una
    partida guardada en el terminal. Si el jugador escoge esta opción,
    el juego cargará su último punto de guardado.

-   **NEW GAME:** la opción de empezar una nueva partida, borrando la
    que estuviera guardada en el proceso (se debería avisar de esto al
    usuario). Si existe una selección de dificultad, esta opción lleva a
    ella antes de empezar la partida, en caso contrario, comienza
    directamente la partida desde el tutorial.

-   **SETTINGS:** esta opción lleva al usuario al menú de opciones, para
    personalizar el juego a su gusto antes de comenzar a jugar.

-   **CREDITS:** esta opción lleva al jugador a la pantalla de créditos,
    en caso de que quiera conocer al equipo detrás del desarrollo del
    juego.

![](media/image4.png){width="5.20625in" height="2.925in"}Menú de opciones
-------------------------------------------------------------------------

La pantalla de opciones de \[Moonraider\], accesible tanto desde el menú
principal, como desde el menú de pausa, en medio de la experiencia de
juego. En esta pantalla el jugador puede personalizar a su gusto
distintas opciones de juego, entre ellas:

-   **VOLUMEN DE BGM**

Volumen relacionado a la banda sonora. Se implementará con un slider.

-   **VOLUMEN DE SFX**

Volumen relacionado a los efectos de sonido. Se implementará con un
slider.

-   **OPCIONES GRÁFICAS**

Si el tiempo de desarrollo permitiera habilitar una configuración de
opciones gráficas, como control de sombras, iluminación, o efectos
post-procesado, sería accesible desde el menú de opciones.

-   **CONFIGURACIÓN DE CONTROLES**

Si el tiempo de desarrollo lo permite, sería positivo para la
experiencia de usuario habilitar una zona donde se puedan cambiar los
atajos de los controles al gusto del usuario. Si no se pudiera hacer
esto, se recomienda encarecidamente ofrecer una imagen ilustrativa de
los controles en su lugar.

![](media/image4.png){width="5.20625in" height="2.925in"}Menú de selección de dificultad
----------------------------------------------------------------------------------------

Si se incluyesen distintos modos de dificultad en el juego (una opción
muy atractiva, para apelar a distintos tipos de jugadores), sería
necesario implementar una pantalla de selección de modo de dificultad
que preceda al inicio de una partida. En esta pantalla, tendríamos:

-   **Las opciones de dificultad disponibles.** El jugador puede
    seleccionar cualquiera de ellas para obtener más información acerca
    de cómo de fácil o difícil es el modo de juego en cuestión, ya que
    la selección escogida no se hará definitiva hasta que el jugador no
    presiones el botón 'start'.

-   **Botón 'Start'.** Este botón representa la confirmación de que el
    jugador está satisfecho con el modo de dificultad seleccionado.
    Cuando el jugador presione este botón, el modo de dificultad se
    'cerrará' para el resto de la partida, y esta comenzará desde el
    tutorial.

In Game HUD
-----------

![](media/image5.png){width="4.8211515748031495in" height="2.725in"}

Durante las sesiones de juego, la interfaz de juego representará en todo
momento la siguiente información, en el caso de PC:

1.  **AMULETO:** en todo momento, el 'Amuleto de Ogmia' será visible en
    la esquina superior izquierda de la pantalla. Este elemento
    informará al jugador en todo momento de cuál es su objetivo en el
    juego, y cuánto le queda para conseguirlo.

2.  **CONTADOR DE FRAGMENTOS:** las mecánicas de exploración implican
    reunir fragmentos de 'esquirla de amuleto' en cada mazmorra para
    juntarlos y crear una esquirla completa cuando se tengan todos. Para
    ayudar a establecer este objetivo y dar un feedback visual del
    progreso de la tarea, se habilitará un contador en la pantalla que
    indique al jugador cuántos fragmentos ha encontrado y cuántos más
    debe encontrar.

3.  **BARRA DE VIDA:** esta barra representa la cantidad de vida total
    del jugador, y cuánta le queda respecto a eso. Dará un feedback
    directo sobre si el jugador recibe daño, y en todo momento el
    jugador podrá visualizar fácilmente esta información.

4.  **MINIMAPA:** el minimapa es el encargado de guiar al jugador dentro
    del espacio de juego. Representa un mapa simplificado del espacio de
    la mazmorra y al jugador dentro de él. Adicionalmente, si se
    interacciona con el minimapa, debería ser posible **ampliarlo** a
    tamaño completo para que el jugador pueda observar todo su entorno.

Por otro lado, es necesario introducir también el HUD ingame en la
versión de **móvil**, ya que los controles táctiles integrados en la
pantalla añaden algunos elementos:

![](media/image6.png){width="5.204486001749781in"
height="2.941666666666667in"}

En la versión móvil del juego, se introducen los siguientes elementos
nuevos en el HUD:

1.  **JOYSTICK VIRTUAL:** se introducirá un joystick virtual en la
    pantalla para habilitar la locomoción y el movimiento por el
    escenario para los jugadores.

2.  **PAD DE BOTONES:** simulando los controles de mando, se añadirán
    cuatro botones a la esquina inferior derecha de la pantalla. Cada
    uno tendrá una acción distinta relacionada, e incluso
    comportamientos distintos en función de cuánto tiempo son apretados
    (por ejemplo, mantener el botón de ataque presionado produce un
    ataque circular, en lugar de uno simple)

3.  **BOTÓN DE PAUSA:** dadas las características del hardware en
    móviles, no se puede habilitar un botón físico como atajo al menú de
    pausa. En su lugar, existirá un botón táctil en la pantalla que dará
    acceso a este menú en su lugar.

Menú de pausa
-------------

![](media/image7.png){width="5.087612642169729in"
height="2.8583333333333334in"}

El menú de pausa cumplirá con la función de dar la opción al jugador de
parar la sesión de juego, pudiendo volver a ella cuando lo desee y
retomarla desde donde la dejó. Visualmente, este menú se superpondrá a
una versión oscurecida del gameplay del juego en el momento en que se
pausó, haciendo aparecer sobre éste el título del juego y las siguientes
opciones:

1.  **RESUME:** botón de reanudar la partida. Al presionarlo, el jugador
    sale del menú principal y vuelve al juego.

2.  **SETTINGS:** da acceso al menú de opciones, que se superpondrá con
    el juego de la misma manera que lo hace esta pantalla. Es posible
    que algunas opciones gráficas, si las hay, no estén disponibles para
    cambiar durante la partida.

3.  **RETURN TO MAIN MENU:** presionar este botón llevará al jugador de
    vuelta al menú principal, interrumpiendo la sesión de juego y
    perdiendo el progreso no guardado en el proceso. Por este motivo, es
    **altamente aconsejable** pedir confirmación al jugador antes de
    realizar esta acción.

Pantalla de Game Over
---------------------

![](media/image8.png){width="5.183333333333334in"
height="2.91211176727909in"}

La pantalla de 'game over' es una parte muy importante de la experiencia
de usuario, ya que su objetivo no sólo es comunicarle al jugador que ha
'perdido', sino también presentarle las opciones que tiene y motivarle
para seguir jugando e 'intentarlo otra vez'.

La propuesta visual para esta pantalla consiste en, sin cortar en ningún
momento la cámara desde el gameplay, acercar la cámara al jugador
'inerte' tras morir en el propio espacio de juego. Si es posible, se
aplicará mediante efectos de post-procesado un efecto 'viñeta' y un
cambio de los colores de la escena para transmitir una sensación de
derrota. En ese momento, aparecerá un letrero de 'Game Over' o 'You
died', y las siguientes opciones para el jugador:

-   **TRY AGAIN:** si el jugador escoge esta opción, se cargará el
    último punto de guardado (que normalmente siempre será dentro del
    Sueño de Medianoche), y el jugador seguirá jugando a partir de ese
    punto 'para intentarlo otra vez'.

-   **SURRENDER:** representa la opción de 'abandonar' el juego y volver
    al menú principal. Se le da una connotación negativa utilizando la
    expresión 'rendirse' para incentivar al jugador a escoger la opción
    de 'intentarlo otra vez' para seguir 'luchando'.

Pantalla de créditos
--------------------

![](media/image9.jpeg){width="5.891666666666667in"
height="3.316666666666667in"}

La pantalla de créditos tiene el objetivo de presentar al equipo de
desarrollo y las tareas que ha desempeñado cada uno de sus componentes
dentro del desarrollo. Esta pantalla será accesible de dos maneras
distintas:

-   **Por elección del jugador a través del menú principal,** caso en el
    que el jugador tendrá el control sobre cuándo salir de la pantalla
    de créditos, y podrá desplazarse por ella a libertad (en caso de que
    los créditos no quepan dentro de una pantalla, se habilitará un
    slider para poder representar la información de manera correcta en
    distintos apartados).

-   **Como conclusión a la experiencia tras alcanzar el final.** En este
    caso, los créditos aparecerán tras alcanzar el final del juego,
    mostrándose de manera automática. Si se presentan de forma estática,
    permanecerán un tiempo en pantalla y luego desparecerán. Por otro
    lado, si se trata de una 'cortina' de créditos, estos se irán
    deslizando por la pantalla hasta que se hayan mostrado todos.
    Después de esto, y sin que el jugador tenga que hacer nada, se
    transitará a la 'Pantalla Final'.

Pantalla final
--------------

La 'pantalla final' no es otra cosa más que una conclusión ilustrativa a
todo el recorrido que ha hecho el jugador para alcanzar el final del
juego. Visualmente, debe mostrarse una escena que case con el final
obtenido por el jugador, y de un lazo satisfactorio a la historia y a la
experiencia de juego.

En cuanto a la información representada en pantalla, a parte de la
ilustración, se podría incluir aquí un 'informe de batalla' aportando
datos sobre los logros del jugador e incluso una puntuación relacionada,
pero dada la naturaleza de \[Moonrider\], eso no aportaría nada a la
experiencia de juego, ya que no se ha diseñado entorno a una
'puntuación' que superar, sino entorno a una experiencia jugable que se
disfruta por sí sola, y se revisita para obtener el otro final, o por el
simple hecho de seguir jugando.

Por otro lado, si se llegasen a implementar distintos modos de
dificultad, sí que sería beneficioso indicar en qué modo de dificultad
se ha superado el juego en esta pantalla, para 'premiar' o 'endecorar' a
los jugadores que superen el juego en las máximas dificultades, para
darles una prueba de que lo han conseguido.

La única opción disponible en pantalla para el jugador será la de
'volver al menú principal', pulsando un botón. El jugador escogerá
cuando regresar al menú principal, y a partir de ahí, su partida
terminará.

Si el jugador cargase su último punto de guardado desde el menú
principal, este le llevaría al último punto de guardado antes del final
del juego, no a la 'pantalla final' directamente.

Controles
=========

> Los controles, según plataforma, son los siguientes:

Controles en PC
---------------

Los jugadores de PC podrán jugar utilizando uno de dos periféricos:
mando y ratón o mando. A continuación, se describe el mapa de controles
básico para cada uno de ellos:

### Mando y ratón

-   **Movimiento:** Teclas WASD o teclas direccionales.

-   **Ataque:** Click izquierdo

-   **Bloqueo:** Click derecho

-   **Voltereta o dash:** Shift

-   **Interacción:** Tecla F

-   **Ataque giratorio:** Mantener pulsado y soltar click izquierdo

-   **Menú de pausa:** Tecla Escape

-   **Abrir minimapa:** Tecla M

-   **Pasar diálogo:** Click en botón 'continuar'

-   **Navegación por menús:** Ratón o teclas direccionales/WASD + Enter

### Mando

-   **Movimiento:** Joystick izquierdo

-   **Ataque:** Botón oeste

-   **Bloqueo:** Botón este

-   **Voltereta o dash:** Gatillo derecho o gatillo izquierdo

-   **Interacción:** Botón sur

-   **Ataque giratorio:** Mantener pulsado botón oeste.

-   **Menú de pausa:** Botón START

-   **Abrir minimapa:** Hombro izquierdo/derecho

-   **Pasar diálogo:** Botón sur

-   **Navegación por menús:** Joystick izquierdo + botón este
    (cancelar) + botón sur (confirmar)

Dadas las facilidades que da Unity para remapear los controles, debería
darse la opción al jugador de hacerlo

Controles en móvil
------------------

Para los controles de móvil se habilitarán unos controles similares a
mando, pero virtualmente representados en la pantalla del móvil:

-   **Movimiento:** Joystick virtual

-   **Ataque:** Botón sur

-   **Bloqueo:** Botón este

-   **Voltereta o dash:** Botón oeste

-   **Interacción:** Reemplaza al botón sur cuando se pueda interactuar
    con algo.

-   **Ataque giratorio:** Botón norte

-   **Menú de pausa:** Tocar botón PAUSA

-   **Abrir minimapa:** Tocar el minimapa

-   **Pasar diálogo:** Tocar botón 'continuar'

-   **Navegación por menús:** Desplazamiento e interacción táctil.

Estilo visual
=============

Dado que el videojuego en desarrollo está enfocado a plataformas web,
dentro de las que se incluye la plataforma móvil, se debe hacer una
propuesta visual que consuma pocos recursos, pero siga siendo atractiva
y explote adecuadamente las tres dimensiones. El equipo consideró la
mejor opción utilizar gráficos de estilo **'low poly'** en este caso:
modelos de bajo poligonaje y texturizado muy sencillo, que simplifican
la optimización de recursos y pueden seguir siendo atractivos gracias a
su sencillez y uso de los colores.

Modelos y animaciones de personajes
-----------------------------------

![](media/image10.jpeg){width="0.6510367454068241in"
height="2.033333333333333in"}![](media/image11.jpeg){width="0.7395833333333334in"
height="1.9416666666666667in"}Los modelos seguirán la misma estética
**'low poly'**, siendo la mayoría de ellos humanoides para simplificar
el proceso de animación, ya que cumpliendo este requisito se pueden
compartir animaciones fácilmente entre ellos, y más importante todavía,
se pueden aplicar animaciones de **mixamo**[^2], lo que acelerará
enormemente el proceso de animación de los personajes y ahorrará mucho
tiempo de desarrollo.

Muchos de los modelos utilizados en el desarrollo pertenecen al pack de
assets ['Dungeon Pack', de Synty
Studios](https://assetstore.unity.com/packages/3d/environments/dungeons/polygon-dungeons-pack-102677),
que el equipo adquirió precisamente para el desarrollo de este juego.

Modelado de escenarios y props
------------------------------

![screenshot](media/image12.jpeg){width="5.330555555555556in"
height="2.9993777340332457in"}

Los escenarios y props, en la misma línea que todo lo demás, también
serán de estética 'low poly'. Entre los assets más importantes para el
modelado de escenarios se encuentran el ['Dungeon Pack', de Synty
Studios](https://assetstore.unity.com/packages/3d/environments/dungeons/polygon-dungeons-pack-102677),
o el ['Low Poly Ultimate Pack', de
polyperfect](https://assetstore.unity.com/packages/3d/props/low-poly-ultimate-pack-54733).

Utilizando estos packs, el equipo podrá generar niveles personalizados a
las necesidades del proyecto utilizando componentes modulares que se
adaptarán muy bien a la generación de niveles procedimentales.

Assets propios
--------------

El equipo desarrollará todos los assets que sean necesarios para el
proyecto y no se encuentren entre los packs de assets externos
disponibles. Asimismo, el modelado de los personajes centrales de la
narrativa, [el viajero protagonista y la hechicera]{.ul}, serán
diseñados y modelados desde cero por el equipo, junto a otros props
importantes como [el Amuleto de Ogmia]{.ul}, props importantes para el
Sueño de Medianoche o elementos visuales del HUD.

Mecánicas
=========

Esta sección se dividirá en dos subsecciones en base a la importancia de
las mecánicas que la componen en relación al diseño del juego, es decir,
en mecánicas núcleo y en mecánicas auxiliares:

Mecánicas núcleo
----------------

Las mecánicas núcleo son aquellas que definen el centro de la
experiencia de juego, y como tales, son las que más atención deben
recibir en el desarrollo:

### Recolección de trozos de amuleto

La mecánica sobre la que se sostienen todas las demás, y la que define
el progreso y compleción del juego, sin duda es la recolección de trozos
del amuleto. Existe un número limitado de éstos, y en cada mazmorra sólo
se podrán encontrar dos trozos de amuleto:

-   **Trozo de amuleto ganado por combate:** en cada mazmorra existirá
    un jefe o enemigo que derrotar en uno de sus extremos más alejados.
    Al derrotarlo, el jugador obtendrá un trozo del amuleto.

-   **Trozo de amuleto juntado de fragmentos más pequeños:** para
    obtener este trozo de amuleto, el jugador tendrá que buscar pequeños
    **fragmentos** en las mazmorras. Al juntar todos los fragmentos de
    trozo de amuleto que haya en una mazmorra, éstos se unirán y el
    jugador obtendrá un trozo completo de amuleto.

![](media/image13.png){width="6.677777777777778in"
height="0.6770833333333334in"}

El proceso de obtención de trozos de amuleto define el ciclo de juego,
la progresión del personaje, las mecánicas, y los objetivos del juego,
además de ser el motor de la narrativa. Es la mecánica núcleo sobre la
que se construyen las demás, y por ello es la más importante: motivo por
el que se desea incluir el amuleto como elemento inmutable y siempre
visible dentro del juego, para que el jugador conozca en todo momento
cuánto progreso ha hecho y cuánto progreso le falta para llegar al final
del juego, completando el amuleto.

![](media/image14.png){width="1.6333333333333333in"
height="1.6333333333333333in"}

Para conseguir esto, se incluirá una representación 3D detallada del
'Amuleto de Ogmia' en la interfaz de juego, en la esquina superior
izquierda, y cada vez que el jugador encuentre una nueva 'esquirla' del
amuleto, ésta se incrustará de manera visual en éste, evolucionando así
de manera visual a lo largo del juego. Se adjuntan esquemas visuales del
amuleto y su progreso, así como del aspecto que tendría el amuleto,
representando también la luna dentro de sus formas y colores, como
metáfora del conocimiento.

### Movimiento y exploración

La mayor parte del tiempo, el jugador la empleará navegando los niveles
y explorándolos en busca de fragmentos o trozos del amuleto. Por eso, la
kinestética del movimiento y la exploración deben estar muy cuidados. La
cámara debe mostrar cómodamente el escenario, pero no mostrar demasiado,
para mantener la comodidad, pero al mismo tiempo conservar el misterio
de 'qué habrá detrás de la siguiente puerta'.

La exploración es uno de los dos pilares base de la experiencia, además
de un paso obligado para encontrar los fragmentos del amuleto repartidos
en las mazmorras.

### Combate

El combate, junto a la exploración, es el otro pilar del gameplay del
juego. Se trata de un sistema de combate 'hack n slash' básico, donde lo
que prima es el combate cuerpo a cuerpo, que es la única opción del
jugador. Se busca que tenga una sensación intrépida, pero que su
dificultad sea comedida. Un punto medio entre el combate estratégico de
'Dark Souls'[^3] y el combate a veces frenético de 'Hyper Light
Drifter'[^4].

El sistema de combate estará guiado por la **barra de vida** del
jugador, que será visible en todo momento en la pantalla. Dada la
propuesta simple de juego, no es necesario implementar sistemas de
estamina: solamente cooldowns para las distintas acciones.

El flujo central del combate consistirá en [esquivar]{.ul} los ataques
enemigos mediante [dashes]{.ul} o esquives y utilizar éstos para
posicionarse adecuadamente en puntos donde el jugador pueda atacar a los
enemigos para desestabilizarlos mediante un [combo básico de tres
ataques]{.ul}. Si además se añadieran [habilidades especiales]{.ul} a la
fórmula (sólo si los tiempos de desarrollo lo permiten), el uso correcto
de éstas en el momento indicado debería ser capaz de darle la vuelta a
un combate complicado, en especial en las etapas finales del juego,
donde no será tan fácil asestar golpes a los enemigos.

Pelear será un requisito y un evento muy común dentro del juego, ya que
en cualquier sala donde aparezcan enemigos, las puertas se cerrarán,
obligando al jugador a pelear para avanzar. De la misma manera, no se
podrán obtener los trozos de amuleto guardados por jefes si no se les
derrota con antelación.

### Obstáculos y trampas

Unido a la exploración y el combate, los obstáculos, trampas y peligros
del entorno serán la tercera pata que complemente a la exploración y el
combate. Repartidas por las mazmorras habrá numerosas trampas (en
especial en las últimas etapas del juego), que el jugador tendrá que
sortear con éxito para poder avanzar. No se busca una experiencia de
plataformeo punitiva donde el jugador muere instantáneamente, sino una
donde no puede darse el lujo de bajar la guardia, pese a que caer en una
o dos trampas no vaya a drenar toda su barra de vida.

Además, en muchas ocasiones, los fragmentos de trozo de amuleto estarán
resguardados en salas con distintas trampas que dificulten su acceso, y
ya que se ha prescindido de una mecánica de salto, la gran mayoría del
peso de plataformeo recaerá en esquivar las trampas haciendo un uso
adecuado del dash, en conjunción con un buen timing.

Mecánicas auxiliares
--------------------

Como su nombre indica, las mecánicas auxiliares existen para potenciar
las mecánicas núcleo, dándole más usos a éstas o creando un efecto que
ayude a crear la experiencia de juego deseada.

### Desarrollo de personaje

Ya que las dos patas de la experiencia de juego son la exploración y el
combate, es requisito para mantener la atención del jugador y darle una
sensación de progreso que el gameplay evolucione de alguna manera a lo
largo del recorrido del juego. Para cubrir esta necesidad y unirla al
mismo tiempo a la narrativa que gira entorno a 'obtener conocimiento',
se ha decidido que el personaje jugador se desarrollará siempre que
obtenga una nueva esquirla de conocimiento, de la siguiente manera:

##### Tutorial

**Encontrar núcleo de amuleto:** Desbloquea el tercer golpe o 'finisher'
del combo básico. Este último ataque es más fuerte y tiene la capacidad
de romper la defensa del enemigo.

##### Nivel 1

**Esquirla de reconocimiento:** Otorga un dash mejorado. Este nuevo dash
alcanza más lejos, otorga más tiempo de invulnerabilidad y es más rápido
que el original.

**Esquirla de combate:** Aumento de vida y estadísticas (+ daño).

##### Nivel 2

**Esquirla de reconocimiento:** Otorga la posibilidad de ejecutar un
'ataque giratorio' cuando se mantenga pulsado el botón de ataque
habitual. Este ataque es más lento, pero hace bastante daño y cubre un
área de 360º entorno al jugador

**Esquirla de combate:** Aumento de vida y estadísticas (+ daño).

##### Nivel 3

**Esquirla de reconocimiento:** Otorga la habilidad de bloquear ataques
durante un corto periodo de tiempo. Para ejecutar esta habilidad se
habilitará un nuevo atajo de controles.

**Esquirla de reconocimiento (ALTERNATIVA):** Otorga la habilidad de
'estocar' cuando se combinan el dash y el ataque (pulsando ambos al
mismo tiempo). Este ataque cubre más distancia que el dash, puede
stunnear al enemigo y además hace bastante daño.

**Esquirla de combate:** Aumento de vida y estadísticas (+ daño)

### Interacción con el entorno / exploración narrativa

Una parte importante de la experiencia de juego será la narrativa
emergente que se generará al explorar las mazmorras. Para fomentar esto
y explorar más el tema del juego, se incluirán distintos objetos
repartidos en las mazmorras con los que el jugador podrá interactuar.
Estos objetos pueden tomar cualquier forma (se destacará su
'interactibilidad' utilizando algún efecto visual llamativo), y al
interactuar con ellos, al jugador se le presentará un diálogo de texto
que aporte una pequeña pieza de 'lore'.

Esto creará pequeñas historias que los jugadores podrán enlazar al
entorno, creando esa narrativa emergente, e incluso uniendo pequeños
retazos separados para formar una imagen mayor del mundo del juego,
siempre entorno a la temática que se quiere explotar.

### Obtención de nuevas armas

Esta mecánica es **opcional**, **poco prioritaria** y **probablemente no
se implemente**. Para fomentar la 'randomización' del juego y dar un
aliciente mayor para derrotar enemigos más allá de la obligación de
hacerlo, se podría plantear un sistema de armas intercambiables para el
jugador, de manera que pueda encontrar y equipar nuevas armas más
fuertes a lo largo de su aventura.

El funcionamiento sería el siguiente: los enemigos tienen una
probabilidad muy baja de soltar su arma al morir. Si la sueltan, el
jugador podrá acercarse a ella, y en el momento en que esté cerca, un
**widget** de información aparecerá en pantalla indicándole las
estadísticas de daño tanto de su arma actual, como de la que hay
arrojada en el suelo.

Si el jugador decide que quiere cambiar de arma, solo tendrá que
interaccionar con el arma tirada en el suelo de la misma manera que se
interactúa con cualquier objeto en el juego, y de esa manera se equipará
con la nueva arma, dejando la vieja tirada en el suelo.

Este sencillo sistema evade al equipo de desarrollo de la necesidad de
implementar un sistema de inventario, y a la vez da un gran aliciente al
jugador para combatir y explorar más cada mazmorra, pudiéndose llegar a
dar el caso donde el jugador 'farmea' las mejores armas del juego. Si se
desease, se podrían incluso ligar habilidades a las armas más poderosas,
de manera que éstas otorgasen nuevos ataques al jugador, o distintos
combos.

### Guardado de partida

Cada vez que el jugador acceda al 'Sueño de Medianoche', la partida se
guardará automáticamente junto a todo su progreso. El juego le informará
de ello.

### Mecánica de muerte y pérdida de progreso

La muerte en \[Moonraider\] no significa el final completo de la
experiencia, con lo que es importante definir cuál es el castigo para el
jugador que muera en su exploración de las mazmorras (no se tiene en
cuenta el caso de morir en el Sueño de Medianoche, ya que no es
posible):

La única condición para que el jugador 'muera', es que su barra de vida
llegue a 0 puntos, sea por daño recibido de trampas o enemigos.

Si el jugador muere, se cargará su último punto de partida, que
idealmente se corresponderá con su última visita al Sueño de Medianoche.
Todo el progreso que hiciera entre ese momento y el momento de su
muerte, se pierde.

Esto introduce una mecánica de 'gestión de riesgo', ya que si un jugador
sale de la mazmorra para guardar su progreso, sabe que al volver tendrá
que volver a enfrentarse a los enemigos... pero al mismo tiempo, si se
arriesga a pasar mucho tiempo sin volver al espacio seguro del sueño,
mayor será la pérdida si muere.

Niveles
=======

En esta sección se describirá todo lo relacionado con los niveles del
juego: cuántos hay, qué estructura tienen y qué elementos contienen

Macroestructura de niveles
--------------------------

![](media/image15.png){width="2.3361111111111112in"
height="2.433333333333333in"}La estructura de juego de \[Moonraider\]
gira entorno al espacio de juego central, el Sueño de Medianoche. Desde
este punto central, que sirve como nexo, punto de guardado y centro de
la narrativa al mismo tiempo, el jugador se desplaza a las mazmorras
para encontrar en ellas las 'esquirlas del conocimiento', objetivo
principal del juego, pudiendo ir y volver al Sueño de Medianoche a
través de los puntos de salida dentro de la mazmorra, manteniéndose
guardado el progreso realizado en las mazmorras, aunque se salga de
éstas.

Por otro lado, no todas las mazmorras son accesibles desde el principio.
El juego tiene una estructura lineal de avance, de manera que [hasta que
no se hayan recolectado las dos esquirlas de amuleto que hay encada
mazmorra]{.ul}, el paso a la siguiente no se abrirá dentro del Sueño de
Medianoche.

Este ciclo continúa hasta que el jugador haya recolectado todas las
esquirlas de conocimiento de todos los niveles, momento en el que el
Sueño de Medianoche se 'completa', y el jugador alcanza el final del
juego la próxima vez que regrese a él.

Estructura individual de niveles
--------------------------------

En esta sección, se describirá mediante esquemas la estructura del
tutorial y la estructura del Sueño de Medianoche, así como la estructura
común del resto de niveles:

### Tutorial

![](media/image16.png){width="2.5881780402449692in"
height="3.308333333333333in"}El tutorial es el primer lugar con el que
interacciona el jugador nada más empezar la partida. Tiene múltiples
propósitos: introducir la narrativa, presentar todas las mecánicas, ser
representativo de la experiencia de juego, y servir como gancho que
llame la atención a los jugadores para seguir jugando. Con el objetivo
de cumplir todos estos requisitos, el tutorial se plantea como un nivel
inmutable (es decir, un nivel que no es procedimental).

El esquema propuesto para este nivel tutorial se encuentra a la derecha.
Para diferenciar de alguna manera este nivel de los demás, se propone
que éste se desarrolle al semi-descubierto, mientras que las mazmorras
que conformarán los niveles del juego serán entornos completamente
interiores. Siguiendo el recorrido del esquema, el jugador se contraría
con:

1.  **ENTRADA:** lo primero que ve el jugador al iniciar una nueva
    partida será una cutscene introductoria, que ocurrirá en este
    espacio. Una vez acabada, se introduce al jugador a los controles de
    movimiento mediante diálogo.

2.  **TRAMPAS:** este espacio estará dedicado a mostrar al jugador qué
    son las trampas y cómo evitarlas, introduciéndole convenientemente a
    la mecánica de voltereta/dash con antelación. Las trampas serán
    fácilmente reconocibles.

3.  **ENEMIGOS:** en este punto, el jugador se encontrará con los
    primeros enemigos del juego. Se le introducirá aquí al sistema de
    combate: cómo atacar, esquivar y derrotar al enemigo sin que
    reduzcan su vida a cero. Los enemigos serán muy fáciles de derrotar
    en este primer combate. A partir de este punto, los caminos se
    bifurcarán, con lo que se introducirá también el acto de
    **explorar.**

Los espacios vacíos entre este punto y los puntos 5 y 6 determinan
espacios de transición, con pocos o ningún enemigo/trampas.

4.  **LORE:** convenientemente, en la sala posterior a la de los
    enemigos, habrá una pequeña 'sala de lore' con un objeto
    interaccionable (diario al lado de un cadáver, por ejemplo). Al
    interactuar con él, el jugador aprenderá a interactuar con objetos
    del entorno, y además recibirá información acerca de los objetivos
    del nivel, ya que ese objeto revelará que en esas ruinas hay un
    amuleto muy poderoso, pero que es necesario encontrar su núcleo, que
    también se encuentra en algún punto de las ruinas, para activarlo.

5.  **NÚCLEO DEL AMULETO:** en esta sala se pretende introducir al
    jugador a dos conceptos: la recolección de 'esquirlas de amuleto' y
    al sistema de progreso.

Se trata de una sala en cuyo centro se encuentra el 'núcleo' del Amuleto
de Ogmia. Este 'núcleo' es especial porque sin él no se puede activar el
amuleto en el punto 6. Esto se ha hecho así para forzar al jugador a
aprender todas las mecánicas antes de acabar el tutorial, pero por todo
lo demás, este 'núcleo' es una réplica exacta de una esquirla de amuleto
de exploración, y su objetivo es introducir la mecánica detrás de éstas.

Por otro lado, cuando se obtenga dicho 'núcleo', el jugador recibirá su
primera **mejora de progreso** del juego, introduciendo un tercer golpe
en su combo básico de ataque. De esta manera, se pretende que el jugador
relacione inmediatamente encontrar esquirlas de amuleto con obtener
mejoras para su personaje.

De hecho, una vez el jugador obtenga el núcleo, y de manera similar a
otras salas con fragmentos de amuleto, se cerrarán las puertas y el
jugador se verá obligado a luchar, poniendo directamente en práctica sus
mejoras.

6.  **AMULETO:** Este punto representa el final del tutorial, así como
    la introducción al Sueño de Medianoche y los objetivos globales del
    juego.

> En esta sala se encuentra el Amuleto de Ogmia, pero para que el
> jugador pueda 'activarlo' y dar paso a la cutscene de final de
> tutorial, será necesario encontrar el 'núcleo' de amuleto en el punto
> 5. Si el jugador llega aquí antes, se le deberá dar una pista cuando
> interactúe con el amuleto 'vacío'.
>
> Una vez interactúe con el amuleto teniendo en su poder el 'núcleo' del
> Amuleto de Ogmia, éste se activará y esto dará lugar a una cutscene
> donde la hechicera se pondrá en contacto con el protagonista por
> primera vez, cerrando el contrato por el que el protagonista se
> convierte en un "buscador del conocimiento".
>
> Una vez cerrado dicho contrato, se llevará al jugador por primera vez
> al Sueño de Medianoche, donde a través de un número de diálogos se le
> introducirá a la estructura global y objetivos del juego, así como al
> sistema de guardado de partida, que funciona guardando la partida cada
> vez que el jugador entra al 'Sueño de Medianoche'.
>
> Una vez acabado todo este proceso, el jugador obtendrá libertad de
> acción y comenzará su recorrido principal para superar \[Moonraider\].

### ![](media/image17.png){width="2.7in" height="3.0277777777777777in"}Sueño de Medianoche

El Sueño de Medianoche, tal y como se especifica en el apartado de
"Narrativa y personajes", es un espacio entre la mente y la materia,
representación física del contrato entre el protagonista y "Ogmia" y
nexo de la historia y experiencia de juego. Además, es el único punto
del juego donde es posible guardar la partida, el escenario final y el
lugar al que el jugador siempre volverá tras pelear en las mazmorras.
Como tal, demanda especial atención su estructura y aspecto, que se
plantea en un esquema adjunto a la izquierda, y se explica a
continuación:

El Sueño de Medianoche es un espacio rodeado de la "nada", donde las
estructuras parecieran flotar en un espacio onírico iluminado por la luz
de una luna rojiza en un cielo nublado de la medianoche. En su
**centro** se encuentra una [estatua, trono o tributo
representativo]{.ul} de "Ogmia" sobre una placeta que idealmente tendrá
grabada las mismas formas que el Amuleto de Ogmia sobre ella. En algún
punto de este espacio central, existirá un punto iluminado que servirá
como punto de guardado, guardándose la partida al interactuar con él
(sea sentándose en el trono, rezando de rodillas a una estatua, etc).
Este punto también es el "punto de spawn" donde el jugador reaparece al
volver al Sueño de Medianoche.

Idealmente, siempre que se entre al Sueño de Medianoche se mostrará una
breve cutscene donde la cámara primero apunta a la luna, mostrando su
etapa actual, y luego al protagonista rezando de rodillas y levantándose
en silencio, momento en el que la cámara vuelve a su posición estándar y
se devuelve el control al jugador.

Desde este punto central partirán tres caminos que llevarán a las
respectivas salidas a las mazmorras o niveles, representadas como
portales, arcos o puertas (se da libertad creativa al modelador de
escenarios). Las que no estén disponibles todavía se mostrarán cerradas
(o sin portal), mientras que las que sean accesibles en ese momento
estarán abiertas (o con portal).

Por otro lado, si los tiempos de desarrollo lo permiten, sería muy
conveniente para el desarrollo de la narrativa, y la sensación de
progreso del jugador, que el Sueño de Medianoche vaya creciendo y
evolucionado a medida que el jugador encuentra **esquirlas del
amuleto**. Al mismo tiempo, la **luna cambiará desde luna nueva a luna
llena** a través de tres etapas de desarrollo globales.

La consiguiente evolución pretende crear una metáfora entre el
"crecimiento" de la luna desde luna nueva a luna llena, acompasándolo
con la exploración del personaje de la hechicera, dividiéndolo en tres
etapas: infancia, adultez y vejez/muerte. En cada etapa de la luna, el
sueño crece y va dando espacio a recuerdos de la hechicera, que una vez
fue humana y tuvo una vida como todos los demás, pero poco a poco fue
cayendo en la "maldición del conocimiento", perdiendo últimamente su
identidad como individuo frente a la totalidad del conocimiento
universal: saberlo todo no es compatible con ser "uno" mismo, ya que lo
que nos da la individualidad es la diferencia con el resto del mundo y
las cosas que desconocemos o ignoramos:

![](media/image18.jpeg){width="2.892361111111111in"
height="1.2590277777777779in"}

De izquierda a derecha: luna en primera etapa, en segunda etapa, en
tercera etapa y en etapa final (luna llena) cuando se complete el
amuleto.

1.  **PRIMERA ETAPA -- INFANCIA:** Desarrollo dado durante la primera
    mazmorra. Durante este período la luna evolucionará desde luna nueva
    a primera etapa. A su vez, la "Zona 1" (consultar esquema de la
    página anterior) se desbloqueará conforme se hallen las esquirlas de
    la primera mazmorra (una mitad con la esquirla de combate, y la otra
    con la esquirla de exploración). Los recuerdos de Ogmia
    desbloqueados en esta primera etapa hablarán acerca de la vida
    temprana de la hechicera: infancia, inocencia, ignorancia...

> Alternativamente, siguiendo el modelo de cuatro etapas de vida de Carl
> Gustav Jung, esta primera etapa se corresponde con "el atleta", con lo
> que se podría hacer especial hincapié en una obsesión por lo físico y
> lo superficial, dejando atrás la inocencia.

2.  **SEGUNDA ETAPA --** **ADULTEZ:** Desarrollo dado durante la segunda
    mazmorra. La luna pasa a segunda etapa, y se desbloquea la "Zona 2",
    de la misma forma que la anterior. Los recuerdos y lugares de esta
    zona estarán relacionados con la adultez: descubrimiento del mundo,
    del cuerpo, del placer, ambición por conseguir objetivos, miedo por
    perder lo que se ha conseguido...

> Alternativamente, en el modelo de Jung, esta etapa se correspondería
> con "la etapa del guerrero", donde nos obsesionamos con alcanzar
> nuestras propias metas, obtener éxito, explorar nuevos escenarios y
> subir escalafones, obtener nuevas sensaciones o más bienes
> materiales... y quizás también con la tercera, donde una vez tenemos
> ya 'todo lo que queremos', nos centramos en 'dar' a los demás, y
> sentirnos así completos, proyectando nuestra imagen en la de los
> demás.

3.  **TERCERA ETAPA -- VEJEZ Y MUERTE:** Desarrollo dado durante el
    progreso de la tercera mazmorra. La luna pasará de segunda a tercera
    etapa, conectando con la luna llena que sólo se verá cuando se
    afronte el final del juego. En este punto se desbloquea la "Zona 3",
    y junto a ella, los recuerdos de la última etapa de la vida de la
    hechicera, relacionada con la vejez y la muerte: sabiduría, y miedo
    a lo desconocido al mismo tiempo, reflexión y contemplación de la
    muerte... y la consecuente decisión de querer saber más acerca del
    mundo, de perdurar con el tiempo. Sin embargo, entre estos
    recuerdos, también habrá otros más extraños, que parezcan hablar de
    un sentimiento de pérdida del "yo" derivado de la obtención del
    conocimiento absoluto.

> A su vez se puede relacionar esta etapa final con la cuarta etapa de
> Jung, la etapa espiritual, donde se trascienden los vínculos
> materiales y afectivos, y se busca un entendimiento superior de uno
> mismo y de todo el mundo: **superar nuestro punto de vista individual
> para empezar a comprender cómo todas las cosas se conectan**. Este
> sería sin duda el empuje final que llevó a la hechicera a pactar para
> convertirse en "Ogmia", la encarnación de todo el conocimiento

### Estructura de las mazmorras

En esta sección se dará una descripción generalista de la estructura de
una mazmorra, tomando como ejemplo el esquema adjunto en la siguiente
página, describiendo el flujo de juego y los objetivos de una mazmorra
como nivel, así como sus componentes individuales y su función:

![](media/image19.png){width="6.410416666666666in"
height="9.326005030621172in"}

El jugador comienza siempre el nivel en el punto de salida (1). El
momento en que abandona la mazmorra está sujeto a distintas
posibilidades dentro de las necesidades del desarrollo:

-   Si el tiempo de desarrollo lo permite, se habilitarán puntos de
    salida en las 'salas de fragmento' (5 y 6), desde los cuáles el
    jugador puede salir al Sueño de Medianoche para guardar la partida y
    su progreso. Cuando vuelva a la mazmorra a través de la entrada
    habilitada en el sueño, reaparecerá de nuevo en la entrada, pero su
    progreso dentro de la mazmorra se guardará (número de fragmentos
    recolectados, esquirla de combate, progreso del minimapa, etc).

-   En caso de que lo anterior no sea posible, se introducirán puntos de
    guardado automáticos cada vez que el jugador encuentre un fragmento
    u obtenga una esquirla, de manera que el juego se guardará no
    solamente en el Sueño de Medianoche, sino también en las mazmorras
    al progresar.

En cualquiera de los dos casos, la estructura de la mazmorra y los
objetivos dentro de ésta no cambian. Siguiendo el recorrido planteado
por el esquema, tenemos:

1.  **ENTRADA:** punto donde aparece el jugador al entrar a la mazmorra,
    independientemente de si es la primera vez que entra en en ella o
    no. Siempre que el jugador entre a la mazmorra a través del Sueño de
    Medianoche, aparece en este punto. Esto aporta a la sensación de
    riesgo del jugador, que gestionará con cuidado cuándo entra y sale
    de la mazmorra.

2.  **SALA DE COMBATE:** cuando un jugador entre en una sala de combate,
    las puertas se cerrarán detrás de él: no se volverán a abrir hasta
    que el jugador derrote a todos los enemigos de la sala. Esta
    mecánica es reminiscente de juegos como los clásicos de 'Zelda' o el
    más reciente 'Binding of Isaac'[^5], que obliga al jugador a pelear
    y consagra la experiencia de combate como requisito para superar el
    juego. Si el jugador sobrevive al combate, las puertas se abren, y
    este puede continuar explorando la mazmorra. Conforme se avance en
    el juego, estas salas contendrán combinaciones de enemigos más
    duros.

3.  **SALA DE TRAMPAS:** estas salas no contendrán enemigos. En su
    lugar, supondrán un peligro para el jugador por estar repletas de
    trampas que tendrán el objetivo de herir y obstaculizar al jugador,
    que deberá hacer buen uso de las mecánicas de movimiento y dash para
    superar estos espacios y continuar explorando. Se podrían entender
    como segmentos de plataformeo, pese a carecer de una mecánica de
    salto. Conforme se avance en las mazmorras, estas salas serán cada
    vez más comunes, y tendrán una variedad de trampas mayor y más
    letal.

4.  **SALA DE SANACIÓN:** estas salas suponen una 'zona de descanso'
    para el jugador, ya que no suponen ningún peligro y ofrecen el único
    medio para recuperar vida dentro de la mazmorra. Estas salas tienen
    un 'aura de sanación' en su centro, que restaurará vida al jugador
    si este se acerca a ella. Sin embargo, [la cantidad de vida que
    pueden aportar es limitada]{.ul}, y una vez esta se agote, el
    'manantial' de vida se agotará y no se repondrá hasta que el jugador
    salga de la mazmorra. Cuando vuelva a entrar, estos 'manantiales' se
    repondrán.

5.  **SALA DE FRAGMENTO (COMBATE):** esta sala contiene un
    [fragmento]{.ul} de esquirla de amuleto. Tal y como se estableció en
    el apartado 10.1.1., es necesario encontrar todos los fragmentos de
    amuleto de una mazmorra para formar la esquirla completa relacionada
    con la exploración de ésta. Esta mazmorra contiene uno de esos
    fragmentos, pero para conseguirlo, el jugador tendrá pelear.

> Una vez el jugador coja el fragmento, las puertas de la habitación se
> cerrarán y enemigos aparecerán por sorpresa. Para poder salir con vida
> de allí, el jugador tendrá que derrotarlos primero. Estos combates
> deberían ser algo más complicados que los de las salas de combate
> habituales, ya que es un desafío que el jugador acepta al coger el
> fragmento.

6.  **SALA DE FRAGMENTO (TRAMPAS):** esta sala, al igual que el
    arquetipo anterior, contiene un fragmento de esquirla de amuleto. La
    única diferencia es que en este caso, el jugador deberá sortear una
    serie de trampas para alcanzar el lugar donde está el fragmento y
    recogerlo, pero no tendrá que pelear contra enemigos. Estas trampas
    deberían ser más complejas de superar que las de salas de trampas
    habituales.

> **EXTRA: SALA DE FRAGMENTO VACÍA:** cabe destacar que también cabe la
> posibilidad de encontrar salas de fragmento que no opongan ningún tipo
> de resistencia al jugador para conseguirlo. Estas salas deberían
> aparecer con más frecuencia al principio del juego, para moldear la
> curva de dificultad, o en modos de dificultad más fáciles, si es que
> se introducen modos de dificultad distintos.

7.  **SALA DE BOSS:** esta sala, que normalmente se encontrará en el
    punto más alejado de la mazmorra, contendrá un 'jefe final' de
    mazmorra, que el jugador tendrá que derrotar para obtener la
    esquirla de combate de esa mazmorra, necesaria junto a la esquirla
    de exploración para obtener acceso a la siguiente mazmorra.
    Normalmente, el jefe de mazmorra será mucho más fácil de derrotar si
    se cuenta con la habilidad adquirida gracias a la esquirla de
    exploración de ese mismo nivel (consultar apartado 10.2.1. para más
    información)

8.  **SALA DE LORE:** este tipo de salas existen para expandir la
    narrativa emergente del juego. Dentro de ellas, se podrán encontrar
    objetos interaccionables (sean diarios, fantasmas, personajes, etc)
    que contarán una pequeña historia o retazo de historia que el
    jugador podrá relacionar con el espacio de la mazmorra, para darle
    un sentido y una atmósfera, y con la temática general del juego.
    Sirve también como zona de descanso en la curva de intensidad
    general.

9.  **SALA VACÍA:** salas que no tienen ningún elemento importante: ni
    trampas, ni enemigos, ni objetos interaccionables. Esto no quiere
    decir que estén vacías 'visualmente' (más bien debería ser todo lo
    contrario), sino que no tienen ningún elemento mecánicamente
    importante dentro de ellas. Sirven para aligerar la curva de
    intensidad general del nivel, y para dar un descanso al jugador.

10. **SALIDA:** la salida de la mazmorra. No tiene por qué ser la única
    salida, pero sí que es la 'principal'. Siempre se encuentra justo
    después de la sala de jefe, y es necesario derrotarle para acceder a
    ella. Desde aquí el jugador puede volver al Sueño de Medianoche para
    salvar su progreso.

Enemigos
========

Este apartado consistirá en una descripción individual de todos los
enemigos del juego, incluyendo dónde se les puede encontrar y cuáles son
sus características.

Enemigos 'melee'
----------------

Aquellos enemigos que sólo pueden combatir a corta distancia

![](media/image20.jpeg){width="1.0152777777777777in" height="2.65in"}

### Esqueleto maltrecho

Enemigo melee más débil del juego.

-   **ZONAS DE APARICIÓN:** Tutorial y nivel 1.

-   **RATIO DE APARICIÓN:** Muy común.

-   **MÉTODO DE ATAQUE:** Se lanza al ataque sin pensárselo mucho. Sólo
    tiene un golpe básico cuerpo a cuerpo.

-   **VELOCIDAD DE MOVIMIENTO:** Normal.

-   **CANTIDAD DE VIDA:** Baja.

-   **CUÁNTO DAÑO HACE:** Poco daño.

### ![](media/image21.png){width="1.0048611111111112in" height="2.941666666666667in"}Esqueleto recluta

Como el esqueleto maltrecho, pero un poco más duro. Nada muy serio.

-   **ZONAS DE APARICIÓN:** Nivel 1 y 3.

-   **RATIO DE APARICIÓN:** Poco común en nivel 1, común en nivel 3.

-   **MÉTODO DE ATAQUE:** Espera su momento para atacar. Combo de dos
    golpes lentos.

-   **VELOCIDAD DE MOVIMIENTO:** Normal.

-   **CANTIDAD DE VIDA:** Normal-baja.

-   **CUÁNTO DAÑO HACE:** Normal.

### Goblin común

Un goblin normal y corriente. No es la gran cosa.

-   **ZONAS DE APARICIÓN:** Nivel 2.

-   **RATIO DE APARICIÓN:** Muy común.

-   **MÉTODO DE ATAQUE:** Ataca sin pensarlo demasiado. Tiene un único
    golpe básico.

-   **VELOCIDAD DE MOVIMIENTO:** Normal.

-   **CANTIDAD DE VIDA:** Normal-baja.

-   **CUÁNTO DAÑO HACE:** Normal-baja.

![](media/image22.png){width="1.0875in" height="3.0166666666666666in"}

### ![](media/image23.png){width="1.03125in" height="2.9833333333333334in"}Goblin soldado

Un goblin entrenado para combatir. Es más inteligente y más duro.

-   **ZONAS DE APARICIÓN:** Nivel 2.

-   **RATIO DE APARICIÓN:** Común.

-   **MÉTODO DE ATAQUE:** Se coordina con sus compañeros para atacar.
    Tiene un único golpe básico.

-   **VELOCIDAD DE MOVIMIENTO:** Normal.

-   **CANTIDAD DE VIDA:** Normal.

-   **CUÁNTO DAÑO HACE:** Normal.

![](media/image24.png){width="1.05in" height="3.2993055555555557in"}

### ![](media/image23.png){width="1.03125in" height="2.9833333333333334in"}Goblin pícaro

El tipo de goblin más astuto. Espera su momento para atacar y mantiene
la distancia.

-   **ZONAS DE APARICIÓN:** Nivel 2.

-   **RATIO DE APARICIÓN:** Poco común.

-   **MÉTODO DE ATAQUE:** Espera a que el jugador esté ocupado con otro
    enemigo para atacar con un solo golpe rápido. Cuando no tiene esa
    oportunidad, mantiene la distancia.

-   **VELOCIDAD DE MOVIMIENTO:** Rápido.

-   **CANTIDAD DE VIDA:** Baja.

-   **CUÁNTO DAÑO HACE:** Normal-alto.

### ![](media/image25.png){width="1.2041666666666666in" height="2.8666666666666667in"}Esqueleto soldado

Un soldado inteligente que coopera estrechamente con sus compañeros para
acabar con el enemigo.

-   **ZONAS DE APARICIÓN:** Nivel 3.

-   **RATIO DE APARICIÓN:** Común.

-   **MÉTODO DE ATAQUE:** Coopera en grupo para rodear al jugador y
    atacarle cuando no pueda defenderse. Tiene un combo de dos golpes
    rápidos.

-   **VELOCIDAD DE MOVIMIENTO:** Normal-rápido.

-   **CANTIDAD DE VIDA:** Normal-alta.

-   **CUÁNTO DAÑO HACE:** Normal-alto.

### ![](media/image26.jpeg){width="1.1909722222222223in" height="2.783333333333333in"}![](media/image25.png){width="1.2041666666666666in" height="2.8666666666666667in"}Esqueleto caballero

Un hueso muy duro de roer. Es el enemigo melee más duro del juego.

-   **ZONAS DE APARICIÓN:** Nivel 3.

-   **RATIO DE APARICIÓN:** Muy poco común.

-   **MÉTODO DE ATAQUE:** Se protege de los ataques del jugador con un
    escudo, y cuando tiene la oportunidad atacada con un combo de dos
    golpes.

-   **VELOCIDAD DE MOVIMIENTO:** Muy lento.

-   **CANTIDAD DE VIDA:** Muy alta.

-   **CUÁNTO DAÑO HACE:** Alto.

Enemigos a distancia
--------------------

Aquellos enemigos que combatan desde la distancia.

![](media/image27.png){width="1.0993055555555555in"
height="3.1493055555555554in"}

### Esqueleto cobarde

Enemigo a distancia más débil. Es un cobarde que sólo sabe tirarte
piedras.

-   **ZONAS DE APARICIÓN:** Tutorial y nivel 1.

-   **RATIO DE APARICIÓN:** Poco común.

-   **MÉTODO DE ATAQUE:** Mantiene la distancia con el jugador y le tira
    piedras mientras está ocupado con otros enemigos.

-   **VELOCIDAD DE MOVIMIENTO:** Normal.

-   **CANTIDAD DE VIDA:** Muy baja.

-   **CUÁNTO DAÑO HACE:** Muy poco daño.

### ![](media/image28.jpeg){width="0.9916666666666667in" height="2.70625in"}Goblin chamán

Un poderoso goblin capaz de curar y buffear a sus aliados.

-   **ZONAS DE APARICIÓN:** Nivel 2.

-   **RATIO DE APARICIÓN:** Muy poco común.

-   **MÉTODO DE ATAQUE:** Huye del jugador constantemente. Cuando está a
    una distancia segura, sana o potencia a sus aliados.

-   **VELOCIDAD DE MOVIMIENTO:** Normal-alta.

-   **CANTIDAD DE VIDA:** Normal.

-   **CUÁNTO DAÑO HACE:** No hace daño.

### ![](media/image29.png){width="1.05in" height="3.048611111111111in"}Goblin bruja

Brujas que poseen magia de ataque muy molesta.

-   **ZONAS DE APARICIÓN:** Nivel 2.

-   **RATIO DE APARICIÓN:** Poco común.

-   **MÉTODO DE ATAQUE:** Mantiene la distancia con el jugador, y cuando
    puede ataca a distancia con conjuros.

-   **VELOCIDAD DE MOVIMIENTO:** Normal-alta.

-   **CANTIDAD DE VIDA:** Normal-baja.

-   **CUÁNTO DAÑO HACE:** Normal.

![](media/image30.png){width="1.2270833333333333in"
height="2.6083333333333334in"}

### Espíritu vengativo

El enemigo a distancia más peligroso. Posee un amplio arsenal de
acciones.

-   **ZONAS DE APARICIÓN:** Nivel 3.

-   **RATIO DE APARICIÓN:** Poco común.

-   **MÉTODO DE ATAQUE:** Mantiene la distancia con el jugador
    constantemente. Puede sanar, buffear aliados o atacar con magia al
    jugador. En cada situación escoge la opción más inteligente.

-   **VELOCIDAD DE MOVIMIENTO:** Muy alta.

-   **CANTIDAD DE VIDA:** Normal.

-   **CUÁNTO DAÑO HACE:** Alto.

Enemigos especiales / bosses
----------------------------

Los enemigos especiales o bosses son todos aquellos cuyo comportamiento
los diferencia de los demás de manera destacada. Según el planteamiento
de diseño inicial, sólo habrá tres jefes en el juego, con posibilidad de
un jefe final (la hechicera). A continuación, se describe a grandes
rasgos a cada uno de ellos:

### Jefe de la primera mazmorra

Debe explotar el dash mejorado. Por lo tanto, debería poseer ataques que
cubran mucho espacio y sean muy difíciles (que no imposibles) de
esquivar si no se tiene el dash mejorado.

### Jefe de la segunda mazmorra

Este jefe debería explotar el ataque circular. Por lo tanto, se deben
crear situaciones que serían mucho más fáciles de resolver si se dispone
de un ataque de área amplio, como por ejemplo, un jefe que pueda invocar
muchos 'minions', de los que es mucho más fácil librarse atacando con el
ataque circular.

### Jefe de la tercera mazmorra

Este jefe debería explotar la mecánica de bloqueo. Eso se consigue
atribuyéndole ataques que sean casi inesquivables, pero fáciles de
bloquear si se tiene el timing apropiado: esto puede traducirse como
ataques de área enormes, o ataques instantáneos, o ataques que no se
pueden esquivar con dash porque el enemigo se mueve contigo al atacarte,
etc.

Flujo de juego
==============

A continuación, se describirá el flujo de juego esperado en una partida
estándar de \[Moonraider\]:

Lo primero con lo que se encontrará el jugador es con la pantalla de
'splash screen' que muestre el logo del estudio. Tras un breve tiempo de
carga, llega a la pantalla de título del juego. El jugador realizará
ajustes en la pantalla de opciones si lo desea, y comenzará una nueva
partida cuando se sienta cómodo para hacerlo.

Tras iniciar una nueva partida, lo primero que verá el jugador será una
cutscene introductoria que toma lugar en el tutorial (revisar apartado
11.2.1.), que le introducirá a la narrativa, atmósfera y tema del juego,
encarnándole además en la figura del viajero protagonista. Tras esta
cutscene, el jugador interaccionará con el tutorial, aprendiendo paso a
paso las mecánicas de juego y explorando este primer escenario, que
establecerá la tónica de exploración y combate que tendrá el resto del
juego, estableciendo una fórmula divertida y enganchando al jugador al
gameplay desde el primer momento. Tras completar el tutorial activando
el Amuleto de Ogmia, el jugador presenciará otra cutscene, que le
introducirá al Sueño de Medianoche, su funcionamiento dentro del juego,
y sobre todo, su función dentro de la historia del juego. En este
momento se cierra la introducción, donde ya se han establecido todos los
objetivos del juego, y a partir de aquí el jugador se mueve entre el
Sueño de Medianoche y las mazmorras, sabiendo en todo momento lo que
tiene que hacer para completar el juego, y cuánto le queda para
conseguirlo.

Dentro de cada mazmorra, el jugador explora el nivel peleando y evitando
trampas, en busca de los fragmentos de esquirla de amuleto que le
otorgarán nuevas habilidades, a la vez que intenta localizar la sala de
jefe para pelear contra él cuando se sienta preparado. Si las mecánicas
lo permiten, vuelve de vez en cuando al Sueño de Medianoche para guardar
partida (en caso contrario, guarda automáticamente el juego). Si muere,
pierde su progreso dentro del nivel y reaparece en el Sueño de
Medianoche, o en el anterior checkpoint, y sigue explorando, combatiendo
y encontrando cachitos de lore emergente en la mazmorra, hasta que
encuentra las dos esquirlas y obtiene acceso a la siguiente mazmorra a
través del Sueño de Medianoche.

Por otro lado, cada vez que vuelve al Sueño de Medianoche tras haber
conseguido una nueva esquirla, este crece, notificando al jugador de
alguna manera que algo ha cambiado dentro de él, permitiéndole explorar
el Sueño de Medianoche si lo desea, y a través de él, la narrativa
central del juego y el hilo argumental que une al Amuleto de Ogmia, con
el protagonista, y la propia figura de "Ogmia" y el conocimiento
absoluto.

Con cada nueva mazmorra el jugador encontrará un mayor desafío y un
entorno distinto, con enemigos más duros, pero con oportunidades para
adquirir nuevas habilidades y mejorar. Esta fórmula de explorar,
combatir y moverse entre el Sueño de Medianoche y la mazmorra,
explorando la narrativa a deseo del jugador en el proceso, se repetirá
hasta que el jugador encuentre la última esquirla del amuleto en la
tercera mazmorra.

Una vez el amuleto esté completo y el jugador vuelva por última vez al
Sueño de Medianoche, se guardará la partida automáticamente y después se
mostrará la cutscene final donde se revela la naturaleza del contrato
entre el protagonista y la deidad 'Ogmia', dándole la decisión final al
jugador acerca de si desea obtener el conocimiento absoluto.

Si el jugador escoge que 'sí', entonces se muestra una cutscene donde el
protagonista se transforma en el nuevo 'Ogmia' y la hechicera muere en
paz repitiéndose así el 'ciclo infinito' de la búsqueda humana del
conocimiento. Tras la cutscene, se da lugar a una cortina de créditos, y
tras esta, la pantalla final de conclusión, con informe de batalla, si
se quiere incluir.

Alternativamente, si el jugador escoge que 'no' desea rendir su
individualidad a cambio del conocimiento absoluto, la hechicera se
enfrenta a él en un intento de obligarle a arrebatarle la vida. Si se
implementa una batalla de boss, este enfrentamiento se resolverá
mediante una pelea jugable; si no, se verá mediante una cutscene como el
protagonista se ve obligado a matar a la hechicera, o cómo esta se
suicida. En cualquier caso, tras morir la hechicera, y con ella el ente
divino del conocimiento absoluto, el protagonista se aleja del Sueño de
Medianoche mientras este se desvanece, para continuar con su 'vida
mortal' (consultar sección de 'Narrativa y Personajes' para más
detalles). Tras esta cutscene, se muestra la cortina de créditos y la
consiguiente pantalla final, con informe de batalla si se desea (muy
poco prioritario).

En cualquiera de los dos casos, la partida concluye con un final acorde
a las decisiones del jugador, pero con cierto espacio a la ambigüedad de
cuál era la opción más correcta. Idealmente, el jugador se habrá
divertido explorando y peleando, jugando a \[Moonrider\], y habrá
explorado la narrativa del juego hasta donde él haya deseado, sin verse
forzado a ello en ningún momento. Incluso es posible que no sólo se haya
divertido, sino que además la experiencia de juego le haya aportado
algo, o le haya hecho reflexionar acerca de alguno de los temas del
juego.

Finalmente, tras acabar el juego, el jugador probablemente abandone la
sesión de juego. Si vuelve a jugar al juego, probablemente será para
explorar más la narrativa emergente o porque el gameplay le ha resultado
tan divertido que 'le apetece echar un rato jugando'. Con un poco de
suerte, lo recomendará a amigos, o se interesará en seguir los futuros
trabajos del estudio o sus integrantes; de cualquier manera, este se
considera un flujo de juego y conclusión satisfactorios.

Hoja de ruta del desarrollo
===========================

En lo referente al desarrollo y la metodología de trabajo, se ha
decidido trabajar con una metodología ágil cercana a SCRUM, donde se
tiene sprints de una semana de duración, que conforman a su vez los
'hitos' del desarrollo:

PRIMER HITO: Prototipo Funcional (21 Diciembre)
-----------------------------------------------

Prototipo funcional que implemente todas las mecánicas núcleo del juego.

SEGUNDO HITO: Alpha (30 Diciembre)
----------------------------------

Versión Alpha del juego que cierre el 'Game Loop'; es decir, que se
pueda jugar de inicio a final, aunque falten assets, mecánicas o haya
algunos bugs.

TERCER HITO: Beta (6 Enero)
---------------------------

Trabajar en finalizar todo lo que no estuviera en la beta, recibiendo
feedback constante de la Alpha para corregir bugs o balancear el juego.
En la versión beta deben estar todos los assets del juego, y deben
reducirse los bugs a un mínimo aceptable para exponer el juego al
público.

CUARTO HITO: Playtesting & prelanzamiento (10-12 Enero)
-------------------------------------------------------

Playtesting constante y masivo a través de una beta abierta. Campaña de
marketing masiva de cara al lanzamiento, pulido final y optimización
completa del juego.

QUINTO HITO: Lanzamiento (11-13 Enero)
--------------------------------------

Lanzamiento oficial del juego.

HITO FINAL: Presentación (20 Enero)
-----------------------------------

Presentación del juego ante tribunal profesional.

Modelo de negocio a largo plazo
===============================

Tras finalizar el desarrollo de \[Moonrider\], Kilonova Studios pretende
conseguir beneficios de dicho proyecto a lo largo de los próximos 2 años
con los siguientes modelos de negocio:

Fidelización
------------

En el mercado del videojuego es un hecho que mantener a un jugador fiel
es más fácil que captar a uno nuevo; 10 veces más fácil, de hecho, según
dicen los datos del mercado que el estudio ha consultado.

Por este motivo, se centrarán esfuerzos en mantener la base de jugadores
que obtenga el juego en su lanzamiento, para ir expandiéndola poco a
poco sin perder nunca a su público base; para conseguir esto, el juego
recibirá actualizaciones periódicas con nuevo contenido, y se realizarán
eventos en fechas especiales.

Así mismo, periódicamente se lanzarán campañas en las que los usuarios
podrán invitar a sus conocidos y si estos se unen a través de su enlace,
ambos serán recompensados con jugosas recompensas (skins exclusivas,
monedas del juego, misiones especiales, etc.)

Freemium
--------

Para captar a nuevos jugadores que se unan a la base sólida que se ha
mencionado en el punto anterior, el juego se basará en un modelo
'freemium", donde cualquier jugador puede adquirir el videojuego, pero
para poder acceder al contenido completo (más modos de juegos, mapas,
expansiones, misiones, etc.) tendrá que pagar una suscripción mensual,
teniendo previamente una prueba gratis de tres días. Esta práctica
conjunta muy bien a la anterior, creándose una sinergia entre mantener a
los jugadores veteranos, y atraer a otros nuevos, todo con el mismo plan
de desarrollo de contenido.

Actualmente el mercado del género dungeon crawler abarca más de cuarenta
millones de personas, por lo que nos encontramos ante un mercado masivo
en el que el último modelo de negocio se asentará perfectamente,
ofreciendo el producto gratuitamente, pero obteniendo una gran
retribución por las numerosas personas que irán adquiriendo la versión
premium.

![](media/image31.jpeg){width="8.195167322834646in" height="5.63200021872266in"}Canvas
======================================================================================

Monetización
============

Para conseguir que el modelo de negocio simbiótico de freemium +
fidelización funcione, la empresa necesita que las horas de juego de los
usuarios se transformen en ingresos para el estudio. Para conseguir
esto, se utilizarán tres tipos de monetización distintos:

Microtransacciones
------------------

Dado que el videojuego realizado se centra en el combate y la
exploración, el usuario podría encontrar problemas para poder avanzar en
alguna de las dos circunstancias. Por ello, se ofrecerá al usuario la
posibilidad de pagar pequeñas cantidades en el juego, por ejemplo, para
adquirir armas especiales para el combate o vestimentas para el
personaje.

DLCs / expansiones
------------------

Para alimentar el modelo de negocio del juego y mantener a los jugadores
fieles contentos, se publicarán expansiones y nuevo contenido del juego
de manera regular, consistiendo éste principalmente en nuevos mapas de
juego y nuevos modos de juego, así como misiones especiales.

Se ofrecerán dos maneras de acceder a este contenido:

-   **Membresía 'premium'**, similar a un 'battle pass', que por una
    cuota fija de pago periódico ofrece al jugador todo el contenido
    nuevo que se vaya publicando del juego, pudiendo mantener el que
    obtuviera en el pasado si decide dejar el programa.

-   **Compra individual de paquetes**; esta opción está pensada para
    jugadores más casuales que quieran escoger sólo los contenidos que
    más les interesen a ellos.

Publicidad integrada
--------------------

Como Unity solo ofrece la posibilidad de poner publicidad en los
dispositivos móviles, sería injusto incluirla de este modo ya que los
usuarios que jugasen en ordenador disfrutarían de una experiencia sin
anuncios mientras que los usuarios de móvil se verían obligados a
verlos. Por dicho motivo, el estudio ha optado por incluir dicha
publicidad directamente en los escenarios y vestimentas de los
personajes. De este modo, se podrán realizar colaboraciones con
diferentes marcas que tengan una temática parecida a la del juego,
pagando estos para ser incluidos en el videojuego durante una
determinada cantidad de tiempo, transcurrido dicho tiempo, los
escenarios o vestimentas se mostrarán sin los logos de los sponsors.

A su vez, durante fechas claves como Halloween, Black Friday o Navidad,
se lanzarán campañas publicitarias para aprovechar el impulso que dichos
días ofrecen al mercado y al marketing.

Marketing
=========

Lanzamientos audiovisuales
--------------------------

El tráiler del videojuego se lanzará como anuncio de 20 segundos en la
plataforma Youtube. Inicialmente, durante la primera semana, el anuncio
se tendrá que visualizar completo sin la posibilidad de saltarlo tras
los primeros 5 segundos, pero posteriormente dicha opción estará
disponible.

Otros canales en los que podremos realizar esta campaña serán en
videojuegos como "Parchis Star" o aplicaciones como "Tinder".

Asimismo, streamers de Twitch serán pagados para que lo jueguen en
directo o lo suban a su canal para que sus seguidores lo vean.

***\-\-\-\--Insertar fotos de cómo se vería en YT y Tinder con imágenes
del juego + stream en Twitch\-\-\-\-\-\-\-\--***

Blogs y RRSS especializadas
---------------------------

El estudio se pondrá en contacto con diferentes perfiles de la red
social Instagram y con blogs de Blogger que puedan hacerles reviews o
simplemente promocionarles para que llegue a una cantidad mayor de
audiencia.

***\-\-\-\--Insertar fotos de cómo se vería en los perfiles de IG y
blogs\-\-\-\-\-\-\-\--***

Autopromoción
-------------

Dado que la red social Instagram permite realizar campañas de promoción
personales, el el grupo optará por ir a través de esta vía también,
pudiendo personalizar los parámetros para llegar a su público objetivo.

A la vez, la potente tecnología de Google Ads será una gran ayuda
también para redirigir a más público al sitio web donde se alojará el
videojuego.

También se ofrecerá a los usuarios la posibilidad de adquirir
merchandising relacionado con la empresa o los vidoejuegos.

Word of mouth
-------------

Se promocionará el videojuego a través de publicaciones de los miembros
del equipo en sus respectivas redes sociales al mismo tiempo que se
compartirán capturas del proyecto por diferentes grupos de Facebook
enfocados al sector de los videojuegos.

***\-\-\-\--Insertar fotos de cómo se vería en grupos de
FB\-\-\-\-\-\-\--***

Referencias y anexos
====================

[^1]: Dios primordial de la mitología celta que unía a los seres humanos
    con los dioses a través del conocimiento

[^2]: Biblioteca y plataforma online de Adobe que contiene un gran
    número de animaciones de dominio público

[^3]: [Dark
    souls](https://store.steampowered.com/app/211420/DARK_SOULS_Prepare_To_Die_Edition/?l=spanish):
    videojuego desarrollado por From Software y publicado en 2011

[^4]: [Hyper Light
    Drifter](https://store.steampowered.com/app/257850/Hyper_Light_Drifter/):
    videojuego desarrollado por Heart Machine y publicado en 2016

[^5]: <https://es.wikipedia.org/wiki/The_Binding_of_Isaac>
