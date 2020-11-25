using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class HeatBlaster : ModItem
	{
		/*public override void HoldItem(Player player)
		{
			if (Main.dayTime)
			{
				AntiarisGlowMask2.AddGlowMask(Mod.ItemType(GetType().Name), "Antiaris/Glow/HeatBlaster_GlowMask");
			}
			else
			{
				AntiarisGlowMask2.AddGlowMask(Mod.ItemType(GetType().Name), "Antiaris/Glow/HeatBlaster2_GlowMask");
			}
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			if (Main.dayTime)
			{
				AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, Mod.GetTexture("Glow/HeatBlaster_GlowMask"), rotation, scale);
			}
			else
			{
				AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, Mod.GetTexture("Glow/HeatBlaster2_GlowMask"), rotation, scale);
			}
		}*/

		public override void SetDefaults()
		{
			item.damage = 31;
			item.width = 52;
			item.height = 28;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.knockBack = 2;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 22f;
			item.DamageType = DamageClass.Ranged;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heat Blaster");
			Tooltip.SetDefault("Uses bullets as ammo\n<right> to launch a flare");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Бластер нагреватель");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует пули в качестве патронов\n<right>, чтобы выстрелить сигнальной ракетой");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "炙炎冲击波");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用子弹作为弹药\n2、 <right> 发射信号弹");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}

			if (player.altFunctionUse == 2)
			{
				if (Main.dayTime)
				{
					type = 163;
				}
				else
				{
					type = 310;
				}
			}
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.Shoot;
				item.knockBack = 0;
				item.damage = 13;
				item.UseSound = SoundID.Item11;
			}
			else
			{
				item.useStyle = ItemUseStyleID.Shoot;
				item.knockBack = 2;
				item.damage = 31;
				item.UseSound = SoundID.Item40;
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FlareGun, 1)
				.AddIngredient(ItemID.TheUndertaker, 1)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddRecipeGroup("Antiaris:SilverBar", 15)
				.AddIngredient(ItemID.Torch, 5)
				.AddTile(18)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.FlareGun, 1)
				.AddIngredient(ItemID.Musket, 1)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddRecipeGroup("Antiaris:SilverBar", 15)
				.AddIngredient(ItemID.Torch, 5)
				.AddTile(18)
				.Register();
		}
	}
}
