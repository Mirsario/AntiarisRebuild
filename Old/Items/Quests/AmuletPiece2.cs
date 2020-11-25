using Terraria.Localization;

namespace Antiaris.Items.Quests
{
	public class AmuletPiece2 : QuestItem
	{
		public AmuletPiece2()
		{
			questItem = true;
			uniqueStack = true;
			maxStack = 1;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amulet Piece");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "护身符碎片");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Часть амулета");
		}
	}
}
