using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
	public class VampiricEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 36;
			item.rare = ItemRarityID.Yellow;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 25, 0);
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampiric Essence");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "嗜血元素");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Вампирическая эссенция");
		}
	}
}
