// using System;
// using System.Diagnostics;
// using System.Collections.Generic;
// using System.Linq;

// namespace Program
// {
//     public class Program
//     {
//         // Configuração de cores e estilo
//         private static readonly ConsoleColor CorTitulo = ConsoleColor.Cyan;
//         private static readonly ConsoleColor CorDestaque = ConsoleColor.Yellow;
//         private static readonly ConsoleColor CorSelecao = ConsoleColor.Green;
//         private static readonly ConsoleColor CorNormal = ConsoleColor.White;
//         private static readonly ConsoleColor CorErro = ConsoleColor.Red;
//         private static readonly ConsoleColor CorSucesso = ConsoleColor.Blue;
//         private static readonly ConsoleColor CorSecundaria = ConsoleColor.DarkGray;

//         public static void EscreverColorido(string texto, ConsoleColor cor, bool centralizado = false)
//         {
//             Console.ForegroundColor = cor;
//             if (centralizado)
//             {
//                 int espacos = (Console.WindowWidth - texto.Length) / 2;
//                 Console.SetCursorPosition(espacos > 0 ? espacos : 0, Console.CursorTop);
//             }
//             Console.WriteLine(texto);
//             Console.ResetColor();
//         }

//         public static void DesenharCabecalho(string titulo)
//         {
//             Console.Clear();
//             string borda = new string('═', titulo.Length + 4);
            
//             EscreverColorido($"╔{borda}╗", CorTitulo, true);
//             EscreverColorido($"║  {titulo}  ║", CorTitulo, true);
//             EscreverColorido($"╚{borda}╝", CorTitulo, true);
//             Console.WriteLine();
//         }

//         public static void MenuCategorias()
//         {
//             Console.Title = "🚀 Super Executor de Programas 🚀";
//             Console.CursorVisible = false;

//             var categorias = new Dictionary<string, List<(string nome, string comando, string descricao)>>()
//             {
//                 {
//                     "🌐 Navegadores", new List<(string, string, string)>
//                     {
//                         ("Firefox", "firefox", "Navegador web de código aberto"),
//                         ("Google Chrome", "google-chrome", "Navegador rápido e seguro do Google"),
//                         ("Chromium", "chromium", "Projeto de código aberto do Chrome"),
//                         ("Tor Browser", "tor-browser", "Navegador para anonimato online")
//                     }
//                 },
//                 {
//                     "💻 Desenvolvimento", new List<(string, string, string)>
//                     {
//                         ("Visual Studio Code", "code", "Editor de código da Microsoft"),
//                         ("LunarVim", "lvim", "IDE Vim moderno"),
//                         ("Vim (Terminal)", "vim", "Editor de texto poderoso"),
//                         ("GVim (Interface Gráfica)", "gvim", "Vim com interface gráfica"),
//                         ("Terminal", "gnome-terminal", "Emulador de terminal GNOME"),
//                         ("Editor Nano", "nano", "Editor de texto simples"),
//                         ("Geany (IDE leve)", "geany", "IDE leve e rápida"),
//                         ("Kate (Editor KDE)", "kate", "Editor avançado do KDE")
//                     }
//                 },
//                 {
//                     "🖼️ Multimídia", new List<(string, string, string)>
//                     {
//                         ("GIMP (Editor de Imagens)", "gimp", "Editor de imagens profissional"),
//                         ("Spotify", "spotify", "Serviço de streaming musical"),
//                         ("VLC Media Player", "vlc", "Reprodutor de mídia versátil"),
//                         ("Rhythmbox", "rhythmbox", "Gerenciador de música do GNOME"),
//                         ("Cheese (Webcam)", "cheese", "Aplicativo para fotos e vídeos com webcam")
//                     }
//                 },
//                 {
//                     "🛠️ Sistema", new List<(string, string, string)>
//                     {
//                         ("Gerenciador de Arquivos (Nautilus)", "nautilus", "Navegador de arquivos do GNOME"),
//                         ("Controle de Áudio (pavucontrol)", "pavucontrol", "Mixer de áudio PulseAudio"),
//                         ("Monitor do Sistema", "gnome-system-monitor", "Visualizador de processos e recursos"),
//                         ("Gerenciador de Tarefas (htop)", "htop", "Monitor de sistema interativo"),
//                         ("Captura de Tela (scrot)", "scrot", "Ferramenta de captura de tela"),
//                         ("Bloco de Notas (Xed)", "xed", "Editor de texto simples"),
//                         ("Gerenciador de Pacotes Synaptic", "synaptic", "Gerenciador gráfico de pacotes"),
//                         ("Configurações do Sistema", "gnome-control-center", "Painel de controle do GNOME"),
//                         ("Terminal Root (pkexec)", "pkexec gnome-terminal", "Terminal com privilégios de root")
//                     }
//                 }
//             };

