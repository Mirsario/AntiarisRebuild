using Terraria.ID;
using Terraria.Localization;

namespace Antiaris.Items.Quests
{
	public class GoldenApple : QuestItem
	{
		public GoldenApple()
		{
			questItem = true;
			uniqueStack = true;
			maxStack = 1;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Apple");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "金苹果");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Золотое яблоко");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GoldCoin, 20)
				.AddIngredient(null, "Apple", 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
