using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine.UI;

namespace EternalWarsWasBetterDiplomacyRandomEventsFix_NativeModloader
{
    public static class Patches
    {
        /*public static bool click_Prefix(WorldLawElement __instance)
        {
            if (Config.isMobile)
            {
                if (!Tooltip.isShowingFor(__instance.button.gameObject))
                {
                    return false;
                }
                Tooltip.hideTooltip();
            }
            World.world.worldLaws.dict[__instance.lawID].boolVal = !World.world.worldLaws.dict[__instance.lawID].boolVal;
            __instance.updateStatus();
            //  if (__instance.lawID == "world_law_diplomacy" && !World.world.worldLaws.dict[__instance.lawID].boolVal)
            //  {
            //      World.world.stopAttacksFor(false);
            //      World.world.wars.stopAllWars();
            //  }
            if (__instance.lawID == "world_law_peaceful_monsters" && World.world.worldLaws.dict[__instance.lawID].boolVal)
            {
                World.world.stopAttacksFor(true);
            }

            return false;

            //     if (Config.isMobile)
            //     {
            //         if (!Tooltip.instance.isShowingFor(button.gameObject))
            //         {
            //             return;
            //         }
            //         Tooltip.hideTooltip();
            //     }
            //     MapBox.instance.worldLaws.dict[lawID].boolVal = !MapBox.instance.worldLaws.dict[lawID].boolVal;
            //     updateStatus();
            //     if (lawID == "world_law_peaceful_monsters" && MapBox.instance.worldLaws.dict[lawID].boolVal)
            //     {
            //         MapBox.instance.stopAttacksFor(pMonsters: true);
            //     }
        }*/

        public static IEnumerable<CodeInstruction> click_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);

            int start = -1;

            int end = -1;

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Is(OpCodes.Ldstr, "world_law_diplomacy"))
                {
                    // Console.WriteLine("FOUND 1");

                    start = i - 2;

                    break;
                }
            }

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Is(OpCodes.Callvirt, AccessTools.Method(typeof(WarManager), nameof(WarManager.stopAllWars))))
                {
                    // /Console.WriteLine("FOUND 2");

                    end = i;

                    break;
                }
            }

            // Console.WriteLine(start);
            // Console.WriteLine(end);
            // 
            // foreach (var item in codes)
            // {
            //     Console.WriteLine($"{item.opcode.Name}   " + item.operand?.ToString());
            // }

            // if (start >= 0 && end >= 0)
            // {
                // codes[start] = new CodeInstruction(OpCodes.Nop);

            codes.RemoveRange(start, end - start + 1);
            // }

            // Console.WriteLine("========================================================================================");
            // Console.WriteLine("========================================================================================");

            // foreach (var item in codes)
            // {
            //     Console.WriteLine($"{item.opcode.Name}   " + item.operand?.ToString());
            // }


            return codes.AsEnumerable();
        }
    }
}
