using Terraria.Localization;

namespace Antiaris.Items.Quests
{
	public class SpiderMass : QuestItem
	{
		public SpiderMass()
		{
			questItem = true;
			maxStack = 999;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Mass");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蜘蛛分泌物");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Паучья масса");
		}
	}
}
