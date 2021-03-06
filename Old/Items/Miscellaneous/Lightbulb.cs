﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class Lightbulb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightbulb");
			Tooltip.SetDefault("Can be colored with gems\nColored lightbulbs are used to change Nixie Tubes color");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "灯泡");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、可以使用宝石染色\n2、染色灯泡可以使数码管改变其颜色");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Лампочка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Можно изменить цвет при помощи драгоценных камней\nЦветные лампочки используются для изменения цвета Газоразрядных индикаторов");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 32;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 0, 50, 0);
		}
	}
}
