using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris
{
	public class AntiarisMod : Mod
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup.RegisterGroup(
                "Antiaris:SilverBar",
                new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.SilverBar), new int[] {
                    ItemID.SilverBar,
                    ItemID.TungstenBar,
                })
            );
        }
    }
}
