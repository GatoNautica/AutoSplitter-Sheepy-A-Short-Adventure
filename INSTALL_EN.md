# How to Install

## Installation
1. **Download the Program**: Once you have downloaded the autosplitter folder, you need to download the Visual Studio installer from Microsoft along with the SDK for .NET 8 or 9 (the code is written with SDK .NET 8 for Windows). After obtaining the installer, download either the preview version or the stable version along with the Desktop development with .NET package. Once you have all this, proceed to download the necessary libraries for the autosplitter to function, which are: OpenCvSharp4, OpenCvSharp4.Extensions, OpenCvSharp4.runtime, and System.Drawing.Common. You can download all these libraries from three different places: Package Manager Console, Manage NuGet Packages for Solution, and the Terminal.

2. **How to Install Packages**: In Package Manager Console: Access it through the Tools menu, then in NuGet Package Manager, select Package Manager Console. Then add the following command Install-Package followed by the package name, like Install-Package OpenCvSharp4.runtime.win.

Using Manage NuGet Packages for Solution: It can be found in the same menu as Package Manager Console. Within Manage NuGet Packages for Solution, go to the Browse tab and search for the package names, then download the latest versions.

Using the Terminal: Access it through the View menu and open the Terminal. Run the following command dotnet add package followed by the package name, like dotnet add package OpenCvSharp4. By adding --version and the version number, you can download that specific version, like dotnet add package OpenCvSharp4 --version 4.10.0.

3. **Download PowerToys**: Download PowerToys and configure it to use Always on Top with the predefined command shortcut to keep the terminal window always visible.

## Running the AutoSplitter
Open Visual Studio and select the option Open a project or solution, then find the .sln file and open it. Once inside, you will see the autosplitter code. In the .csproj tab, make sure to have all the library packages installed in <ItemGroup>, the terminal configuration and framework you are using in <PropertyGroup>, and finally your operating system and SDK or .NET in the <Project>.
  # Example: 
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

Finally, every time you want to run the code, do it with Ctrl+F5 or by pressing the Play button with the game in fullscreen mode or windowed mode without minimizing the game window.

*Remember to edit, save, or modify the code in the .cs file every time you need to make changes.*

## Verification and Adjustments
Make sure that the reference images and exclusion images are correctly configured and match the game's screenshots.

If you encounter any problems or false positives, adjust the exclusion images or the code parameters as necessary.