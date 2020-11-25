using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class TerraSpear : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 14;
			item.useTime = 14;
			item.shootSpeed = 5.6f;
			item.knockBack = 6.2f;
			item.width = 66;
			item.height = 76;
			item.damage = 84;
			item.scale = 1.1f;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<TerraSpear>();
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(0, 28, 25, 45);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra Spear");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "泰拉长枪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Терра Копье");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10.0f));
			speedX = vector2.X;
			speedY = vector2.Y;
			Projectile.NewProjectile(position.X, position.Y, speedX * 1.6f, speedY * 1.6f, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "TrueDarkLance")
				.AddIngredient(null, "TrueGungnir")
				.AddTile(134)
				.Register();
		}
	}
}
