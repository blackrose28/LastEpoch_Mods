using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace LastEpoch_Hud.Scripts.Mods.Items
{
    [RegisterTypeInIl2Cpp]
    public class Items_Crafting_Eternity_Anywhere : MonoBehaviour
    {
        public static Items_Crafting_Eternity_Anywhere instance { get; private set; }
        public Items_Crafting_Eternity_Anywhere(System.IntPtr ptr) : base(ptr) { }

        private static bool isLegendaryCrafting = false;

        void Awake()
        {
            instance = this;
        }
        void Update()
        {
            if ((Scenes.IsGameScene()) && (!Refs_Manager.game_uibase.IsNullOrDestroyed()) &&
                (Input.GetKeyDown(Save_Manager.instance.data.KeyBinds.EternityCache)))
            {
                var panel = Refs_Manager.EternityCachePanelUI;

                panel.gameObject.active = !panel.gameObject.active;
                if (panel.gameObject.active)
                {
                    panel.Open();
                    isLegendaryCrafting = true;
                    var unique = Refs_Manager.EternityCachePanelUI.beforeMain.Container.GetContent()[0].data;
                    var exalted = Refs_Manager.EternityCachePanelUI.beforeOther.Container.GetContent()[0].data;
                    unique.absorb4ModExaltedItemToBecomeLegendary(exalted);
                }
                else
                {
                    panel.Close();
                    isLegendaryCrafting = false;
                }
            }
        }

        [HarmonyPatch(typeof(EternityCachePanelUI), "seal")]
        public class EternityCachePanelUI_seal
        {
            [HarmonyPrefix]
            static bool Prefix(ref EternityCachePanelUI __instance)
            {
                if (isLegendaryCrafting)
                {
                    var unique = __instance.beforeMain.Container.GetContent()[0].data;
                    var exalted = __instance.beforeOther.Container.GetContent()[0].data;
                    if (unique.IsNullOrDestroyed() || exalted.IsNullOrDestroyed()) { return false; }
                    unique.absorb4ModExaltedItemToBecomeLegendary(exalted);
                    return true;
                }
                else { return false; }
            }
        }
    }
}
