using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

namespace FVM_VK
{
    public class mm
    {
        #region responses
        public static string GetResponse(string url)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }

        public static string VKRequest(string access_token, string METHOD_NAME, string PARAMETERS = null)
        {
            string api_url = "https://api.vk.com/method/";
            string version = "5.70";
            string url = api_url + METHOD_NAME + "?" + PARAMETERS + "&access_token=" + access_token + "&v=" + version;

            Thread.Sleep(30);

            return GetResponse(url);
        }
        #endregion
        #region UploadMultipart
        public static string ffp = Application.StartupPath + "/temp" + $".wav";
        public static string UploadMultipart(string url, string filepath, string extension)
        {
            //инициализация
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            byte[] imagebytearraystring = FileToByteArray(filepath); //переводим в массив байтов
            form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "file", $"Document{extension}"); //загружаем как огг файл
            HttpResponseMessage response = httpClient.PostAsync(url, form).Result; //получаем ответ

            if (File.Exists(ffp))
                File.Delete(ffp);

            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;

            return sd;
        }
        #endregion

        private static byte[] FileToByteArray(string fullFilePath)
        {
            /*FileStream fs = File.OpenRead(fullFilePath);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;*/
            File.Copy(fullFilePath, fullFilePath + "222");
            byte[] b = File.ReadAllBytes(fullFilePath + "222");
            File.Delete(fullFilePath + "222");
            return b;
        }
    }
}
