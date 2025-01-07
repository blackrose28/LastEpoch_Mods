using HarmonyLib;
using MelonLoader;

namespace LastEpoch_Hud.Scripts.Mods.Character
{
    public class Character_SoulEmber_Multiplier
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

        [HarmonyPatch(typeof(DungeonRunManager), "modifySoulEmberCountOnSingleplayerOrServer")]
        public class DungeonRunManager_modifySoulEmberCountOnSingleplayerOrServer
        {
            [HarmonyPrefix]
            static void Prefix(ref int changeInSoulEmberCount, bool updateVisuals)
            {
                
                if (Scenes.IsGameScene())
                {
                    //Melon<LastEpoch_Hud.Main>.Logger.Msg("modifySoulEmberCountOnSingleplayerOrServer get called: " + changeInSoulEmberCount + " " + updateVisuals.ToString());
                    if (changeInSoulEmberCount > 0) { changeInSoulEmberCount *= 50; }
                }
            }
        }

        [HarmonyPatch(typeof(DungeonRunManager), "modifySoulEmberCountUIAndClientCount")]
        public class DungeonRunManager_modifySoulEmberCountUIAndClientCount
        {
            [HarmonyPrefix]
            static void Prefix(ref int change, bool replaceCountInstead)
            {

                if (Scenes.IsGameScene())
                {
                    //Melon<LastEpoch_Hud.Main>.Logger.Msg("modifySoulEmberCountUIAndClientCount get called: " + change + " " + replaceCountInstead.ToString());
                    if (change > 0) { change *= 50; }
                }
            }
        }

        [HarmonyPatch(typeof(DungeonRunManager), "modifySoulEmberVisualCountFromServerOrSingleplayer")]
        public class DungeonRunManager_modifySoulEmberVisualCountFromServerOrSingleplayer
        {
            [HarmonyPrefix]
            static void Prefix(ref int changeInSoulEmberCount, bool replaceCountInstead)
            {

                if (Scenes.IsGameScene())
                {
                    //Melon<LastEpoch_Hud.Main>.Logger.Msg("modifySoulEmberVisualCountFromServerOrSingleplayer get called: " + changeInSoulEmberCount + " " + replaceCountInstead.ToString());
                    if (changeInSoulEmberCount > 0) { changeInSoulEmberCount *= 50; }
                }
            }
        }
    }
}