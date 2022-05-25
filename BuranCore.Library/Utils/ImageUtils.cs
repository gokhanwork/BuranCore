using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Buran.Core.Library.Utils
{
    public class ImageUtils
    {
        public async Task<string> GetImageAsBase64Url(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var bytes = await client.GetByteArrayAsync(url);
                    return "image/jpeg;base64," + Convert.ToBase64String(bytes);
                }
            }
            catch (Exception)
            {

            }
            return string.Empty;
        }

        public async Task<byte[]> GetImageAsBytes(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetByteArrayAsync(url);
            }
        }
    }
}
