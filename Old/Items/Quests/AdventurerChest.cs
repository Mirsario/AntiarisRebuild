using Terraria.Localization;

namespace Antiaris.Items.Quests
{
	public class AdventurerChest : QuestItem
	{
		public AdventurerChest()
		{
			questItem = true;
			uniqueStack = true;
			maxStack = 1;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adventurer's Chest");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "冒险家的箱子");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сундучок Путешественника");
		}
	}
}
