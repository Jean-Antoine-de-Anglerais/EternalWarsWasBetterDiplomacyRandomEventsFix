using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace EternalWarsWasBetterDiplomacyRandomEventsFix_NativeModloader
{
    internal class Main : MonoBehaviour
    {
        public static Harmony harmony = new Harmony(MethodBase.GetCurrentMethod().DeclaringType.Namespace);
        private bool _initialized = false;

        public void Update()
        {
            if (global::Config.gameLoaded && !_initialized)
            {
                harmony.Patch(AccessTools.Method(typeof(WorldLawElement), nameof(WorldLawElement.click)),
                transpiler: new HarmonyMethod(AccessTools.Method(typeof(Patches), "click_Transpiler")));

                _initialized = true;
            }
        }
    }
}
