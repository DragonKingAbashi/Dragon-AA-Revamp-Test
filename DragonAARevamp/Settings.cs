using System;
using System.Collections.Generic;
using System.Reflection;
using PhoenixPoint.Modding;

namespace DragonAARevamp
{
    internal class Settings
    {

        [ConfigField("Disables the rock tiles in phoenix bases completely.", "True")]
        public bool DisableRocksAtBases = true;
        [ConfigField("Will only show the confirmation popup when moving a unit to the evacuation zone if the whole squad is ready to evacuate. You can still evacuate single units by using the ability bar.", "True")]
        public bool EnableSmartEvacuation = true;
        [ConfigField("Will preselect the closest phoenix base to the screen's center when entering the bases menu at the bottom.", "True")]
        public bool EnableSmartBaseSelection = true;
        [ConfigField("If an aircraft is completely empty you can scrap it from the roster list.", "True")]
        public bool EnableScrapAircraft = true;

        [ConfigField("Adds various items to the agenda tracker above the time controller.", "True", true, "UX Enhancements")]
        public bool EnableExtendedAgendaTracker = true;
        [ConfigField("Adds vehicle-related entries (travel and exploration times) to the agenda tracker", "True")]
        public bool AgendaTrackerShowVehicles = true;
        [ConfigField("Adds excavation-related entries (excavation times) to the agenda tracker", "True")]
        public bool AgendaTrackerShowExcavations = true;
        [ConfigField("Adds incoming base defense missions to the agenda tracker", "True")]
        public bool AgendaTrackerShowBaseDefenses = true;
        [ConfigField("Hides status bar. This shows 'timed events' (excavation and base defense countdowns) in vanilla and is not needed when the items are displayed in the tracker", "False")]
        public bool AgendaTrackerHideStatusBar = false;
        [ConfigField("Adds a secondary objective to take control of a recently excavated site", "True")]
        public bool AgendaTrackerAddMissionObjective = true;

        [ConfigField("General switch to enable the related subfeatures.", "True", true, "UI Enhancements")]
        public bool EnableUIEnhancements = true;
        [ConfigField("Shows current production and research points behind the facility count and adds some related information to the manufacturing and research screens.", "True")]
        public bool ShowDetailedResearchAndProduction = true;
        [ConfigField("Shows personal abilities and augmentations (if any) of recruits in havens.", "True")]
        public bool ShowRecruitInfoInsideZoneTooltip = true;
        [ConfigField("Adds current healing rates to the bases tooltip in geoscape. Adds tooltips to the left-hand side menu in the bases screen and the bases info in recruitment screen.", "True")]
        public bool ShowExtendedBaseInfo = true;
        [ConfigField("Adds trade information and recruit class/level to the haven popups.", "True")]
        public bool ShowExtendedHavenInfo = true;
        
        [ConfigField("General switch to enable the related subfeatures.", "True", true, "Item Unlocks")]
        public bool UnlockItemsByResearch = true;
        [ConfigField("Unlocks phoenix elite gear created from the redeemable 'gold' items by adjusting their stats, adding damage types and add manufacturing costs. These will show up once certain research requirements are met.", "True")]
        public bool UnlockPhoenixEliteGear = true;
        [ConfigField("Unlocks living weapons for manufacturing. These will show up once certain research requirements are met. Will NOT check for the completion of the related missions.", "False")]
        public bool UnlockLivingWeapons = false;
        [ConfigField("Unlocks living armor for manufacturing. These will show up once certain research requirements are met. Will NOT check for the completion of the related missions.", "False")]
        public bool UnlockLivingArmor = false;
        [ConfigField("Unlocks independent ammunition items after basic research is completed. QOL for the early game.", "True")]
        public bool UnlockIndependentAmmunition = true;
        [ConfigField("Unlocks independent weapons items after basic research is completed. If you wish to clutter up your manufacturing list.", "False")]
        public bool UnlockIndependentWeapons = false;
        [ConfigField("Unlocks independent armor items after basic research is completed. If you wish to clutter up your manufacturing list.", "False")]
        public bool UnlockIndependentArmor = false;
        [ConfigField("Unlocks hidden items after basic research is completed. If you wish to clutter up your manufacturing list.", "False")]
        public bool UnlockHiddenItems = false;

