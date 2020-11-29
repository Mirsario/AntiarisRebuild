using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class PowerofLight : ModItem
	{
		/*public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(Mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask");
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, Mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale);
		}*/

		public override void SetDefaults()
		{
			item.damage = 34;
			item.DamageType = DamageClass.Ranged;
			item.width = 56;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.shoot = ModContent.ProjectileType<Projectiles.Ranged.LightEnergy>();
			item.shootSpeed = 13f;
			item.useStyle = ItemUseStyleID.Shoot;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item91;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Power of Light");
			Tooltip.SetDefault("Shoots bouncing clots of light which increase their damage with each bounce\n<right> to shoot a powerful piercing clot");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "强光体");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "发射可以反弹的光凝聚体，反弹次数越多伤害越高\n<right> 发射强力的光凝聚体");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сила света");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает отскакивающими сгустками света, которые повышают свой урон при каждом отскоке\n<right>, чтобы выстрелить мощным пронизывающим сгустком");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;

			if (player.altFunctionUse == 2)
			{
				type = ModContent.ProjectileType<Projectiles.Ranged.LightEnergy2>();
			}
			else
			{
				type = ModContent.ProjectileType<Projectiles.Ranged.LightEnergy>();
			}

			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.damage = 50;
				item.shoot = ModContent.ProjectileType<Projectiles.Ranged.LightEnergy2>();
				item.shootSpeed = 13f;
				item.useAnimation = 42;
				item.useTime = 42;
				item.autoReuse = true;
			}
			else
			{
				item.damage = 38;
				item.shoot = ModContent.ProjectileType<Projectiles.Ranged.LightEnergy>();
				item.shootSpeed = 13f;
				item.useAnimation = 15;
				item.useTime = 15;
				item.autoReuse = true;
			}

			return base.CanUseItem(player);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, -2);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 20)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddIngredient<Materials.TranquilityElement>(8)
				.AddTile(134)
				.Register();
		}
	}
}
