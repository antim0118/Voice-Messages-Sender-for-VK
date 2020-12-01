using System.Diagnostics;
using System.IO;

namespace VMVK
{
    public static class ffmpeg
    {
        public static void ProcessAudio(string input, string output)
        {
            if (!Settings.ffmpegPathIsValid) return;
            if (File.Exists(output))
                File.Delete(output);
            ProcessStartInfo info = new ProcessStartInfo(Settings.ffmpegPath, $"-y -i \"{input}\" -c:a libopus -b:a 16K -ac 1 \"{output}\"");
            info.UseShellExecute = false;
            info.CreateNoWindow = false;

            Process process = Process.Start(info);
            process.WaitForExit();
        }
    }
}
