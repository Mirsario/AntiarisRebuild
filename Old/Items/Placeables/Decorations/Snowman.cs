using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class Snowman : ModItem
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
			item.createTile = ModContent.TileType<Snowman>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowman");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "雪人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Снеговик");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SnowBlock, 20)
				.AddTile(18)
				.Register();
		}
	}
}
