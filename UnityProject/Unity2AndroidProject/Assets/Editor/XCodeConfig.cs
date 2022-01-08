using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public class XCodeConfig
{
    [PostProcessBuild]
    private static void OnBuildFinish(BuildTarget buildTarget, string buildPath)
    {
        Debug.Log($"构建成功:{buildTarget},路径:{buildPath}");

#if UNITY_IPHONE || UNITY_IOS
        SetXCodeProject(buildPath);
#endif
    }
    
    public static void SetXCodeProject(string buildPath)
    {
        PBXProject project = new PBXProject();

        var srcPath = PBXProject.GetPBXProjectPath(buildPath);
        var src = File.ReadAllText(srcPath);
        var plistPath = Path.Combine(buildPath, "Info.plist");
        var plistText = File.ReadAllText(plistPath);
        
        project.ReadFromString(src);

        string targetGuid = project.GetUnityMainTargetGuid();
        //添加一个库
        project.AddFrameworkToProject(targetGuid, "AVKit.framework", false);
        //添加一个权限
        PlistDocument plist = new PlistDocument();
        plist.ReadFromString(plistText);
        
        //https://www.jianshu.com/p/901725508629  查看权限字段
        plist.root.SetString("NSCameraUsageDescription","SF请求相机权限");
        
        //写入
        plist.WriteToFile(plistPath);
        project.WriteToFile(srcPath);
    }
}
