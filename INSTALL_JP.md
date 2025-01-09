# インストール方法
## インストール

**プログラムのダウンロード**:
最初に`autosplitter`フォルダをダウンロードします。次に、MicrosoftからVisual Studioインストーラーと、.NET 8または9のSDK（コードはWindows向けに.NET 8 SDKで書かれています）をダウンロードします。インストーラーを取得したら、プレビュー版または安定版と、.NETによるデスクトップ開発パッケージをダウンロードします。これらをすべて取得したら、`AutoSplitter`が動作するために必要なライブラリである`OpenCvSharp4`、`OpenCvSharp4.Extensions`、`OpenCvSharp4.runtime`、`System.Drawing.Common`をダウンロードします。これらのライブラリは、パッケージマネージャーコンソール、ソリューションのNuGetパッケージの管理、ターミナルの3つの異なる場所からダウンロード可能です。

**パッケージのインストール方法**: パッケージマネージャーコンソール: パッケージマネージャーコンソール: ツールメニューからNuGetパッケージマネージャーを選択し、パッケージマネージャーコンソールを選択します。その後、Install-Packageコマンドに続けてパッケージ名を追加し、例えば Install-Package OpenCvSharp4.runtime.win のように実行します。

ソリューションのNuGetパッケージ管理: パッケージマネージャーコンソールと同じメニュー内にあります。ソリューションのNuGetパッケージの管理で、参照タブに移動し、パッケージ名を検索して最新バージョンをダウンロードします。


ターミナル: 表示メニューからターミナルを開き、`dotnet add package`コマンドに続けてパッケージ名を追加し、例えば `dotnet add package OpenCvSharp4` のように実行します。`--version`オプションにバージョン番号を追加することで、特定のバージョンをダウンロードできます。例： `dotnet add package OpenCvSharp4 --version 4.10.0`

**PowerToysのダウンロード**: `PowerToys`をダウンロードし、常にトップに表示するためのショートカットコマンドを設定し、ターミナルウィンドウを常時表示できるようにします。


## AutoSplitterの実行

Visual Studioを開き、「プロジェクトまたはソリューションを開く」を選択して`.sln`ファイルを見つけ、開きます。内部にはAutoSplitterのコードが表示されます。`.csproj`タブで、
<ItemGroup>内にすべてのライブラリパッケージがインストールされていること、<PropertyGroup>内に使用しているターミナル構成とフレームワークが設定されていること、そして<Project>内にOSとSDKまたは.NETが設定されていることを確認します。

  # 例:
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


最後に、コードを実行するたびに、`Ctrl+F5`を押すか、プレイボタンを押してゲームをフルスクリーンまたはウィンドウモードで最小化せずに実行します。
変更時は毎回、`.cs`ファイルのコードを編集、保存、更新することを忘れないでください。

## 検証・調整
参照画像と除外画像が正しく構成され、ゲームのスクリーンショットと一致することを確認してください。
問題や誤検知が発生した場合は、除外画像またはコードのパラメーターを必要に応じて調整してください。