using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YT2MP3
{
    internal class Downloader
    {
        public async Task DownloadYoutubeVideo(string url)
        {

            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            
            Console.WriteLine($"Convertendo o aúdio do vídeo: {video.Title}");

            string tituloFormatado = string.Join("", video.Title.Split(Path.GetInvalidFileNameChars()));
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var manifestoStream = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var audioStream = manifestoStream
                .GetAudioOnlyStreams()
                .Where(s => s.Container == Container.Mp4)
                .GetWithHighestBitrate();

            try
            {
                await youtube.Videos.Streams.DownloadAsync(audioStream, $"{dir}\\{tituloFormatado}.mp3");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
