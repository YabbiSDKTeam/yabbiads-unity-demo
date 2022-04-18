#if UNITY_IOS
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

public class iOSPostProcessBuild
{
    const string k_Description = "Your data will be used to provide you a better and personalized ad experience.";

    [PostProcessBuild(0)]
    public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuildProject)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            string plistPath = pathToBuildProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            plist.ReadFromString(File.ReadAllText(plistPath));
            PlistElementDict root = plist.root;

            // Set the description key-value in the plist:
            root.SetString("NSUserTrackingUsageDescription", k_Description);

            // Set the description key-value in the plist:
            root.SetString("NSLocationWhenInUseUsageDescription", k_Description);

            // Save changes to the plist:
            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
#endif