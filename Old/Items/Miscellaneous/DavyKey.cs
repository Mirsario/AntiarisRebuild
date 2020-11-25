using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
	public class DavyKey : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 30;
			item.rare = ItemRarityID.Green;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 2, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Davy's Key");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ключ Дэйви");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BrokenDavyKey")
				.AddRecipeGroup("Antiaris:DemoniteBar", 10)
				.AddIngredient(ItemID.Sapphire, 4)
				.AddIngredient(null, "TranquilityElement")
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}