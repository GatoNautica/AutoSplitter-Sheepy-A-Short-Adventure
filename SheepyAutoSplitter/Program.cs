using OpenCvSharp;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

class AutoSplitter
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out Rect rect);

    [StructLayout(LayoutKind.Sequential)]
    private struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    static void Main(string[] args)
    {
        string baseDirectory = @"C:\Users\YouUsers\OneDrive\Desktop\AutoSplitter-Sheepy A Short Adventure\SheepyAutoSplitter";

        string[] Chapters = {
            "The Awakening",
            "Chapter 1 First Steps",
            "Chapter 2 Descent",
            "Chapter 3 Revelation",
            "Chapter 4 Passage of Time",
            "Chapter 5 Purgatory",
            "Chapter 6 Apotheosis"
        };

        string[] referenceImagesPaths = new string[Chapters.Length];
        for (int i = 0; i < Chapters.Length; i++)
        {
            referenceImagesPaths[i] = Path.Combine(baseDirectory, "PicturesSplitForChapters", Chapters[i], "end.png");
        }

        Mat[] referenceImages = new Mat[referenceImagesPaths.Length];
        for (int i = 0; i < referenceImagesPaths.Length; i++)
        {
            referenceImages[i] = Cv2.ImRead(referenceImagesPaths[i], ImreadModes.Color);
            if (referenceImages[i].Empty())
            {
                Console.WriteLine($"Error al cargar la imagen: {referenceImagesPaths[i]}");
                return;
            }
        }

        string startImagePath = Path.Combine(baseDirectory, "UniversalImages", "start.png");
        Mat startImage = Cv2.ImRead(startImagePath, ImreadModes.Color);
        if (startImage.Empty())
        {
            Console.WriteLine($"Error al cargar la imagen: {startImagePath}");
            return;
        }

        string menuImagePath = Path.Combine(baseDirectory, "UniversalImages", "menu.png");
        Mat menuImage = Cv2.ImRead(menuImagePath, ImreadModes.Color);
        if (menuImage.Empty())
        {
            Console.WriteLine($"Error al cargar la imagen: {menuImagePath}");
            return;
        }

        string pauseImagePath = Path.Combine(baseDirectory, "UniversalImages", "pause.png");
        Mat pauseImage = Cv2.ImRead(pauseImagePath, ImreadModes.Color);
        if (pauseImage.Empty())
        {
            Console.WriteLine($"Error al cargar la imagen: {pauseImagePath}");
            return;
        }

        string settingsImagePath = Path.Combine(baseDirectory, "UniversalImages", "settings.png");
        Mat settingsImage = Cv2.ImRead(settingsImagePath, ImreadModes.Color);
        if (settingsImage.Empty())
        {
            Console.WriteLine($"Error al cargar la imagen: {settingsImagePath}");
            return;
        }

        string[] noSplitImagesPaths = {
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit23.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit66.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit3.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit4.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit5.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit6.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit7.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit8.png"),
            Path.Combine(baseDirectory, "NoSplitImages", "noSplit9.png")
        };

        Mat[] noSplitImages = new Mat[noSplitImagesPaths.Length];
        for (int i = 0; i < noSplitImagesPaths.Length; i++)
        {
            noSplitImages[i] = Cv2.ImRead(noSplitImagesPaths[i], ImreadModes.Color);
            if (noSplitImages[i].Empty())
            {
                Console.WriteLine($"Error al cargar la imagen: {noSplitImagesPaths[i]}");
                return;
            }
        }

        Console.WriteLine("Iniciando autosplitter...");
        StartSplitting(referenceImages, startImage, menuImage, pauseImage, settingsImage, noSplitImages, Chapters);
    }
    static void StartSplitting(Mat[] referenceImages, Mat startImage, Mat menuImage, Mat pauseImage, Mat settingsImage, Mat[] noSplitImages, string[] Chapters)
    {
        int currentSplitIndex = 0;
        Thread.Sleep(5000);
        while (currentSplitIndex < referenceImages.Length)
        {
            try
            {
                Mat screenshot = CaptureFullScreen();
                if (screenshot.Empty())
                {
                    Console.WriteLine("Error: No se pudo capturar la pantalla completa.");
                    continue;
                }

                if (IsBlackScreen(screenshot) && !IsNoSplitImage(screenshot, noSplitImages))
                {
                    Console.WriteLine($"¡Pantalla negra detectada para: {Chapters[currentSplitIndex]}!");
                    if (!IsMatch(referenceImages[currentSplitIndex], screenshot, Chapters[currentSplitIndex]))
                    {
                        Console.WriteLine($"No se detectó end.png, usando start.png como respaldo.");
                        if (IsMatch(startImage, screenshot, "start.png") &&
                            !IsMatch(menuImage, screenshot, "menu.png") &&
                            !IsMatch(pauseImage, screenshot, "pause.png") &&
                            !IsMatch(settingsImage, screenshot, "settings.png"))
                        {
                            Console.WriteLine($"¡Split detectado con start.png para: {Chapters[currentSplitIndex]}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"¡Split detectado: {Chapters[currentSplitIndex]}!");
                    }
                    currentSplitIndex++;
                    Thread.Sleep(25000);
                }
                else if (IsMatch(referenceImages[currentSplitIndex], screenshot, Chapters[currentSplitIndex]))
                {
                    Console.WriteLine($"¡Split detectado: {Chapters[currentSplitIndex]}!");
                    currentSplitIndex++;
                    Thread.Sleep(25000);
                }
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        Console.WriteLine("Todos los splits han sido detectados.");
    }

    static Mat CaptureFullScreen()
    {
        try
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            Rect rect;
            if (!GetWindowRect(foregroundWindow, out rect))
            {
                Console.WriteLine("No se pudo obtener el rectángulo de la ventana en primer plano.");
                return new Mat();
            }

            var primaryScreen = System.Windows.Forms.Screen.PrimaryScreen;
            if (primaryScreen == null)
            {
                Console.WriteLine("Error: No se detectó ninguna pantalla principal.");
                return new Mat();
            }

            int screenWidth = primaryScreen.Bounds.Width;
            int screenHeight = primaryScreen.Bounds.Height;

            if (rect.Right - rect.Left == screenWidth && rect.Bottom - rect.Top == screenHeight)
            {
                using (Bitmap screenshot = new Bitmap(screenWidth, screenHeight))
                {
                    using (Graphics g = Graphics.FromImage(screenshot))
                    {
                        g.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                    }
                    Mat screenshotMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(screenshot);
                    return screenshotMat;
                }
            }
            else
            {
                Console.WriteLine("La ventana en primer plano no coincide con la pantalla principal.");
                return new Mat();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error capturando la pantalla completa: {ex.Message}");
            return new Mat();
        }
    }

    static bool IsMatch(Mat referenceImage, Mat screenshot, string chapter)
    {
        try
        {
            Mat grayReference = new Mat();
            Mat grayScreenshot = new Mat();

            Cv2.CvtColor(referenceImage, grayReference, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(screenshot, grayScreenshot, ColorConversionCodes.BGR2GRAY);

            Mat result = new Mat();
            Cv2.MatchTemplate(grayScreenshot, grayReference, result, TemplateMatchModes.CCoeffNormed);

            double maxVal;
            Cv2.MinMaxLoc(result, out _, out maxVal, out _, out _);
            Console.WriteLine($"Nivel de coincidencia para '{chapter}': {maxVal}");
            return maxVal > 0.8;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la comparación de imágenes: {ex.Message}");
            return false;
        }
    }

    static bool IsNoSplitImage(Mat screenshot, Mat[] noSplitImages)
    {
        foreach (var refImage in noSplitImages)
        {
            if (IsMatchWithoutOutput(refImage, screenshot, "No Split Image"))
            {
                return true;
            }
        }
        return false;
    }

    static bool IsMatchWithoutOutput(Mat referenceImage, Mat screenshot, string chapter)
    {
        try
        {
            Mat grayReference = new Mat();
            Mat grayScreenshot = new Mat();

            Cv2.CvtColor(referenceImage, grayReference, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(screenshot, grayScreenshot, ColorConversionCodes.BGR2GRAY);

            Mat result = new Mat();
            Cv2.MatchTemplate(grayScreenshot, grayReference, result, TemplateMatchModes.CCoeffNormed);

            double maxVal;
            Cv2.MinMaxLoc(result, out _, out maxVal, out _, out _);
            return maxVal > 0.8;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la comparación de imágenes: {ex.Message}");
            return false;
        }
    }

    static bool IsBlackScreen(Mat image)
    {
        try
        {
            Mat grayImage = new Mat();
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);

            Mat hist = new Mat();
            int[] histSize = { 256 };
            Rangef[] ranges = { new Rangef(0, 256) };
            Cv2.CalcHist(new Mat[] { grayImage }, new int[] { 0 }, null, hist, 1, histSize, ranges);

            float totalPixels = grayImage.Rows * grayImage.Cols;
            float blackPixels = hist.At<float>(0);
            float darkPixels = 0;

            for (int i = 0; i < 50; i++)
            {
                darkPixels += hist.At<float>(i);
            }

            float blackPercentage = (blackPixels / totalPixels) * 100;
            float darkPercentage = (darkPixels / totalPixels) * 100;

            return darkPercentage > 95;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la detección de pantalla negra: {ex.Message}");
            return false;
        }
    }
}