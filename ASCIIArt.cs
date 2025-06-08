using System;
using System.Threading;

namespace Program
{
    public static class ASCIIArt
    {
       public static void MostrarAnimacaoInicio()
{
    try
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;

        string[] rocketFrames = {
            "     ▲     ",
            "    / \\    ",
            "   /   \\   ",
            "  /_____\\  ",
            "  |     |  ",
            "  |     |  ",
            "  |     |  ",
            " /| | | |\\ ",
            "/ | | | | \\"
        };

        string[] stars = {
            "  *    *     *   ",
            "    *      *     ",
            "  *         *    ",
            "      *         *",
            "*          *     ",
            "    *         *  "
        };

        for (int i = 0; i < 15; i++)
        {
            Console.Clear();
            
            // Posição segura para as estrelas
            int starTop = Math.Max(0, Console.WindowHeight / 2 - 10);
            
            foreach (var starLine in stars)
            {
                Console.SetCursorPosition(
                    Math.Max(0, (Console.WindowWidth - starLine.Length) / 2),
                    Math.Min(starTop++, Console.WindowHeight - 1)
                );
                Console.WriteLine(starLine);
            }

            // Posição segura para o foguete
            int rocketTop = Math.Max(0, Console.WindowHeight / 2 - rocketFrames.Length / 2);
            
            for (int j = 0; j < rocketFrames.Length; j++)
            {
                Console.SetCursorPosition(
                    Math.Max(0, Console.WindowWidth / 2 - rocketFrames[j].Length / 2),
                    Math.Min(rocketTop + j, Console.WindowHeight - 1)
                );
                Console.WriteLine(rocketFrames[j]);
            }

            if (i < 10)
            {
                Console.SetCursorPosition(
                    Math.Max(0, Console.WindowWidth / 2 - 7),
                    Math.Min(Console.WindowHeight / 2 + 5, Console.WindowHeight - 1)
                );
                Console.WriteLine($"Iniciando em {10 - i}...");
            }

            Thread.Sleep(100);
        }
    }
    catch
    {
        // Fallback se a animação falhar
        Console.Clear();
        Console.WriteLine("🚀 Iniciando programa...");
        Thread.Sleep(1000);
    }
    finally
    {
        Console.ResetColor();
        Console.Clear();
    }
}

        public static void MostrarLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] logo = {
                "  _____                       _____               _             ",
                " / ____|                     |  __ \\             | |            ",
                "| (___  _   _ _ __   ___ _ __| |__) |___  ___ ___| |_ _ __ ___  ",
                " \\___ \\| | | | '_ \\ / _ \\ '__|  _  // _ \\/ __/ _ \\ __| '__/ _ \\ ",
                " ____) | |_| | |_) |  __/ |  | | \\ \\  __/\\__ \\  __/ |_| | | (_) |",
                "|_____/ \\__,_| .__/ \\___|_|  |_|  \\_\\___||___/\\___|\\__|_|  \\___/ ",
                "              | |                                                  ",
                "              |_|                                                  "
            };

            foreach (var line in logo)
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void MostrarLoading(int duracaoSegundos = 2)
        {
            Console.CursorVisible = false;
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(duracaoSegundos);

            string[] frames = { "|", "/", "-", "\\" };
            int frameIndex = 0;

            while (DateTime.Now < end)
            {
                Console.Write($"\rCarregando {frames[frameIndex]}");
                frameIndex = (frameIndex + 1) % frames.Length;
                Thread.Sleep(100);
            }

            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.CursorVisible = true;
        }
    }
}