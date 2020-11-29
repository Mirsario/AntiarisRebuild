using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class CrystalGrower : ModItem
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
			item.damage = 25;
			item.DamageType = DamageClass.Ranged;
			item.width = 42;
			item.height = 18;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 8f;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Grower");
			Tooltip.SetDefault("Fires a spread of crystal bullets");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "晶体生长器");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "散射水晶弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кристальный садовод");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает пятью кристальными пулями за раз");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 89;
			int numberProjectiles = 5;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CrimtaneBar, 11)
				.AddIngredient(ItemID.SoulofNight, 7)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddIngredient<Materials.BloodyChargedCrystal>(12)
				.AddIngredient<Materials.WrathElement>(4)
				.AddTile(16)
				.Register();
		}
	}
}
