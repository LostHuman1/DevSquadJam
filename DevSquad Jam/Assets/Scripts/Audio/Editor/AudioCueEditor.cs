using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

[CustomEditor(typeof(AudioSource))]
public class AudioCueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AudioSource audiosource = (AudioSource)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Play Sound"))
        {
            audiosource.Play();
        }
        if (GUILayout.Button("Stop"))
        {
            audiosource.Stop();
        }
    }
    public static void PlayClip(AudioClip clip)
    {
        Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
        Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
        MethodInfo method = audioUtilClass.GetMethod(
            "PlayClip",
            BindingFlags.Static | BindingFlags.Public,
            null,
            new System.Type[] {
         typeof(AudioClip)
        },
        null
        );
        method.Invoke(
            null,
            new object[] {
         clip
        }
        );
    }
    public static void StopAllClips()
    {
        Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
        Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
        MethodInfo method = audioUtilClass.GetMethod(
            "StopAllClips",
            BindingFlags.Static | BindingFlags.Public,
            null,
            new System.Type[] { },
            null
        );
        method.Invoke(
            null,
            new object[] { }
        );
    }
}
