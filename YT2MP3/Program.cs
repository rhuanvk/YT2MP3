namespace YT2MP3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("##### Conversor de vídeos para .mp3 #####\n");
            Console.WriteLine("Informe a URL do video a ser convertido:");
            
            string url = Console.ReadLine();

            Console.WriteLine("Iniciando download...");
           
            Downloader downloader = new Downloader();
            await downloader.DownloadYoutubeVideo(url);

            Console.WriteLine("Download finalizado. Verifique sua área de trabalho.\n");
            Console.WriteLine("Pressione qualquer tecla para finalizar.");
            Console.WriteLine("#########################################");
            Console.ReadKey();
        }
    }
}
