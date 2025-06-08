using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Program
{
    public class MenuManager
    {
        private static readonly Dictionary<string, List<(string nome, string comando, string descricao)>> Categorias = new()
        {
            {
                "🌐 Navegadores", new List<(string, string, string)>
                {
                    ("Firefox", "firefox", "Navegador web de código aberto"),
                    ("Google Chrome", "google-chrome", "Navegador rápido e seguro do Google"),
                    ("Chromium", "chromium", "Projeto de código aberto do Chrome"),
                    ("Tor Browser", "tor-browser", "Navegador para anonimato online")
                }
            },
            {
                "💻 Desenvolvimento", new List<(string, string, string)>
                {
                     ("Eclipse", "/home/wagner/eclipse/java-2024-09/eclipse/eclipse", "IDE Java popular"),
                    ("Rider", "rider", "IDE da JetBrains para .NET (pasta RiderProjects presente)"),
                    ("Visual Studio Code", "code", "Editor de código da Microsoft"),
                    ("LunarVim", "lvim", "IDE Vim moderno"),
                    ("Vim (Terminal)", "vim", "Editor de texto poderoso"),
                    ("GVim (Interface Gráfica)", "gvim", "Vim com interface gráfica"),
                    ("Terminal", "gnome-terminal", "Emulador de terminal GNOME"),
                    ("Editor Nano", "nano", "Editor de texto simples"),

                }
            },
            {
                "🖼️ Multimídia", new List<(string, string, string)>
                {
                    ("GIMP (Editor de Imagens)", "gimp", "Editor de imagens profissional"),
                    ("Spotify", "spotify", "Serviço de streaming musical"),
                    ("VLC Media Player", "vlc", "Reprodutor de mídia versátil"),
                    ("Rhythmbox", "rhythmbox", "Gerenciador de música do GNOME"),
                    ("Cheese (Webcam)", "cheese", "Aplicativo para fotos e vídeos com webcam")
                }
            },
            {
                "🛠️ Sistema", new List<(string, string, string)>
                {
                    ("Gerenciador de Arquivos (Nautilus)", "nautilus", "Navegador de arquivos do GNOME"),
                    ("Controle de Áudio (pavucontrol)", "pavucontrol", "Mixer de áudio PulseAudio"),
                    ("Monitor do Sistema", "gnome-system-monitor", "Visualizador de processos e recursos"),
                    ("Gerenciador de Tarefas (htop)", "htop", "Monitor de sistema interativo"),
                    ("Captura de Tela (scrot)", "scrot", "Ferramenta de captura de tela"),
                    ("Bloco de Notas (Xed)", "xed", "Editor de texto simples"),
                    ("Gerenciador de Pacotes Synaptic", "synaptic", "Gerenciador gráfico de pacotes"),
                    ("Configurações do Sistema", "gnome-control-center", "Painel de controle do GNOME"),
                    ("Terminal Root (pkexec)", "pkexec gnome-terminal", "Terminal com privilégios de root")
                }
            },
              {
                "🎮 Jogos", new List<(string, string, string)>
                {
                    ("Roblox", "flatpak run org.vinegarhq.Sober", "Plataforma de jogos online"),
                    ("Steam", "steam", "Plataforma de jogos digitais"),
                    ("ProtonUp-Qt", "protonup-qt", "Gerenciador de versões do Proton"),
                    ("Minecraft", "minecraft-launcher", "Jogo sandbox de construção"),
                    ("Wine", "winecfg", "Camada de compatibilidade para Windows")
                }
            },
        };

        public static void MenuCategorias()
        {
            Console.Title = "🚀 Super Executor de Programas 🚀";
            Console.CursorVisible = false;

            while (true)
            {
                UIHelper.DesenharCabecalho("🌟 MENU PRINCIPAL 🌟");
                UIHelper.EscreverColorido("Escolha uma categoria:\n", UIHelper.CorDestaque, true);

                var nomesCategorias = Categorias.Keys.ToList();
                int selecionado = UIHelper.SelecionarOpcao(nomesCategorias, "Voltar");

                if (selecionado == -1) return;

                var nomeCategoria = nomesCategorias[selecionado];
                var programas = Categorias[nomeCategoria];

                GerenciarProgramasDaCategoria(nomeCategoria, programas);
            }
        }

        private static void GerenciarProgramasDaCategoria(string nomeCategoria, List<(string nome, string comando, string descricao)> programas)
        {
            while (true)
            {
                UIHelper.DesenharCabecalho(nomeCategoria);
                UIHelper.EscreverColorido("Escolha um programa:\n", UIHelper.CorDestaque, true);

                int programaSelecionado = UIHelper.SelecionarOpcao(
                    programas.Select(p => p.nome).ToList(),
                    "Voltar",
                    programas.Select(p => p.descricao).ToList()
                );

                if (programaSelecionado == -1) break;

                ExecutarProgramaSelecionado(programas[programaSelecionado]);
            }
        }

        private static void ExecutarProgramaSelecionado((string nome, string comando, string descricao) programa)
        {
            UIHelper.DesenharCabecalho(programa.nome);
            UIHelper.EscreverColorido($"📝 Descrição: {programa.descricao}\n", UIHelper.CorNormal);
            UIHelper.EscreverColorido("Deseja executar este programa?", UIHelper.CorDestaque);
            
            if (UIHelper.ConfirmarAcao())
            {
                try
                {
                    UIHelper.EscreverColorido($"\n🚀 Iniciando {programa.nome}...", UIHelper.CorSucesso);
                    Process.Start(programa.comando);
                }
                catch (Exception ex)
                {
                    UIHelper.EscreverColorido($"\n❌ Erro ao abrir {programa.nome}: {ex.Message}", UIHelper.CorErro);
                }
            }
            else
            {
                UIHelper.EscreverColorido("\nOperação cancelada.", UIHelper.CorSecundaria);
            }

            UIHelper.EscreverColorido("\n✅ Pressione qualquer tecla para continuar...", UIHelper.CorSecundaria);
            Console.ReadKey();
        }
    }
}