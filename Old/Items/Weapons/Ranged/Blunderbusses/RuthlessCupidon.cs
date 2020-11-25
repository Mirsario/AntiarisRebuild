using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class RuthlessCupidon : ModItem
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
			item.damage = 32;
			item.DamageType = DamageClass.Ranged;
			item.width = 56;
			item.height = 24;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4.0f;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 9.0f;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruthless Cupidon");
			Tooltip.SetDefault("Uses buckshots as ammo\nCreates a crystal energy behind you when shooting\nEnergy flies into cursor position and restore life on hit");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "无情丘比特");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火铳弹作为弹药\n2、当你开火时身后会产生水晶能量\n3、能量会以光标所在方向发射，击中敌人后可以恢复生命");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Безжалостный купидон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nСоздает кристальную энергию позади после выстрела\nЭта энергия летит в курсор игрока и восстановят здоровье при попадании");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45.0f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				position += muzzleOffset;
			if (player.Center.X < Main.mouseX + (double)Main.screenPosition.X)
				player.direction = 1;
			else
				player.direction = -1;
			for (int k = 0; k < Main.rand.Next(2, 4); k++)
				Projectile.NewProjectile(player.Center.X + -40 * player.direction + Main.rand.Next(-20, 21), player.Center.Y - Main.rand.Next(-20, 40), speedX / 2.0f, speedY / 2.0f, ModContent.ProjectileType<CrystalEnergy>(), (int)((item.damage * (double)player.rangedDamage) / 1.5f), 4.0f, player.whoAmI, 0.0f, 0.0f);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase")
				.AddIngredient(ItemID.LifeCrystal, 2)
				.AddIngredient(ItemID.CrystalShard, 12)
				.AddIngredient(ItemID.GoldBar, 10)
				.AddTile(134)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "BlunderbussBase")
				.AddIngredient(ItemID.LifeCrystal, 2)
				.AddIngredient(ItemID.CrystalShard, 12)
				.AddIngredient(ItemID.PlatinumBar, 10)
				.AddTile(134)
				.Register();
		}
	}
}
