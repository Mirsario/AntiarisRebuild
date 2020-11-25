﻿using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Chests
{
	public class SunkenChest : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 10, 0);
			;
			item.createTile = ModContent.TileType<SunkenChest>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunken Chest");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "沉没的箱子");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Затонувший сундук");
		}
	}
}
