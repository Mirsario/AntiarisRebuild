﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Flails
{
	public class TheBuccaneersBuster : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 54;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 40;
			item.useTime = 40;
			item.shootSpeed = 13f;
			item.knockBack = 7f;
			item.width = 48;
			item.height = 42;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<TheBuccaneersBuster>();
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
			item.channel = true;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Buccaneer's Buster");
			Tooltip.SetDefault("Enemies hit has a chance to drop more money\nHitting an enemy has a chance to release an exploding big bone");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пиратский разрушитель");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Попадание по врагу дает шанс получить больше монет\nПопадание по врагу дает шанс выпустить взрывную большую кость");
		}
	}
}
