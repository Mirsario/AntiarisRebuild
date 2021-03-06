using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class PalmWoodCabinet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 0, 50);
			item.createTile = ModContent.TileType<PalmWoodCabinet>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Cabinet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шкаф из пальмовой древесины");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "棕榈木柜橱");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PalmWood, 14)
				.AddTile(106)
				.Register();
		}
	}
}