using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class EbonwoodCabinet : ModItem
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
			item.createTile = ModContent.TileType<EbonwoodCabinet>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Cabinet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шкаф из эбеновой древесины");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "乌木柜橱");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Ebonwood, 14)
				.AddTile(106)
				.Register();
		}
	}
}