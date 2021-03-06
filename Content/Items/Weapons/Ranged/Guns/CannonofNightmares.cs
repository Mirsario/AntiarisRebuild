﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class CannonofNightmares : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 21;
			item.DamageType = DamageClass.Ranged;
			item.width = 70;
			item.height = 40;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.shootSpeed = 20f;
			item.value = Item.sellPrice(0, 2, 10, 0);
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cannon of Nightmares");
			Tooltip.SetDefault("Has a chance to shoot out a rocket");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "梦魇加农炮");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "开火时有概率发射火箭");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пушка кошмаров");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Имеет шанс выстрелить ракетой");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(5) == 0)
			{
				type = 134;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}
	}
}
