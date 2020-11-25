using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Miscellaneous
{
	public class EmptyOxygenTank : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 34;
			item.maxStack = 20;
			item.value = Item.sellPrice(0, 0, 2, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empty Oxygen Tank");
			Tooltip.SetDefault("Must be filled using the Compressor");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "空氧气罐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "也许需要使用压缩器装填氧气");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пустой бак");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Может быть наполнен кислородом через компрессор");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 5)
				.AddTile(TileID.HeavyWorkBench)
				.Register();
		}
	}
}
