using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace FontSvgImageSource
{
    public static class RandomAccessStreamExtensions
    {
        public static async Task WriteContentAsync(this IRandomAccessStream stream, string content)
        {
            using (var dataWriter = new DataWriter(stream))
            {
                dataWriter.WriteString(content);
                await dataWriter.StoreAsync();
                await dataWriter.FlushAsync();
                dataWriter.DetachStream();
            }
            stream.Seek(0);
        }

    }


}
