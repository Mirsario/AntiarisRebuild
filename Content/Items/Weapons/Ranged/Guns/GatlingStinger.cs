using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class GatlingStinger : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 28;
			item.DamageType = DamageClass.Ranged;
			item.width = 60;
			item.height = 40;
			item.useTime = 3;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.Shoot;
			item.reuseDelay = 35;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightRed;
			item.autoReuse = true;
			item.shoot = ProjectileID.HornetStinger;
			item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 3, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gatling Stinger");
			Tooltip.SetDefault("Fires a burst of stingers\nDoes not require ammo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Жало гатлинга");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает залпом жал");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.IllegalGunParts)
				.AddIngredient(ItemID.Stinger, 8)
				.AddIngredient(ItemID.HoneyBlock, 10)
				.AddIngredient<Materials.HoneyExtract>(14)
				.AddTile(134)
				.Register();
		}
	}
}
