using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildScript
{
    #region Public Methods
    [MenuItem("Build/Build Client (WebGL)")]
    public static void BuildWebGLClient()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "Builds/WebGL/Client";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        Console.WriteLine("Building Client (WebGL)...");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Console.WriteLine("Built Client (WebGL).");
    }
    #endregion
}