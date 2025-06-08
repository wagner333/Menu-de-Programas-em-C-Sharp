using System;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            try
            {
                // Mostra a animação de entrada
                ASCIIArt.MostrarAnimacaoInicio();
                
                // Mostra o logo
                Console.Clear();
                ASCIIArt.MostrarLogo();
                
                // Mostra loading
                ASCIIArt.MostrarLoading();
                
                // Inicia o menu principal
                MenuManager.MenuCategorias();
            }
            catch (Exception ex)
            {
                UIHelper.EscreverColorido($"\n⚠️ Erro inesperado: {ex.Message}", UIHelper.CorErro);
            }
            finally
            {
                UIHelper.EscreverColorido("\n👋 Programa finalizado. Até logo!", UIHelper.CorSecundaria);
                Console.CursorVisible = true;
            }
        }
    }
}