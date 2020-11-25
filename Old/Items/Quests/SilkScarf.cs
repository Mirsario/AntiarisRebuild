using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Quests
{
	[AutoloadEquip(EquipType.Neck)]
	public class SilkScarf : QuestItem
	{
		public SilkScarf()
		{
			questItem = true;
			uniqueStack = true;
			maxStack = 1;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 30;
			item.accessory = true;
			item.vanity = true;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silk Scarf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "丝绸围巾");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шёлковый шарф");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Silk, 10)
				.AddTile(86)
				.Register();
		}
	}
}
