using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public static class UIHelper
    {
        // Configuração de cores e estilo
        public static readonly ConsoleColor CorTitulo = ConsoleColor.Cyan;
        public static readonly ConsoleColor CorDestaque = ConsoleColor.Yellow;
        public static readonly ConsoleColor CorSelecao = ConsoleColor.Green;
        public static readonly ConsoleColor CorNormal = ConsoleColor.White;
        public static readonly ConsoleColor CorErro = ConsoleColor.Red;
        public static readonly ConsoleColor CorSucesso = ConsoleColor.Blue;
        public static readonly ConsoleColor CorSecundaria = ConsoleColor.DarkGray;

        public static void EscreverColorido(string texto, ConsoleColor cor, bool centralizado = false)
        {
            Console.ForegroundColor = cor;
            if (centralizado)
            {
                int espacos = (Console.WindowWidth - texto.Length) / 2;
                Console.SetCursorPosition(espacos > 0 ? espacos : 0, Console.CursorTop);
            }
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public static void DesenharCabecalho(string titulo)
{
    try
    {
        Console.Clear();
        string borda = new string('═', Math.Min(titulo.Length + 4, Console.WindowWidth - 4));
        
        int windowWidth = Console.WindowWidth;
        int left = (windowWidth - (titulo.Length + 4)) / 2;
        left = Math.Max(0, left);

        Console.SetCursorPosition(left, Math.Max(0, Console.CursorTop));
        EscreverColorido($"╔{borda}╗", CorTitulo);

        Console.SetCursorPosition(left, Math.Max(0, Console.CursorTop));
        EscreverColorido($"║  {titulo}  ║", CorTitulo);

        Console.SetCursorPosition(left, Math.Max(0, Console.CursorTop));
        EscreverColorido($"╚{borda}╝", CorTitulo);
        
        Console.WriteLine("\n");
    }
    catch (Exception)
    {
        // Fallback simples se houver erro no desenho
        Console.Clear();
        EscreverColorido($"=== {titulo} ===\n", CorTitulo);
    }
}

        public static int SelecionarOpcao(List<string> opcoes, string textoVoltar = "Voltar", List<string>? descricoes = null)
        {
            int selecionado = 0;
            int totalOpcoes = opcoes.Count;

            while (true)
            {
                DesenharCabecalho("Selecione uma opção");
                
                for (int i = 0; i < totalOpcoes; i++)
                {
                    if (i == selecionado)
                    {
                        EscreverColorido($"> {opcoes[i]}", CorSelecao);
                        if (descricoes != null && i < descricoes.Count)
                        {
                            EscreverColorido($"   {descricoes[i]}", CorSecundaria);
                        }
                    }
                    else
                    {
                        EscreverColorido($"  {opcoes[i]}", CorNormal);
                    }
                }

                EscreverColorido($"\n  {textoVoltar}", selecionado == totalOpcoes ? CorSelecao : CorSecundaria);

                var key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.UpArrow && selecionado > 0) selecionado--;
                else if (key == ConsoleKey.DownArrow && selecionado < totalOpcoes) selecionado++;
                else if (key == ConsoleKey.Enter) return selecionado < totalOpcoes ? selecionado : -1;
                else if (key == ConsoleKey.Escape) return -1;
            }
        }

        public static bool ConfirmarAcao(string mensagem = "Deseja confirmar esta ação?")
{
    int selecionado = 0;
    string[] opcoes = { "✅ Sim", "❌ Não" };

    // Animação de confirmação
    string[] checkFrames = {
        "[    ]",
        "[=   ]",
        "[==  ]",
        "[=== ]",
        "[ ===]",
        "[  ==]",
        "[   =]",
        "[    ]",
        "[   =]",
        "[  ==]",
        "[ ===]",
        "[====]"
    };

    int frame = 0;
    bool animating = true;

    while (true)
    {
        if (animating)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            EscreverColorido($"{checkFrames[frame]} {mensagem}", CorDestaque);
            frame = (frame + 1) % checkFrames.Length;
        }

        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(intercept: true).Key;
            animating = false;

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            for (int i = 0; i < opcoes.Length; i++)
            {
                if (i == selecionado)
                    EscreverColorido($"{opcoes[i]} ", CorSelecao);
                else
                    Console.Write($"{opcoes[i]} ");
            }

            if (key == ConsoleKey.LeftArrow && selecionado > 0) selecionado--;
            else if (key == ConsoleKey.RightArrow && selecionado < opcoes.Length - 1) selecionado++;
            else if (key == ConsoleKey.Enter) return selecionado == 0;
            else if (key == ConsoleKey.Escape) return false;
        }

        Thread.Sleep(100);
    }
}
    }
}