        [ConfigField("Override some difficulty settings", "True", true, "Difficulty")]
        public bool EnableDifficultyOverrides = true;
        [ConfigField("Amount of supplies you'll start the game with, vanilla defaults: { Easy: 800, Standard: 500, Hard: 300, VeryHard: 200 }", "800")]
        public float DifficultyOverrideStartingSupplies = 800f;
        [ConfigField("Amount of materials you'll start the game with, vanilla defaults: { Easy: 1000, Standard: 700, Hard: 500, VeryHard: 400 }", "1000")]
        public float DifficultyOverrideStartingMaterials = 1000f;
        [ConfigField("Amount of tech you'll start the game with, vanilla defaults: { Easy: 200, Standard: 150, Hard: 100, VeryHard: 80 }", "200")]
        public float DifficultyOverrideStartingTech = 200f;
        [ConfigField("How much flat skill points each alive soldier will get, vanilla defaults: { Easy: 12, Standard: 10, Hard: 8, VeryHard: 5 }", "12")]
        public int DifficultyOverrideSoldierSkillPointsPerMission = 12;
        [ConfigField("How much of total experience will be converted to PX skill points, vanilla defaults: { Easy: 0.02, Standard: 0.015, Hard: 0.01, VeryHard: 0.01 }", "0.02")]
        public float DifficultyOverrideExpConvertedToSkillpoints = 0.02f;
        [ConfigField("How much geoscape population (% of starting) must drop to reach game over, vanilla defaults: { Easy: 5, Standard: 10, Hard: 15, VeryHard: 20 }", "5")]
        public int DifficultyOverrideMinPopulationThreshold = 5;
        [ConfigField("How much % of starving population at a haven will die each day, vanilla default is 0.01 (1%)", "0.01")]
        public float DifficultyOverrideStarvationDeathsPart = 0.01f;
        [ConfigField("How much % of starving population at a haven will die each day if in mist, vanilla default is 0.03 (3%)", "0.03")]
        public float DifficultyOverrideStarvationMistDeathsPart = 0.03f;
        [ConfigField("Additional deaths of starving population at a haven each day, vanilla default is 5", "5")]
        public int DifficultyOverrideStarvationDeathsFlat = 5;
        [ConfigField("Additional deaths of starving population at a haven each day if in mist, vanilla default is 15", "15")]
        public int DifficultyOverrideStarvationMistDeathsFlat = 15;
        [ConfigField("Completely disable population reduction by starvation. Only haven destructions will drop the bar.", "False")]
        public bool DifficultyOverrideDisableDeathByStarvation = false;
        [ConfigField("Mist expansion rate in kilometres per hour, vanilla default is 30", "30")]
        public int DifficultyOverrideMistExpansionRate = 30;
        
        [ConfigField("Fully leveled soldiers will convert some experience to skill points. Base rate is dependent on difficulty setting, somewhere between 1 and 2 percent.", "True", true, "Progression")]
        public bool EnableExperienceToSkillpointConversion = true;
        [ConfigField("Will add the converted skill points to the soldier's pool.", "False")]
        public bool XPtoSPAddToPersonalPool = false;
        [ConfigField("Will add the converted skill points to the faction's pool.", "True")]
        public bool XPtoSPAddToFactionPool = true;
        [ConfigField("Will multiply the converted skill points by its value.", "2")]
        public float XPtoSPConversionMultiplier = 2f;
        internal float XPtoSPConversionRate = 0.01f; // Default is dependent on difficulty setting, this is just a fallback if the setting is unretrievable.

