using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class Blunderbee : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 17;
			item.DamageType = DamageClass.Ranged;
			item.width = 60;
			item.height = 38;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 0, 65, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blunderbee");
			Tooltip.SetDefault("Uses buckshots as ammo\nAlso shoots out bees");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蜜蜂火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火铳弹当做弹药\n2、同时也发射蜜蜂");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пчелотон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nТакже выстреливает пчёлами");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			short bee = ProjectileID.Bee;

			if (player.strongBees && Main.rand.Next(3) == 0)
			{
				bee = ProjectileID.GiantBee;
				damage += damage / 5;
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			for (int i = 0; i < 2; i++)
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, bee, damage, knockBack, player.whoAmI);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.BeeWax, 8)
				.AddIngredient(ItemID.Stinger, 5)
				.AddTile(18)
				.Register();
		}
	}
}
