using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class Globe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 46;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<Globe>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Globe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "地球仪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Глобус");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Antiaris:GoldBar", 5)
				.AddTile(16)
				.Register();
		}
	}
}
