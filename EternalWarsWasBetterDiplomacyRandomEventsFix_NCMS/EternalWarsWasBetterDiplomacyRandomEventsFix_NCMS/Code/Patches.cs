using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace EternalWarsWasBetterDiplomacyRandomEventsFix_NCMS
{
    public static class Patches
    {
        public static IEnumerable<CodeInstruction> click_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            int start = -1;

            int end = -1;

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Is(OpCodes.Ldstr, "world_law_diplomacy"))
                {
                    start = i - 2;

                    break;
                }
            }

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Is(OpCodes.Callvirt, AccessTools.Method(typeof(WarManager), nameof(WarManager.stopAllWars))))
                {
                    end = i;

                    break;
                }
            }

            codes.RemoveRange(start, end - start + 1);

            return codes.AsEnumerable();
        }
    }
}
