using System;
using System.IO;
using System.Reflection;
using Base.Build;
using System.Linq;
using PhoenixPoint.Home.View.ViewModules;
using HarmonyLib;

namespace DragonAARevamp
{
    public static class AssortedAdjustments
    {
        internal static string LogPath;
        internal static string ModDirectory;
        internal static Settings Settings;
        internal static string[] ValidPresets = new string[] { "vanilla", "hardcore", "mad" };
        internal static HarmonyInstance Harmony;

        internal static string ModName = "AssortedAdjustments";
        internal static Version ModVersion;



        // Modnix Entrypoints
        public static void SplashMod(Func<string, object, object> api)
        {
            Harmony = HarmonyInstance.Create("de.mad.AssortedAdjustments");

            ModDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogPath = Path.Combine(ModDirectory, "AssortedAdjustments.log");
            Settings = api("config", null) as Settings ?? new Settings();
            
            if ((!String.IsNullOrEmpty(Settings.DebugDevKey) && Settings.DebugDevKey == "mad") || (!String.IsNullOrEmpty(Settings.BalancePresetId) && Settings.BalancePresetId == "mad"))
            {
                Settings.DebugLevel = 3;
            }
            Logger.Initialize(LogPath, Settings.DebugLevel, ModDirectory, nameof(AssortedAdjustments));

            object ModInfo = api("mod_info", null);
            ModVersion = (Version)ModInfo.GetType().GetField("Version").GetValue(ModInfo);



            Logger.Always($"Modnix Mad.AssortedAdjustments.SplashMod initialised.");
            //Logger.Always($"Settings: {Settings}");



            try
            {
                Settings.ToMarkdownFile(Path.Combine(ModDirectory, "settings-reference.md"));
                Settings.ToHtmlFile(Path.Combine(ModDirectory, "settings-reference.htm"));
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }



        public static void MainMod(Func<string, object, object> api)
        {
            try
            {
                DataHelpers.Print();
                Harmony.PatchAll();
                ApplyAll();

                Logger.Always($"Modnix Mad.AssortedAdjustments.MainMod initialised.");
                Logger.Always($"GameVersion: {RuntimeBuildInfo.BuildVersion}");
                Logger.Always($"ModVersion: {ModVersion}");
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }



        public static void ApplyAll()
        {
            if(Settings.EnableEconomyAdjustments)
            {
                Patches.EconomyAdjustments.Apply();
            }

            if (Settings.EnableFacilityAdjustments)
            {
                Patches.FacilityAdjustments.Apply();
            }

            if (Settings.EnableDifficultyOverrides)
            {
                Patches.DifficultyOverrides.Apply();
            }

            if (Settings.UnlockItemsByResearch)
            {
                Patches.UnlockItemsByResearch.Init();
            }
        }



        [HarmonyPatch(typeof(UIModuleBuildRevision), "SetRevisionNumber")]
        public static class UIModuleBuildRevision_SetRevisionNumber_Patch
        {
            public static void Postfix(UIModuleBuildRevision __instance)
            {
                try
                {
                    __instance.BuildRevisionNumber.text = $"{RuntimeBuildInfo.UserVersion} w/{ModName} {ModVersion}";
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }
    }
}
