using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace VMVK
{
    public static class Settings
    {
        public static string AccessToken = string.Empty;
        public static bool AccessTokenIsValid
        {
            get
            {
                if (AccessToken.Length < 80) return false;
                try
                {
                    var conversations = Program.api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams
                    {
                        Count = 1
                    });
                    if (conversations == null || conversations.Count == 0) return false;
                    return true;
                }
                catch { }
                return false;
            }
        }
        public static string ffmpegPath = string.Empty;
        public static bool ffmpegPathIsValid => File.Exists(ffmpegPath);
        public static bool firstStart = false;

        //working paths
        public static string selectedFile = string.Empty;
        public static string tempPath = Path.Combine(Application.StartupPath, "temp");

        public static string SettingsPath = Path.Combine(Application.StartupPath, "settings.bin");
        public static void Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    using (FileStream FS = File.OpenRead(SettingsPath))
                    using (BinaryReader BR = new BinaryReader(FS, Encoding.ASCII))
                    {
                        int magic = BR.ReadInt32();
                        if (magic != 568493946)
                            throw new Exception("Неверный magic код настроек");

                        //read token
                        ushort count = BR.ReadUInt16();
                        string encrypted = Encoding.ASCII.GetString(BR.ReadBytes(count));
                        AccessToken = Encryptor.Decrypt(encrypted);

                        //read ffmpeg path
                        count = BR.ReadUInt16();
                        ffmpegPath = Encoding.UTF8.GetString(BR.ReadBytes(count));
                    }
                }
                else
                    firstStart = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить настройки:\n" + ex.ToString());
            }

            if (ffmpegPath.Length == 0 || !File.Exists(ffmpegPath))
            {
                string stPath = Path.Combine(Application.StartupPath, "ffmpeg.exe");
                if (File.Exists(stPath))
                    ffmpegPath = stPath;
            }
        }

        public static void Save()
        {
            try
            {
                using (FileStream FS = File.OpenWrite(SettingsPath))
                using (BinaryWriter BW = new BinaryWriter(FS, Encoding.ASCII))
                {
                    BW.Write((int)568493946); //magic

                    //write token
                    string encrypted = Encryptor.Encrypt(AccessToken);
                    byte[] b = Encoding.ASCII.GetBytes(encrypted);
                    BW.Write((ushort)b.Length);
                    BW.Write((byte[])b);

                    //write ffmpeg path
                    b = Encoding.UTF8.GetBytes(ffmpegPath);
                    BW.Write((ushort)b.Length);
                    BW.Write((byte[])b);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить настройки:\n" + ex.ToString());
            }
        }
    }
}
