using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace LastEpoch_Hud.Scripts.Mods.Skills
{
    public class Skills_SigilOfHope
    {
        //public static bool CanRun()
        //{
        //    if ((Scenes.IsGameScene()) && (!Save_Manager.instance.IsNullOrDestroyed()))
        //    {
        //        if (!Save_Manager.instance.data.IsNullOrDestroyed())
        //        {
        //            return Save_Manager.instance.data.Character.Cheats.Enable_ExperienceMultiplier;
        //        }
        //        else { return false; }
        //    }
        //    else { return false; }
        //}

        [HarmonyPatch(typeof(SigilsOfHopeMutator), "OnAbilityUse")]
        public class SigilsOfHopeMutator_OnAbilityUse
        {
            [HarmonyPrefix]
            static void Prefix(ref SigilsOfHopeMutator __instance, AbilityInfo abilityInfo, AbilityMutator mutator, float manaCost, Vector3 targetLocation, bool instantCast)
            {

                if (Scenes.IsGameScene())
                {
                    //Melon<LastEpoch_Hud.Main>.Logger.Msg("SigilsOfHopeMutator OnAbilityUse get called: " + __instance.addedDuration);
                    if (__instance.addedDuration < 3600)
                    {
                        __instance.addedDuration += 3600;
                    }
                }
            }
        }
    }
}