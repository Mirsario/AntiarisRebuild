using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class QuillPenStand : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<QuillPenStand>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quill-Pen Stand");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "羽毛笔笔座");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Перо на подставке");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddIngredient(ItemID.StoneBlock, 5)
				.AddIngredient(ItemID.Feather, 1)
				.AddTile(18)
				.Register();
		}
	}
}