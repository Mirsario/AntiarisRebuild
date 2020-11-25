using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class BrokenHeavenlyClock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Heavenly Clock");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сломанные райские часы");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 28;
			item.rare = ItemRarityID.Cyan;
			item.maxStack = 1;
		}
	}
}