        [ConfigField("General switch to enable the related subfeatures", "True", true, "Facility modifications")]
        public bool EnableFacilityAdjustments = true;
        // Healing
        [ConfigField("Healing rate for medical bays, vanilla default is 4", "8")]
        public float MedicalBayBaseHeal = 8f;
        [ConfigField("Stamina regeneration rate for living quarters, vanilla default is 2", "4")]
        public float LivingQuartersBaseStaminaHeal = 4f;
        [ConfigField("Healing rate for aircraft at vehicle bays, vanilla default is 48", "60")]
        public int VehicleBayAircraftHealAmount = 60;
        [ConfigField("Healing rate for vehicles at vehicle bays, vanilla default is 20", "40")]
        public int VehicleBayVehicleHealAmount = 40;
        [ConfigField("Healing rate for mutogs at mutation labs, vanilla default is 20", "40")]
        public int MutationLabMutogHealAmount = 40;
        //Training
        [ConfigField("Experience gain rate per hour for soldiers at training facilities, vanilla default is 2", "2")]
        public int TrainingFacilityBaseExperienceAmount = 2;
        [ConfigField("Enables training facilities to add skillpoints to the faction pool. This is currently disabled in vanilla.", "True")]
        public bool TrainingFacilitiesGenerateSkillpoints = true;
        [ConfigField("Global skillpoints gain rate per day per facility, vanilla default is 1. Needs the above flag set to true!", "1")]
        public int TrainingFacilityBaseSkillPointsAmount = 1;
        // Resource Generators
        [ConfigField("Production points generated at fabrication plants, vanilla default is 4", "4")]
        public float FabricationPlantGenerateProductionAmount = 4f;
        [ConfigField("Research points generated at research labs, vanilla default is 4", "4")]
        public float ResearchLabGenerateResearchAmount = 4f;
        [ConfigField("Supplies (Food) generated at food production facilities, vanilla default is 0.33 (translates to 8 food/day).", "0.5")]
        public float FoodProductionGenerateSuppliesAmount = 0.5f;
        [ConfigField("Research points generated at bionic labs, vanilla default is 4", "4")]
        public float BionicsLabGenerateResearchAmount = 4f;
        [ConfigField("Mutagen points generated at mutation labs, vanilla default is 0.25 (translates to 6 mutagen/day).", "0.25")]
        public float MutationLabGenerateMutagenAmount = 0.25f;
        // Add Tech & Materials to Facilities
        [ConfigField("Fabrication plant generate this amount of materials per day.", "1")]
        public float FabricationPlantGenerateMaterialsAmount = 1f;
        [ConfigField("Research labs generate this amount of tech per day.", "1")]
        public float ResearchLabGenerateTechAmount = 1f;
        internal float GenerateResourcesBaseDivisor = 24f;

        [ConfigField("General switch to enable the related subfeatures.", "True", true, "Economy")]
        public bool EnableEconomyAdjustments = true;
        [ConfigField("General multiplier for manufacturing costs.", "0.75")]
        public float ResourceMultiplier = 0.75f;
        [ConfigField("General multiplier for scrapping costs, vanilla default is 0.5", "0.5")]
        public float ScrapMultiplier = 0.5f;
        [ConfigField("General multiplier for manufacturing times.", "0.5")]
        public float CostMultiplier = 0.5f;

        [ConfigField("Suppresses the 'Nothing found' event when exploring sites.", "True")]
        public bool DisableNothingFound = true;

        [ConfigField("Keeps the game paused/pauses the game when setting a new target for an aircraft.", "True", true, "Pause and Center")]
        public bool PauseOnDestinationSet = true;
        [ConfigField("Keeps the game paused/pauses the game when exploring a new site.", "False")]
        public bool PauseOnExplorationSet = false;
        [ConfigField("Pauses the game when new recruits have arrived at phoenix bases.", "True")]
        public bool PauseOnRecruitsGenerated = true;
        [ConfigField("Pauses the game when a squad is fully rested.", "True")]
        public bool PauseOnHealed = true;
        internal bool CenterOnHealed = true;
        [ConfigField("Centers view on the haven that was just discovered.", "True")]
        public bool CenterOnHavenRevealed = true;
        [ConfigField("Centers view on the ancient site that was just excavated.", "True")]
        public bool CenterOnExcavationComplete = true;
        internal bool CenterOnVehicleArrived = true;

        [ConfigField("Enables some logging if errors occur", "True", true, "Do not touch")]
        public bool Debug = true;
        internal int DebugLevel = 1;
        [ConfigField("Magical setting that allows the developer to trigger code for personal use.", "")]
        public string DebugDevKey = "";
        public int PresetStateHash = -1;

