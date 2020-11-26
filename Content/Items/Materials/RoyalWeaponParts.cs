using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Materials
{
	public class RoyalWeaponParts : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.rare = ItemRarityID.Blue;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
    }
}
