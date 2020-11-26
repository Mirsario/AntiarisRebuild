using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Materials
{
	public class NatureEssence : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.maxStack = 999;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.value = Item.sellPrice(0, 0, 4, 0);
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, new Vector3(0.8f, 0.7f, 0.3f) * Main.essScale);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
