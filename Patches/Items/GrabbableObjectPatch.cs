using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeathKnife.Patches.Items
{
    // Patch GrabbableObject because it is the base class for a shovel
    [HarmonyPatch(typeof(GrabbableObject), "Start")]
    internal class GrabbableObjectPatch
    {
        // Patch start so that we can set shovelHitForce to 3
        public static void Prefix(GrabbableObject __instance)
        {
            // Only run if the instance is a shovel
            if (__instance.GetType() == typeof(KnifeItem))
            {
                KnifeItem knife = __instance as KnifeItem;
                knife.knifeHitForce = Plugin.config.Value;
            }

        }
    }

}
