using Terraria.Localization;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class YellowLightbulb : Lightbulb2
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yellow Lightbulb");
			Tooltip.SetDefault("Can be inserted into Nixie Tube to change its color");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "黄色灯泡");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "可以放进数码管改变其颜色");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Жёлтая лампочка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Можно вставить в Газоразрядный индикатор, чтобы изменить его цвет");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 32;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "Lightbulb")
				.AddIngredient(ItemID.Topaz)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