//             while (true)
//             {
//                 DesenharCabecalho("🌟 MENU PRINCIPAL 🌟");
//                 EscreverColorido("Escolha uma categoria:\n", CorDestaque, true);

//                 var nomesCategorias = categorias.Keys.ToList();
//                 int selecionado = SelecionarOpcao(nomesCategorias, "Voltar");

//                 if (selecionado == -1) return;

//                 var nomeCategoria = nomesCategorias[selecionado];
//                 var programas = categorias[nomeCategoria];

//                 while (true)
//                 {
//                     DesenharCabecalho(nomeCategoria);
//                     EscreverColorido("Escolha um programa:\n", CorDestaque, true);

//                     int programaSelecionado = SelecionarOpcao(
//                         programas.Select(p => p.nome).ToList(),
//                         "Voltar",
//                         programas.Select(p => p.descricao).ToList()
//                     );

//                     if (programaSelecionado == -1) break;

//                     var (nomePrograma, comando, descricao) = programas[programaSelecionado];
                    
//                     DesenharCabecalho(nomePrograma);
//                     EscreverColorido($"📝 Descrição: {descricao}\n", CorNormal);
//                     EscreverColorido("Deseja executar este programa?", CorDestaque);
                    
//                     if (ConfirmarAcao())
//                     {
//                         try
//                         {
//                             EscreverColorido($"\n🚀 Iniciando {nomePrograma}...", CorSucesso);
//                             Process.Start(comando);
//                         }
//                         catch (Exception ex)
//                         {
//                             EscreverColorido($"\n❌ Erro ao abrir {nomePrograma}: {ex.Message}", CorErro);
//                         }
//                     }
//                     else
//                     {
//                         EscreverColorido("\nOperação cancelada.", CorSecundaria);
//                     }

//                     EscreverColorido("\n✅ Pressione qualquer tecla para continuar...", CorSecundaria);
//                     Console.ReadKey();
//                 }
//             }
//         }

//         public static int SelecionarOpcao(List<string> opcoes, string textoVoltar = "Voltar", List<string>? descricoes = null)
//         {
//             int selecionado = 0;
//             int totalOpcoes = opcoes.Count;

//             while (true)
//             {
//                 DesenharCabecalho("Selecione uma opção");
                
//                 for (int i = 0; i < totalOpcoes; i++)
//                 {
//                     if (i == selecionado)
//                     {
//                         EscreverColorido($"> {opcoes[i]}", CorSelecao);
//                         if (descricoes != null && i < descricoes.Count)
//                         {
//                             EscreverColorido($"   {descricoes[i]}", CorSecundaria);
//                         }
//                     }
//                     else
//                     {
//                         EscreverColorido($"  {opcoes[i]}", CorNormal);
//                     }
//                 }

//                 EscreverColorido($"\n  {textoVoltar}", selecionado == totalOpcoes ? CorSelecao : CorSecundaria);

//                 var key = Console.ReadKey(intercept: true).Key;
//                 if (key == ConsoleKey.UpArrow && selecionado > 0) selecionado--;
//                 else if (key == ConsoleKey.DownArrow && selecionado < totalOpcoes) selecionado++;
//                 else if (key == ConsoleKey.Enter) return selecionado < totalOpcoes ? selecionado : -1;
//                 else if (key == ConsoleKey.Escape) return -1;
//             }
//         }

//         public static bool ConfirmarAcao()
//         {
//             int selecionado = 0;
//             string[] opcoes = { "✅ Sim", "❌ Não" };

//             while (true)
//             {
//                 Console.SetCursorPosition(0, Console.CursorTop);
//                 Console.Write(new string(' ', Console.WindowWidth));
//                 Console.SetCursorPosition(0, Console.CursorTop - 1);

//                 for (int i = 0; i < opcoes.Length; i++)
//                 {
//                     if (i == selecionado)
//                         EscreverColorido($"{opcoes[i]} ", CorSelecao);
//                     else
//                         Console.Write($"{opcoes[i]} ");
//                 }

//                 var key = Console.ReadKey(intercept: true).Key;
//                 if (key == ConsoleKey.LeftArrow && selecionado > 0) selecionado--;
//                 else if (key == ConsoleKey.RightArrow && selecionado < opcoes.Length - 1) selecionado++;
//                 else if (key == ConsoleKey.Enter) return selecionado == 0;
//                 else if (key == ConsoleKey.Escape) return false;
//             }
//         }

//         public static void Main(string[] args)
//         {
//             Console.OutputEncoding = System.Text.Encoding.UTF8;
//             Console.CursorVisible = false;

//             try
//             {
//                 MenuCategorias();
//             }
//             catch (Exception ex)
//             {
//                 EscreverColorido($"\n⚠️ Erro inesperado: {ex.Message}", CorErro);
//             }
//             finally
//             {
//                 EscreverColorido("\n👋 Programa finalizado. Até logo!", CorSecundaria);
//                 Console.CursorVisible = true;
//             }
//         }
//     }
// }

