using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class GreenBigCrystal : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = Item.sellPrice(0, 0, 3, 10);
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Big Crystal");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Большой зеленый кристалл");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "绿水晶");
		}
	}
}
