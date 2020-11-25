using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
	public class BlueCrystalBullet : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.DamageType = DamageClass.Ranged;
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2.0f;
			item.value = Item.sellPrice(0, 0, 0, 80);
			item.rare = ItemRarityID.Pink;
			item.shoot = ModContent.ProjectileType<BlueCrystalBullet>();
			item.shootSpeed = 15.0f;
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Crystal Bullet");
			Tooltip.SetDefault("Crazy velocity and infinity piercing");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Голубая кристальная пуля");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Безумная скорость и бесконечная пробиваемость");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蓝水晶弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "疯狂的攻速和无尽的穿透");
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(null, "BlueBigCrystal", 1)
				.AddIngredient(ItemID.MusketBall, 100)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
