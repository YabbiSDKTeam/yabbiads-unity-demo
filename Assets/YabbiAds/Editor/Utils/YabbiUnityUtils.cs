using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace YabbiAds.Unity.Editor.Utils
{
    public class YabbiUnityUtils
    {
        public static int CompareVersions(string v1, string v2)
        {
            var re = new Regex(@"\d+(\.\d+)+");
            var match1 = re.Match(v1);
            var match2 = re.Match(v2);
            return new Version(match1.ToString()).CompareTo(new Version(match2.ToString()));
        }
        public static string GetXcodeVersion()
        {
            string profilerOutput = null;
            try
            {
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo("system_profiler", "SPDeveloperToolsDataType | grep \"Xcode:\"")
                    {
                        CreateNoWindow = false, RedirectStandardOutput = true, UseShellExecute = false
                    }
                };
                p.Start();
                p.WaitForExit();
                profilerOutput = p.StandardOutput.ReadToEnd();
                var re = new Regex(@"Xcode: (?<version>\d+(\.\d+)+)");
                var m = re.Match(profilerOutput);
                if (m.Success) profilerOutput = m.Groups["version"].Value;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
            }

            return profilerOutput;
        }
    }
}