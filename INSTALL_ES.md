# Como instalar

## Instalación
1. **Descargar el programa**: Una vez hayas descargado la carpeta del autosplitter, deberás descargar el instalador de Visual Studio de Microsoft junto al SDK de .NET 8 o 9 (el código está escrito con SDK .NET 8 para Windows). Luego de tener el instalador, deberás descargar ya sea la versión preview o la versión estable junto al paquete Desarrollo de escritorio .NET. Una vez tengas todo esto, sigue descargando las bibliotecas necesarias para que funcione el código del autosplitter, las cuales son: OpenCvSharp4, OpenCvSharp4.Extensions, OpenCvSharp4.runtime, y System.Drawing.Common. Todas estas bibliotecas las puedes descargar en 3 lugares diferentes: en Package Manager Console, Manage NuGet Packages for Solution, y en la Terminal.

2. **¿Como installar los paquetes?**: En Package Manager Console: Accede a ella en el apartado Tools y luego en NuGet Package Manager, selecciona Package Manager Console. Luego, agrega el siguiente comando Install-Package seguido del nombre del paquete, como Install-Package OpenCvSharp4.runtime.win.

Con Manage NuGet Packages for Solution: Se encuentra en la misma ruta que Package Manager Console. Dentro de Manage NuGet Packages for Solution, ve al apartado de Browse y busca el nombre de los paquetes y descarga las últimas versiones.

Con la Terminal: Accede a ella en el apartado de View y abre la Terminal. Ahí, ejecuta el siguiente comando dotnet add package seguido del nombre del paquete, como dotnet add package OpenCvSharp4. Agregando --version y el número de la versión, podrás descargar exactamente esa versión, como dotnet add package OpenCvSharp4 --version 4.10.0.

3. **Desacargar complemento**: Descarga PowerToys y configúralo para utilizar Always on Top junto al atajo de comando predefinido para mantener siempre la ventana de la terminal visible en todo momento.

## Ejecutar el AutoSplitter
Abre Visual Studio y selecciona la opción de Open a project or solution y busca el archivo .sln y ábrelo. Una vez dentro, verás el código del autosplitter. En la pestaña del .csproj, asegúrate de tener en los <ItemGroup> todos los paquetes de las bibliotecas instalados, en <PropertyGroup> la configuración de la terminal y el framework que estás utilizando, y por último en el <Project> tu sistema operativo junto al SDK o .NET que estás usando.
  # Ejemplo: 
  <Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

	<PropertyGroup>
		<OutputType>Exe</OutputType>
		<UseWindowsForms>true</UseWindowsForms>
		<TargetFramework>net8.0-windows</TargetFramework>
		<Nullable>enable</Nullable>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="OpenCvSharp4" Version="4.10.0.20241108" />
		<PackageReference Include="OpenCvSharp4.Extensions" Version="4.10.0.20241108" />
		<PackageReference Include="OpenCvSharp4.runtime.win" Version="4.10.0.20241108" />
		<PackageReference Include="System.Drawing.Common" Version="9.0.0" />
	</ItemGroup>

</Project>

Por último, cada vez que quieras iniciar el código, hazlo con Ctrl+F5 o en el botón de Play con el juego en modo pantalla completa o en modo ventana sin minimizar la pestaña del juego.

*Recuerda que cada vez que quieras editar, guardar o modificar el código, hazlo en el archivo .cs*

## Verficacion y Ajustes
Asegúrate de que las imágenes de referencia y las imágenes de exclusión estén correctamente configuradas y coincidan con las capturas de pantalla del juego.

Si encuentras algún problema o falso positivo, ajusta las imágenes de exclusión o los parámetros del código según sea necesario.