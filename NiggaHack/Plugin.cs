using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using NiggaHack.Framework;
using NiggaHack.Framework.Elements;
using static NiggaHack.Framework.Elements.Textures;
using PlayFab.ClientModels;
using NiggaHack.Framework.Helpers;
using UnityEngine.UIElements;

namespace NiggaHack
{
    public struct Metadata
    {
        public const string GUID = "com.rxin.NiggaHack";
        public const string Name = "NiggaHack";
        public const string Version = "1.0.1";
    }

    [BepInPlugin(Metadata.GUID, Metadata.Name, Metadata.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        public static Font LabelFont;

        void Awake()
        {
            base.Logger.LogInfo("Loading...");

            var harmony = new Harmony(Metadata.GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            base.Logger.LogInfo("Loaded.");
        }

        void Update()
        {

        }

        void OnGUI()
        {
            Textures.SetupTextures();
            Textures.ApplyTextures();

            if (Time.time >= Settings.ToggleDelay + .1f && GameInput.GetKey(KeyCode.Insert))
            {
                Settings.ToggleDelay = Time.time;
                Settings.Toggled = !Settings.Toggled;
            }
            if (Settings.Toggled)
            {
                Settings.WindowRect = GUI.Window(1, Settings.WindowRect, StartMenu, "");
            }
        }

        void StartMenu(int ___)
        {
            GUI.DrawTexture(new Rect(0f, 0f, Settings.WindowRect.width, Settings.WindowRect.height), windowTexture, ScaleMode.StretchToFill, false, 0f, BackgroundColor, Vector4.zero, new Vector4(6f, 6f, 6f, 6f));
            GUI.DrawTexture(new Rect(0f, 0f, 100f, Settings.WindowRect.height), sidePannelTexture, ScaleMode.StretchToFill, false, 0f, BackgroundColor, Vector4.zero, new Vector4(6f, 0f, 0f, 6f));
            GUI.DragWindow(new Rect(0, 0, Settings.WindowRect.width, 20));


            // Draw Title
            if (LabelFont == null)
            {
                LabelFont = Font.CreateDynamicFontFromOSFont("Gill Sans Nova", 16);
            }

            GUIStyle LabelStyle = new GUIStyle(GUI.skin.label);
            LabelStyle.font = LabelFont;
            GUI.Label(new Rect(12f, 5f, Settings.WindowRect.width, 30f), "Niggahack", LabelStyle);

            // Draw Tabs
            GUILayout.BeginArea(new Rect(7.5f, 30f, 100f, Settings.WindowRect.height));
            GUILayout.BeginVertical();
            for (int i = 0; i < Settings.Tabs.Length; i++)
            {
                GUILayout.Space(5f);
                
            }
        }
    }
}
