using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class TV : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<TV>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TV");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "电视机");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Телевизор");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 12)
				.AddIngredient(ItemID.Glass, 10)
				.AddIngredient(ItemID.Wire, 6)
				.AddTile(16)
				.Register();
		}
	}
}
