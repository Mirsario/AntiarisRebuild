using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Materials
{
	public class BloodyChargedCrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 10, 0);
        }
    }
}
