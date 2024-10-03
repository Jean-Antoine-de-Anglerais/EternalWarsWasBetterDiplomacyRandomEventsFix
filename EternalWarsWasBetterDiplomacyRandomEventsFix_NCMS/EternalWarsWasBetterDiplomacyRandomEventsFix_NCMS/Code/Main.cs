using HarmonyLib;
using NCMS;
using System.Reflection;
using UnityEngine;

namespace EternalWarsWasBetterDiplomacyRandomEventsFix_NCMS
{
    [ModEntry]
    class Main : MonoBehaviour
    {
        public static Harmony harmony = new Harmony(MethodBase.GetCurrentMethod().DeclaringType.Namespace);

        void Awake()
        {
            harmony.Patch(AccessTools.Method(typeof(WorldLawElement), nameof(WorldLawElement.click)),
            transpiler: new HarmonyMethod(AccessTools.Method(typeof(Patches), nameof(Patches.click_Transpiler))));
        }
    }
}
