using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class GildedCannon : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 23;
			item.DamageType = DamageClass.Ranged;
			item.width = 74;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 3;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6f;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Cannon");
			Tooltip.SetDefault("Fires a spread of bullets\nAlso shoots out close ranged golden ember");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "镀金大炮");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、发射散弹\n2、同时发射一个近距离的金色余烬");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Позолоченная пушка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает шестью пулями за раз\nТакже выстреливает золотым угольком близкого действия");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.6f, speedY * 0.6f, ModContent.ProjectileType<Projectiles.Ranged.AmberShot>(), damage, knockBack + 2.0f, player.whoAmI);
			float numberProjectiles = 6;

			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));

				(speedX, speedY) = (perturbedSpeed.X, perturbedSpeed.Y);

				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}

			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}
	}
}