        public bool Equals(Settings obj)
        {
            Type t = this.GetType();
            Type o = obj.GetType();

            if (t != o)
            {
                return false;
            }

            FieldInfo[] tFields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
            //FieldInfo[] oFields = o.GetFields(BindingFlags.Instance | BindingFlags.Public);


            foreach (FieldInfo fi in tFields)
            {
                if (fi.Name == "BalancePresetId" || fi.Name == "BalancePresetState" || fi.Name == "DebugDevKey"|| fi.Name == "PresetStateHash")
                {
                    continue;
                }

                object tValue = fi.GetValue(this);
                object oValue = fi.GetValue(obj);
                Logger.Info($"[Settings_Equals] {fi.Name}: {tValue} <-> {oValue}");

                if (!tValue.Equals(oValue))
                {
                    return false;
                }
            }

            return true;
        }



        public override string ToString()
        {
            string result = "";
            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo fi in fields)
            {
                result += "\n";
                result += fi.Name;
                result += ": ";
                result += fi.GetValue(this).ToString();
            }
            return result;
        }



        public void ToHtmlFile(string destination)
        {
            string result = "<!doctype html><html lang=en><head><meta charset=utf-8><title>Assorted Adjustments: Settings</title><style>html {font-family: sans-serif;} body {padding:2em;} h1 {padding-left: 10px;} th {font-size:1.4em;}</style></head><body>\n";
            result += "<h1>SETTINGS</h1>\n";

            result += "<table cellpadding=0 cellspacing=10>\n";
            result += $"<tr><th align=left>Name</th><th align=left>Value</th><th align=left>Description</th><th align=right>Default</th></tr>\n";

            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                Annotation annotation = Attribute.IsDefined(fi, typeof(Annotation)) ? (Annotation)Attribute.GetCustomAttribute(fi, typeof(Annotation)) : null;

                string settingName = fi.Name;
                string setValue = fi.GetValue(this).ToString();
                string settingDesc = annotation?.Description;
                string defaultValue = annotation?.DefaultValue;

                if (annotation?.DefaultValue != null && setValue != defaultValue)
                {
                    setValue = $"<b>{setValue}</b>";
                }

                if (annotation != null && annotation.StartSection)
                {
                    result += $"<tr><td colspan=4><br><b>{annotation.SectionLabel}</b></td></tr>\n";
                }

                result += "<tr><td>";
                result += $" {settingName} ";
                result += "</td><td>";
                result += $" {setValue} ";
                result += "</td><td>";
                result += $" {settingDesc} ";
                result += "</td><td align=right>";
                result += $" <i>{defaultValue}</i> ";
                result += "</td></tr>\n";
            }
            result += "</table></body></html>";

            System.IO.File.WriteAllText(destination, result);
        }



        public void ToMarkdownFile(string destination)
        {
            string result = "";
            result += "# SETTINGS";
            result += "\n\n";

            result += $"|Name|Value|Description|Default|\n";
            result += $"|:---|:----|:----------|:-----:|\n";

            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                Annotation annotation = Attribute.IsDefined(fi, typeof(Annotation)) ? (Annotation)Attribute.GetCustomAttribute(fi, typeof(Annotation)) : null;

                string settingName = fi.Name;
                string setValue = fi.GetValue(this).ToString();
                string settingDesc = annotation?.Description;
                string defaultValue = annotation?.DefaultValue;

                if (annotation?.DefaultValue != null && setValue != defaultValue)
                {
                    setValue = $"<b>{setValue}</b>";
                }

                if (annotation != null && annotation.StartSection)
                {
                    result += $"| . | . | . | . |\n";
                    result += $"| . | . | . | . |\n";
                    result += $"| . | . | . | . |\n";
                    result += $"| <b>{annotation.SectionLabel}</b> | | | |\n";
                }

                result += "|";
                result += $" {settingName} ";
                result += "|";
                result += $" {setValue} ";
                result += "|";
                result += $" {settingDesc} ";
                result += "|";
                result += $" <i>{defaultValue}</i> ";
                result += "|\n";
            }

            System.IO.File.WriteAllText(destination, result);
        }
    }
}
