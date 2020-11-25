using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class CrimsonDrake : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 17;
			item.DamageType = DamageClass.Ranged;
			item.width = 66;
			item.height = 26;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 65f;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Drake");
			Tooltip.SetDefault("Uses buckshots as ammo\nFires two buckshots");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "血腥德雷克");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用火铳弹当做弹药\n发射两个火铳弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Багряный дракон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nВыстреливает двумя картечами");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.UnholyDamage);
		}*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-9, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.CrimtaneBar, 10)
				.AddIngredient(ItemID.TissueSample, 10)
				.AddTile(18)
				.Register();
		}
	}
}
