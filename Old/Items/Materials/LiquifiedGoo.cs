using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
	public class LiquifiedGoo : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.rare = ItemRarityID.Green;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Liquified Goo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "液体凝胶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Жидкая слизь");
		}

		public override void AddRecipes()
		{
			CreateRecipe(3)
				.AddIngredient(ItemID.Bottle, 3)
				.AddIngredient(null, "GreenGoo")
				.AddTile(17)
				.Register();
		}
	}
}
