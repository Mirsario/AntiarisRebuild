using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
	public class AntlionLongbow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 27;
			item.DamageType = DamageClass.Ranged;
			item.width = 40;
			item.height = 76;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 8f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Longbow");
			Tooltip.SetDefault("Shoots out an arrow and a piercing splinter at the same time");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮长弓");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "发射弓箭的同时发射尖刺");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Длинный лук муравьиного льва");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Одновременно выстреливает стрелой и проникающей занозой");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Bow);
		}*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.8f, speedY * 0.8f + 2f, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<BigSplinter>(), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * 0.8f, speedY * 0.8f - 2f, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
