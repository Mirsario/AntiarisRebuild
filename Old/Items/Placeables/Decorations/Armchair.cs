using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class Armchair : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 42;
			item.height = 32;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.createTile = ModContent.TileType<Armchair>();
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armchair");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "扶手椅");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 15)
				.AddIngredient(ItemID.Silk, 6)
				.AddTile(106)
				.Register();
		}
	}
}
