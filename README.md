# Description

La idea es empezar por un sistema que almacene mis apuntes a modo de wiki en varios niveles y que, básicamente, cubra lo hago actualmente con Notion.

Organice deberá admitir una organización en dos niveles:

1. [Nivel 1] Temas Globales.
2. [Nivel 2] Temas específicos relacionados con el padre.

Un ejemplo sería:
* Angular
  * Installing and basics
  * Components
  * DataBinding

Podemos considerar que el nivel 0 es la carpeta del usuario.<br>
El nivel 1 serían una lista de carpetas dentro de la carpeta del usuario.<br>
El nivel 2 es una lista de ficheros .md dentro de la carpeta del tema.

Dentro de cada fichero, tenemos un texto que se debería de escribir en el sistema markdown.

La aplicación debe:

1. Si es la primera vez que la inicias, pedirte registrarte.
    * El registro está formado por:
      * Username
      * Carpeta raíz para crear tu carpeta de usuario.
2. Si estás registrado, acceder a tu carpeta de usuario y listar las carpetas de temas Globales
por pantalla.
3. Al escoger una carpeta. Mostrar la lista de páginas (ficheros) de la carpeta.
4. Al escoger una página, mostrarla por pantalla.
5. Poder volver atrás en la interfaz hacia páginas y temas. 

# Interfaz

Quiero mantener esta aplicación lo más sencilla posible, así que se quedará siendo una aplicación de consola.
De todos modos, quiero que tenga algo de diseño más allá de letras blancas sobre un fondo negro, así que la aplicación se desarrollará con una TUI utilizando la librería Spectreconsole.

[spectreconsole](https://github.com/spectreconsole/spectre.console)

# Markdown a cubrir.

- [ ] Heading
- [ ] Bold
- [ ] Italic
- [ ] Blockquote
- [ ] Ordered List
- [ ] Unordered List
- [ ] Code
- [ ] Horizontal Rule
- [ ] Link
- [ ] Image
- [ ] Table
- [ ] Fenced Code Block
- [ ] Task List	
