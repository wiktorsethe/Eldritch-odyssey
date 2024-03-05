using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildLinuxServer
{
    [MenuItem("Build/Build Server (Linux)")]
    public static void BuildServer()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/Preloader.unity" };
        buildPlayerOptions.locationPathName = "Builds/Linux/Server/Server.x86_64";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.subtarget = (int)(StandaloneBuildSubtarget.Server);

        Console.WriteLine("Building Server (Linux)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Server (Linux).");
    }
}
