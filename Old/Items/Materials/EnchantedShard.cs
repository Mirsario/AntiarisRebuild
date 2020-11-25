using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
	public class EnchantedShard : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Green;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Shard");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "附魔石碎片");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зачарованный осколок");
		}

		public override void AddRecipes()
		{
			CreateRecipe(14)
				.AddIngredient(ItemID.EnchantedSword)
				.AddTile(16)
				.Register();

			CreateRecipe(10)
				.AddIngredient(ItemID.EnchantedBoomerang)
				.AddTile(16)
				.Register();
		}
	}
}
