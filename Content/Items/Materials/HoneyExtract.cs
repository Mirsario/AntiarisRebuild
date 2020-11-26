using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Materials
{
	public class HoneyExtract : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = ItemRarityID.Orange;
            item.maxStack = 999;
            item.consumable = true;
            item.buffType = BuffID.Honey;
            item.buffTime = 900;
            item.useAnimation = 15;
            item.useTime = 15;
            item.UseSound = SoundID.Item2;
            item.useStyle = ItemUseStyleID.EatFood;
        }
    }
}
