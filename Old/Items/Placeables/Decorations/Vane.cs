using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class Vane : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<Vane>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vane");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "风向标");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Флюгер");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 15)
				.AddTile(16)
				.Register();
		}
	}
}
