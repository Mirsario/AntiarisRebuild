using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class TerraBlunderbuss : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void SetDefaults()
		{
			item.damage = 53;
			item.width = 86;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 14;
			item.crit = item.crit + 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4f;
			item.DamageType = DamageClass.Ranged;
			item.value = Item.sellPrice(0, 30, 15, 10);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 11f;
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra Blunderbuss");
			Tooltip.SetDefault("Uses buckshots as ammo\nHigh shot speed\nHas a chance to shoot a Terra buckshot that increases ranged damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мушкетон Терры");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nВысокая скорость выстрелов\nИмеет шанс выпустить картечь Терры, которая увеличит дальний урон");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "泰拉火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火铳弹当做弹药\n2、有概率同时发射能够增加远程伤害的泰拉之弹");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			if (Main.rand.Next(3) == 0)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 1.4f, speedY * 1.4f, ModContent.ProjectileType<TrueBuckshot3>(), damage + 15, knockBack + 2.0f, player.whoAmI);
			}
			else
			{
				if (Main.rand.Next(2) == 0)
					Projectile.NewProjectile(position.X, position.Y - 5f, speedX * 1.2f, speedY * 1.2f, type, damage, knockBack, player.whoAmI);
				else
					Projectile.NewProjectile(position.X - 19f * player.direction, position.Y + 7f, speedX, speedY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "TrueHighRoller", 1)
				.AddIngredient(null, "TrueHallowedBlunderbuss", 1)
				.AddTile(134)
				.Register();
		}
	}
}
