using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace golos
{
    public partial class Form1 : Form
    {

        public static string access_token = "";
        public static string api_url = "https://api.vk.com/method/";

        public Form1()
        {
            InitializeComponent();
        }

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

        public static string VKRequest(string METHOD_NAME, string PARAMETERS = null)
        {
            string url = api_url + METHOD_NAME + "?" + PARAMETERS + "&access_token=" + access_token + "&v=5.69";

            return GetResponse(url);
        }
        #endregion

        #region upload
        public string UploadMultipart(string url, string filepath)
        {
            //инициализация
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            byte[] imagebytearraystring = FileToByteArray(filepath); //переводим в массив байтов
            form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "file", "Document.ogg"); //загружаем как огг файл
            HttpResponseMessage response = httpClient.PostAsync(url, form).Result; //получаем ответ

            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;

            return sd;
        }
        private byte[] FileToByteArray(string fullFilePath)
        {
            FileStream fs = File.OpenRead(fullFilePath);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.TextLength > 50)
            {
                access_token = textBox3.Text; //сохраняем токен в переменную

                string _url_multipart = VKRequest("docs.getMessagesUploadServer", "type=audio_message&peer_id=-100390278"); //запрос ссылки на загрузку
                string url_multipart = _url_multipart.Split(new string[] { "upload_url" }, StringSplitOptions.None)[1].Split('"')[2].Replace(@"\", ""); //чистим запрос, получаем "чистую" ссылку
                OpenFileDialog OPF = new OpenFileDialog(); //просим файл
                OPF.Filter = "Файлы ogg|*.ogg";
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    string filevk = UploadMultipart(url_multipart, OPF.FileName); //загружаем файл и получаем ссылку на файл
                    VKFile vkfile = JsonConvert.DeserializeObject<VKFile>(filevk);

                    string res = VKRequest("docs.save", $"file={vkfile.file}"); //сохраняем файл как документ (его не видно в общем списке)

                    string owner_id = res.Split(new string[] { "owner_id" }, StringSplitOptions.None)[1].Split(',')[0].Split(':')[1]; //получаем твой id
                    string media_id = res.Split(new string[] { "id" }, StringSplitOptions.None)[1].Split(',')[0].Split(':')[1]; //получаем номер документа с голосовухой
                    string sendRes = VKRequest("messages.send", $"peer_id={textBox5.Text}&attachment=doc{owner_id}_{media_id}"); //отправляем сообщение
                    richTextBox3.Text = sendRes;
                }
                else
                {
                    richTextBox3.Text = "не выбран файл";
                }
            }
            else
            {
                richTextBox3.Text = "неправильный токен ¯\\_(ツ)_/¯";
            }
        }

        struct VKFile
        {
            public string file;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "20000000**"; //вставляем циферки в поле ввода диалога
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://vkhost.github.io/");
        }
    }
}
