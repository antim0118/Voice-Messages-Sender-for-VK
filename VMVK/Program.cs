using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace VMVK
{
    static class Program
    {
        static VkNet.VkApi _api = new VkNet.VkApi();
        public static VkNet.VkApi api
        {
            get
            {
                _api.Authorize(new VkNet.Model.ApiAuthParams
                {
                    AccessToken = Settings.AccessToken
                });
                return _api;
            }
        }

        public const int refreshRate = 60;
        public const float step = 0.1f;

        public static MainForm mainForm;

        [STAThread]
        static void Main()
        {
            Settings.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }

        public static string UploadMultipart(string url, string filepath)
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            byte[] file = File.ReadAllBytes(filepath);
            form.Add(new ByteArrayContent(file, 0, file.Length), "file", Path.GetFileName(filepath)); //загружаем как огг файл (или нет)
            HttpResponseMessage response = httpClient.PostAsync(url, form).Result; //отправляем и получаем ответ

            httpClient.Dispose();
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
