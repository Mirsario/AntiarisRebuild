using Terraria.Localization;

namespace Antiaris.Items.Quests
{
	public class StolenPresent : QuestItem
	{
		public StolenPresent()
		{
			questItem = true;
			maxStack = 999;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stolen Present");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "偷来的礼物");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Украденный подарок");
		}
	}
}
