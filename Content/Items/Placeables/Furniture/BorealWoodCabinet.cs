using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Placeables.Furniture
{
	public class BorealWoodCabinet : ModItem
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
			item.useStyle = ItemUseStyleID.Swing;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 0, 50);
			item.createTile = Mod.Find<ModTile>(nameof(Tiles.Furniture.BorealWoodCabinet)).Type;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boreal Wood Cabinet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шкаф из северной древесины");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "北地木柜橱");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BorealWood, 14)
				.AddTile(106)
				.Register();
		}
	}
}
