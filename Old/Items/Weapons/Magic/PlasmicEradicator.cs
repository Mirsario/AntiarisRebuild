using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class PlasmicEradicator : ModItem
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
			item.damage = 85;
			item.magic = true;
			item.width = 84;
			item.height = 44;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 11, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item91;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<PlasmicRay>();
			item.shootSpeed = 6f;
			item.mana = 6;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasmic Eradicator");
			Tooltip.SetDefault("Shoots three piercing plasmic rays\nHitting an enemy with a ray has a chance to summon an electric sphere");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Плазменный искоренитель");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает тремя проникающими плазменными лучами\nПопадание по врагу лучом имеет шанс призвать электрическую сферу");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			int numberProjectiles = 3;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "CosmicRayer")
				.AddIngredient(ItemID.ElectrosphereLauncher)
				.AddIngredient(ItemID.MartianConduitPlating, 15)
				.AddIngredient(ItemID.Wire, 10)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddTile(134)
				.Register();
		}
	}
}
