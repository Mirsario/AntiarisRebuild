﻿using Terraria.Localization;

namespace Antiaris.Items.Quests
{
	public class TheGuideforGuides : QuestItem
	{
		public TheGuideforGuides()
		{
			questItem = true;
			uniqueStack = true;
			maxStack = 1;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 32;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Guide for Guides");
			Tooltip.SetDefault("'Written by A. R. Willow'\n'Contains information to make you the Guide'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Руководство для Гидов");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Написано А. Р. Уиллоу'\n'Содержит информацию, чтобы сделать из вас Гида'");
		}
	}
}
