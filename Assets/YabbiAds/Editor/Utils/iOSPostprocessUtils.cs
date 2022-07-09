#if UNITY_IOS
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

#pragma warning disable 618

namespace YabbiAds.Unity.Editor.Utils
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnusedParameter.Local")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "Unity.IncorrectMethodSignature")]
    public class iOSPostprocessUtils : MonoBehaviour
    {
        private const string suffix = ".framework";

        private const string minVersionToEnableBitcode = "12.0";


        private static readonly string[] frameworkList =
        {
            "CoreLocation",
            "UIKit",
        };

        private static readonly string[] weakFrameworkList =
        {
            "WebKit",
            "AppTrackingTransparency"
        };

        private static readonly string[] platformLibs =
        {
            "libc++.dylib",
            "libz.dylib",
            "libsqlite3.dylib",
            "libxml2.2.dylib"
        };

        [PostProcessBuild(45)] 
        private static void PreparePodfile(BuildTarget target, string buildPath)
        {
            using var sw = File.AppendText(buildPath + "/Podfile");
            sw.WriteLine("source 'https://github.com/YabbiSDKTeam/CocoaPods'");
            sw.WriteLine(@"post_install do |installer|
    installer.pods_project.targets.each do |target|
        target.build_configurations.each do |config|
            config.build_settings['BUILD_LIBRARY_FOR_DISTRIBUTION'] = 'YES'
        end
    end
end");
        }

        [PostProcessBuild(41)]
        public static void updateInfoPlist(BuildTarget buildTarget, string buildPath)
        {
            var path = Path.Combine(buildPath, "Info.plist");
            AddNSUserTrackingUsageDescription(path);
            AddNSLocationWhenInUseUsageDescription(path);
        }

        public static void PrepareProject(string buildPath)
        {
            Debug.Log("preparing your xcode project for yabbi");
            var projectPath = PBXProject.GetPBXProjectPath(buildPath);
            var project = new PBXProject();

            project.ReadFromString(File.ReadAllText(projectPath));

#if UNITY_2019_3_OR_NEWER
            var target = project.GetUnityMainTargetGuid();
            var unityFrameworkTarget = project.GetUnityFrameworkTargetGuid();
#else
             var target = project.TargetGuidByName("Unity-iPhone");
#endif

            AddProjectFrameworks(frameworkList, project, target, false);
            AddProjectFrameworks(weakFrameworkList, project, target, true);
            AddProjectLibs(platformLibs, project, target);
            project.AddBuildProperty(target, "OTHER_LDFLAGS", "-ObjC");

            var xcodeVersion = YabbiUnityUtils.GetXcodeVersion();
            if (xcodeVersion == null ||
                YabbiUnityUtils.CompareVersions(xcodeVersion, minVersionToEnableBitcode) >= 0)
            {
                project.SetBuildProperty(target, "ENABLE_BITCODE", "YES");
            }
            else
            {
                project.SetBuildProperty(target, "ENABLE_BITCODE", "NO");
            }

            project.AddBuildProperty(target, "LIBRARY_SEARCH_PATHS", "$(SRCROOT)/Libraries");
            project.AddBuildProperty(target, "LIBRARY_SEARCH_PATHS", "$(TOOLCHAIN_DIR)/usr/lib/swift/$(PLATFORM_NAME)");
#if UNITY_2019_3_OR_NEWER
            project.AddBuildProperty(target, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
            project.AddBuildProperty(unityFrameworkTarget, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "NO");
#else
             project.AddBuildProperty(target, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
#endif
            project.AddBuildProperty(target, "LD_RUNPATH_SEARCH_PATHS", "@executable_path/Frameworks");
            project.SetBuildProperty(target, "SWIFT_VERSION", "5.0");

            File.WriteAllText(projectPath, project.WriteToString());
        }

        private static void AddProjectFrameworks(IEnumerable<string> frameworks, PBXProject project, string target,
            bool weak)
        {
            foreach (var framework in frameworks)
            {
                if (!project.ContainsFramework(target, framework))
                {
                    project.AddFrameworkToProject(target, framework + suffix, weak);
                }
            }
        }

        private static void AddProjectLibs(IEnumerable<string> libs, PBXProject project, string target)
        {
            foreach (var lib in libs)
            {
                var libGUID = project.AddFile("usr/lib/" + lib, "Libraries/" + lib, PBXSourceTree.Sdk);
                project.AddFileToBuild(target, libGUID);
            }
        }


        private static void AddNSUserTrackingUsageDescription(string path)
        {
            // if (!YabbiSettings.Instance.NSUserTrackingUsageDescription) return;
            // if (!CheckContainsKey(path, "NSUserTrackingUsageDescription"))
            // {
            AddKeyToPlist(path, "NSUserTrackingUsageDescription",
                "$(PRODUCT_NAME)" + " " +
                "needs your advertising identifier to provide personalised advertising experience tailored to you.");
            // }
        }

        private static void AddNSLocationWhenInUseUsageDescription(string path)
        {
            // if (!YabbiSettings.Instance.NSLocationWhenInUseUsageDescription) return;
            // if (!CheckContainsKey(path, "NSLocationWhenInUseUsageDescription"))
            // {
            AddKeyToPlist(path, "NSLocationWhenInUseUsageDescription",
                "$(PRODUCT_NAME)" + " " +
                "needs your location for analytics and advertising purposes.");
            // }
        }

        private static void AddKeyToPlist(string path, string key, string value)
        {
            var plist = new PlistDocument();
            plist.ReadFromFile(path);
            plist.root.SetString(key, value);
            File.WriteAllText(path, plist.WriteToString());
        }
    }
}
#endif