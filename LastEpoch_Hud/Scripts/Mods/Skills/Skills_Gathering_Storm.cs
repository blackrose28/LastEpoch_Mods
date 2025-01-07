using HarmonyLib;
using MelonLoader;

namespace LastEpoch_Hud.Scripts.Mods.Skills
{
    public class Skill_GatheringStorm
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

        [HarmonyPatch(typeof(GatheringStorm1Mutator), "OnMinionHitGatheringStorm")]
        public class GatheringStorm1Mutator_OnMinionHitGatheringStorm
        {
            [HarmonyPrefix]
            static void Prefix(ref GatheringStorm1Mutator __instance, Summoned summon, Ability _ability, Actor target, AT tags, bool crit, bool kill)
            {
                if (Scenes.IsGameScene())
                {
                    //Melon<LastEpoch_Hud.Main>.Logger.Msg("OnUpdateTick get called: " + summon.name + " ability: " + _ability.name + " " + target.name + " " + tags.ToString() + " " + crit.ToString() + " " + kill.ToString() + ". Storm stacks:" + __instance.stormStacks);
                    if (_ability.name == "PrimalLightning" && __instance.stormStacks < 10)
                    {
                        __instance.stormStacks = 10;
                    }
                }
            }
        }
    }
}