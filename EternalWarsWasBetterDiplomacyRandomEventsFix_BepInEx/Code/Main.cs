using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace EternalWarsWasBetterDiplomacyRandomEventsFix_BepInEx
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "jean.worldbox.mods.EternalWarsWasBetterDiplomacyRandomEventsFix_BepInEx";
        public const string pluginName = "Eternal Wars Was Better: Diplomacy Random Events Fix";
        public const string pluginVersion = "1.0.0.0";

        public static Harmony harmony = new Harmony(MethodBase.GetCurrentMethod().DeclaringType.Namespace);
        private bool _initialized = false;

        public void Update()
        {
            if (global::Config.gameLoaded && !_initialized)
            {
                harmony.Patch(AccessTools.Method(typeof(WorldLawElement), nameof(WorldLawElement.click)),
                transpiler: new HarmonyMethod(AccessTools.Method(typeof(Patches), nameof(Patches.click_Transpiler))));

                _initialized = true;
            }
        }
    }
}
