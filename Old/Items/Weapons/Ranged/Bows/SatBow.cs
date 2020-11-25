using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
	public class SatBow : ModItem
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
			item.damage = 42;
			item.DamageType = DamageClass.Ranged;
			item.width = 38;
			item.height = 78;
			item.useAnimation = 25;
			item.useTime = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 70f;
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sat's Bow");
			Tooltip.SetDefault("Shoots out three arrows at once");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Sat的弓");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "一次可以发射三支箭");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Лук Сата");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает тремя стрелами сразу");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Bow);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(10);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
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
				.AddIngredient(null, "Shadowflame", 15)
				.AddIngredient(ItemID.HallowedBar, 20)
				.AddIngredient(ItemID.Amethyst, 2)
				.AddIngredient(ItemID.Marrow)
				.AddIngredient(null, "WrathElement", 8)
				.AddTile(412)
				.Register();
		}
	}
}
