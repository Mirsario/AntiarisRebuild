using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class WandOfLightRage : ModItem
	{
		public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask");
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale);
		}

		public override void SetDefaults()
		{
			item.damage = 27;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0.0f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item81;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<Lightning3>();
			item.shootSpeed = 22.0f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of Light Rage");
			Tooltip.SetDefault("Casts furious lightning at enemies\n'Forged with Aer'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "雷怒之杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "对敌人降下天谴\n“空气之造物”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох ярости света");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выпускает яростную молнию в противников\n'Сковано из Аера'");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.ownedProjectileCounts[type] > 3)
				return false;
			knockBack = player.GetWeaponKnockback(item, knockBack);
			player.itemTime = item.useTime;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float x = Main.mouseX - Main.screenPosition.X - vector.X;
			float y = Main.mouseY - Main.screenPosition.Y - vector.Y;
			if (player.gravDir == -1.0f)
				y = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector.Y;
			float distance = (float)Math.Sqrt(x * x + y * y);
			if ((float.IsNaN(x) && float.IsNaN(y)) || (x == 0.0f && y == 0.0f))
			{
				x = player.direction;
				y = 0.0f;
				distance = item.shootSpeed;
			}
			else
				distance = item.shootSpeed / distance;
			x *= distance;
			y *= distance;
			int count = 1;
			for (int k = 0; k < count; k++)
			{
				vector = new Vector2(player.position.X + player.width * 0.5f + (float)(Main.rand.Next(201) * -(float)player.direction) + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				vector.X = (vector.X + player.Center.X) / 2.0f + Main.rand.Next(-200, 201);
				vector.Y -= 100 * k;
				x = Main.mouseX + Main.screenPosition.X - vector.X;
				y = Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (y < 0.0f)
					y *= -1.0f;
				if (y < 20.0f)
					y = 20.0f;
				distance = (float)Math.Sqrt(x * x + y * y);
				distance = item.shootSpeed / distance;
				x *= distance;
				y *= distance;
				Projectile.NewProjectile(vector.X, vector.Y, x, y + Main.rand.Next(-180, 181) * 0.02f, type, damage, knockBack, player.whoAmI, 0.0f, Main.rand.Next(10));
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Bone, 3)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Lens, 3)
				.AddIngredient(ItemID.FallenStar, 10)
				.AddIngredient(ItemID.Topaz, 10)
				.AddIngredient(ItemID.ManaCrystal)
				.AddTile(TileID.DemonAltar)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Bone, 3)
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddIngredient(ItemID.Lens, 3)
				.AddIngredient(ItemID.FallenStar, 10)
				.AddIngredient(ItemID.Topaz, 10)
				.AddIngredient(ItemID.ManaCrystal)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}
