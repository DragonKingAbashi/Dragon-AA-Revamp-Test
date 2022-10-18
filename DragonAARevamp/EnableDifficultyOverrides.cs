﻿using System;
using System.Linq;
using Base.Core;
using Base.Defs;
using Harmony;
using HarmonyLib;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Geoscape.Entities;
using PhoenixPoint.Geoscape.Entities.Sites;

namespace DragonAARevamp
{
    internal static class DifficultyOverrides
    {
        public static void Apply()
        {
            DefRepository defRepository = GameUtl.GameComponent<DefRepository>();

            foreach (GameDifficultyLevelDef def in defRepository.DefRepositoryDef.AllDefs.OfType<GameDifficultyLevelDef>())
            {
                def.StartingSupplies = DragonAARevamp.Settings.DifficultyOverrideStartingSupplies;
                def.StartingMaterials = DragonAARevamp.Settings.DifficultyOverrideStartingMaterials;
                def.StartingTech = DragonAARevamp.Settings.DifficultyOverrideStartingTech;
                def.SoldierSkillPointsPerMission = DragonAARevamp.Settings.DifficultyOverrideSoldierSkillPointsPerMission;
                def.ExpConvertedToSkillpoints = DragonAARevamp.Settings.DifficultyOverrideExpConvertedToSkillpoints;
                def.MinPopulationThreshold = DragonAARevamp.Settings.DifficultyOverrideMinPopulationThreshold;

                Logger.Info($"[DifficultyOverrides_Apply] def: {def.name}, GUID: {def.Guid}, StartingSupplies: {def.StartingSupplies}, StartingMaterials: {def.StartingMaterials}, StartingTech: {def.StartingTech}, SoldierSkillPointsPerMission: {def.SoldierSkillPointsPerMission}, ExpConvertedToSkillpoints: {def.ExpConvertedToSkillpoints}, MinPopulationThreshold: {def.MinPopulationThreshold}");
            }

            foreach (GeoHavenDef def in defRepository.DefRepositoryDef.AllDefs.OfType<GeoHavenDef>())
            {
                def.StarvationDeathsPart = DragonAARevamp.Settings.DifficultyOverrideStarvationDeathsPart;
                def.StarvationMistDeathsPart = DragonAARevamp.Settings.DifficultyOverrideStarvationMistDeathsPart;
                def.StarvationDeathsFlat = DragonAARevamp.Settings.DifficultyOverrideStarvationDeathsFlat;
                def.StarvationMistDeathsFlat = DragonAARevamp.Settings.DifficultyOverrideStarvationMistDeathsFlat;

                Logger.Info($"[DifficultyOverrides_Apply] def: {def.name}, GUID: {def.Guid}, StarvationDeathsPart: {def.StarvationDeathsPart}, StarvationMistDeathsPart: {def.StarvationMistDeathsPart}, StarvationDeathsFlat: {def.StarvationDeathsFlat}, StarvationMistDeathsFlat: {def.StarvationMistDeathsFlat}");
            }

            foreach (GeoMistGeneratorDef def in defRepository.DefRepositoryDef.AllDefs.OfType<GeoMistGeneratorDef>())
            {
                def.KmPerHour = DragonAARevamp.Settings.DifficultyOverrideMistExpansionRate;

                Logger.Info($"[DifficultyOverrides_Apply] def: {def.name}, GUID: {def.Guid}, KmPerHour: {def.KmPerHour}");
            }
        }



        // Havens don't lose population at all (essentially stopping the population census apart from destroying havens) 
        [HarmonyPatch(typeof(GeoHaven), "GetDyingPopulation")]
        public static class GeoHaven_GetDyingPopulation_Patch
        {

            public static void Postfix(GeoHaven __instance, HavenZonesStats.HavenOnlyOutput output, ref int __result)
            {
                try
                {
                    Logger.Debug($"[GeoHaven_GetDyingPopulation_POSTFIX] Disable death by starvation.");

                    Logger.Info($"[GeoHaven_GetDyingPopulation_POSTFIX] Haven: {__instance.Site.LocalizedSiteName}, Population: {__instance.Population}, Food: {output.Food}");
                    Logger.Info($"[GeoHaven_GetDyingPopulation_POSTFIX] Saving {__result} people");

                    __result = 0;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }
    }
}
