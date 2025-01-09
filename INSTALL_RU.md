# Как установить

## Установка

1. **Скачивание программы**: Когда ви скачали папку с автосплиттером загрузите Visual Studio и установите .NET SDK версии 8 или 9 (код написан для 8 версии). При установке выберите пакет "Desktop development with .NET". Установите библиотеки: OpenCvSharp4, OpenCvSharp4.Extensions, OpenCvSharp4.runtime, System.Drawing.Common. Вы можете установить их через консоль диспетчера пакетов, Manage NuGet Packages for Solution, Терминал.

2. **Как установить пакеты**: В консоли диспетчера пакетов: откройте ее через меню «Инструменты», затем в диспетчере пакетов NuGet выберите «Консоль диспетчера пакетов». Затем добавьте следующую команду Install-Package, а затем имя пакета, например, Install-Package OpenCvSharp4.runtime.win.

Использование Manage NuGet Packages for Solution: его можно найти в том же меню, что и Package Manager Console. В Manage NuGet Packages for Solution перейдите на вкладку Поиска и найдите имена пакетов, затем загрузите последние версии.

Использование терминала: откройте ее через меню Вид и откройте терминал. Выполните следующую команду: "dotnet add package", после которой напишите имя пакета, например:
dotnet add package OpenCvSharp4
Добавив --version и номер версии, вы можете загрузить эту конкретную версию, например:
dotnet add package OpenCvSharp4 --version 4.10.0.

3. **Установка PowerToys**: Скачайте PowerToys и настройте функцию "Всегда поверх других окон".

## Запуск автосплиттера

Откройте Visual Studio и выберите Open a project or solution. Найдите .sln-файл и откройте его. Там вы увидите код файла. В файле .csproj проверьте:
Установленные библиотеки в <ItemGroup>;
Настройки терминала и фреймворка в <PropertyGroup>;
Вашу ОС и .NET в <Project>.

# Пример:

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

Когда ви запускаете код, делайте это нажатием Ctrl+F5 или нажатием кнопки Play. Игра должна быть в полноэкранном или оконном режиме, но не свернутой.

_Редактируйте, сохраняйте или модифицируйте код в файле .cs когда вам нужно сделать изменения._

## Проверка и корректировка

Убедитесь, что эталонные и исключаемые изображения настроены корректно и соответствуют скриншотам из игры.

Если возникают проблемы или ложные срабатывания, настройте параметры изображений или исправьте код.