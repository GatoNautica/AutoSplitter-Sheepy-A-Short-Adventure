# SheepyAutoSplitter

## Descripción General
SheepyAutoSplitter es una herramienta diseñada para ayudar a los speedrunners a dividir automáticamente el tiempo en puntos de control predefinidos (splits) durante una carrera de Sheepy A Short Adventure. Permite a los jugadores concentrarse en el juego sin preocuparse por registrar los tiempos manualmente.

## ¿Quién Soy?
Soy GatoNáutica, un desarrollador multimedia principiante apasionado por los videojuegos y la programación. Disfruto creando y explorando nuevas ideas en mi tiempo libre, siempre buscando divertirme y pasar un buen rato.

## ¿Por Qué Lo Hice?
Al principio, no tenía esto en mente. La idea surgió después de intentar hacer mi primer speedrun y subirlo a la página antes de leer el foro. Fue entonces cuando me di cuenta de que el juego no tenía soporte para autosplitter, lo cual me distraía mucho al tener que hacer los splits manualmente (y también porque me daba flojera hacerlo).

Así que, una noche del 8 de diciembre a las 3:09 a.m., mientras no podía dormir, decidí empezar este proyecto. Aquí está el resultado. Es la primera vez que hago algo así, por lo que es posible que tenga errores o que se pueda mejorar de una mejor forma. Como no tengo mucho conocimiento en estos temas, al inicio intenté usar Cheat Engine, pero no me funcionó; nunca supe qué hacer exactamente.

## ¿Cómo Funciona el Código?
El autosplitter funciona capturando la pantalla del juego y analizando el contenido para identificar cuándo se alcanzan los puntos de control. Utiliza técnicas de procesamiento de imágenes para detectar pantallas negras y verificar imágenes de referencia. También está programado para evitar falsos positivos en ciertas zonas o al realizar determinadas acciones.

Según las reglas de la run, esta solo es válida y termina en el primer pantallazo en negro después de finalizar el capítulo 6, justo antes de los créditos. Por lo tanto, el código analiza las pantallas en negro al pasar de un capítulo a otro para hacer los splits de forma más precisa.

Acciones como perder o abrir el menú del juego, que generan pantallas en tonos negros y podrían causar falsos positivos, están completamente gestionadas. Me aseguré de que cada acción que genera una pantalla en negro no deseada no sea detectada 
para evitar errores.

## Funciones implementadas en el código
1. **Captura de Pantalla**:

El código utiliza la biblioteca OpenCvSharp para capturar la pantalla del juego. La función CaptureFullScreen toma una captura de pantalla completa y la convierte en una matriz de imágenes (Mat).

2. **Detección de Pantallas Negras**:

La función IsBlackScreen convierte la captura de pantalla a escala de grises y calcula el histograma de la imagen. Si el porcentaje de píxeles negros o tonos oscuros supera un umbral específico, se considera que es una pantalla negra.

3. **Verificación de Imágenes de Referencia**:

El autosplitter compara la captura de pantalla actual con las imágenes de referencia (end.png) de cada capítulo utilizando la función IsMatch. Esta función convierte ambas imágenes a escala de grises y utiliza la técnica de coincidencia de plantillas para determinar el nivel de coincidencia.

4. **Exclusión de Imágenes No Deseadas**:

Para evitar falsos positivos, el código también verifica si la captura de pantalla coincide con alguna de las imágenes de exclusión (noSplit1.png, noSplit2.png, etc.). Si hay una coincidencia, la pantalla negra se ignora.

5. **Ejecución del Autosplitter**:

La función StartSplitting es el corazón del autosplitter. Captura continuamente la pantalla, verifica si es una pantalla negra y comprueba las coincidencias con las imágenes de referencia y exclusión. Cuando se detecta un split válido, se registra el tiempo y se pasa al siguiente punto de control.

6. **Configuración de Imágenes**:

Las imágenes de referencia (end.png) y las imágenes de exclusión (noSplit1.png, noSplit2.png) deben colocarse en las carpetas adecuadas para que el autosplitter funcione correctamente. Las imágenes universales como start.png y menu.png también son esenciales para respaldar la detección.

## Uso Correcto del Autosplitter 
1. **Instalación**: Sigue las instrucciones del archivo `INSTALL.md` para configurar todas las dependencias y preparar el entorno.

2. **Ejecución**: Ejecuta el autosplitter desde Visual Studio. Preferiblemente como administrador.

3. **Configuración**: Personaliza las imágenes de referencia y las imágenes de exclusión para adaptarlas a tu run específica. Ejemplo: C:\Users\Tu Usuario\OneDrive\Desktop\AutoSplitter-Sheepy A Short Adventure

## ¿README_LANGUAGES.md?
Aquí se encuentran todos los mensajes que se muestran en el código y en la terminal. Únicamente para las personas que no hablan español.

## Contribuciones 
¡Las contribuciones son bienvenidas y apreciadas! Si tienes ideas, mejoras o encuentras algún problema, no dudes en colaborar con el proyecto. Aquí tienes algunas maneras de contribuir:
1. **Reportar Problemas**: Si encuentras algún bug o tienes problemas utilizando el autosplitter, abre un issue en el repositorio de GitHub.

2. **Sugerir Mejoras**: Si tienes ideas para nuevas características o mejoras en el código, abre un issue en GitHub para discutirlas con la comunidad.

3. **Enviar Pull Requests**: Si has realizado cambios o mejoras en el código, envía un pull request. Asegúrate de seguir las normas de contribución y de que tu código esté bien documentado.

4. **Documentación**: Ayuda a mejorar la documentación del proyecto añadiendo o actualizando información en los archivos README o en la wiki del proyecto.

5. **Traducciones**: Si puedes ayudar a traducir el proyecto o los mensajes del código a otros idiomas, abre un pull request con las traducciones.

6. **Compartir y Promocionar**: Comparte el proyecto con otros speedrunners y entusiastas de los videojuegos. Cuantas más personas utilicen y contribuyan al proyecto, mejor será.

## Licencia 
Este proyecto está licenciado bajo la [Licencia MIT](https://opensource.org/licenses/MIT)