using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Content.Items.Materials
{
	public class BlueBigCrystal : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 24;
			item.value = Item.sellPrice(0, 0, 3, 10);
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Big Crystal");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Большой голубой кристалл");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蓝水晶");
		}
	}
}
