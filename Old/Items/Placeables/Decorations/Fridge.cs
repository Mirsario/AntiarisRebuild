using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class Fridge : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 38;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<Fridge>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fridge");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "冰箱");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Холодильник");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 12)
				.AddIngredient(ItemID.Wire, 20)
				.AddTile(16)
				.Register();
		}
	}
}