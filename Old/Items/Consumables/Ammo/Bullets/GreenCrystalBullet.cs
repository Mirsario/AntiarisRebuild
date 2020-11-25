using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
	public class GreenCrystalBullet : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.DamageType = DamageClass.Ranged;
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4.0f;
			item.value = Item.sellPrice(0, 0, 0, 80);
			item.rare = ItemRarityID.Pink;
			item.shoot = ModContent.ProjectileType<GreenCrystalBullet>();
			item.shootSpeed = 7.0f;
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Crystal Bullet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зеленая кристальная пуля");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "绿水晶弹");
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(null, "GreenBigCrystal", 1)
				.AddIngredient(ItemID.MusketBall, 100)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
