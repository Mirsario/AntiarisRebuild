using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
	public class AncientSniper : ModItem
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
			item.damage = 35;
			item.DamageType = DamageClass.Ranged;
			item.width = 48;
			item.height = 28;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 70f;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Sniper");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "远古狙击手");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Древний снайпер");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Crossbow);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteBar, 11)
				.AddIngredient(null, "ShadowChargedCrystal", 12)
				.AddIngredient(ItemID.SoulofNight, 7)
				.AddIngredient(null, "WrathElement", 4)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddTile(16)
				.Register();
		}
	}
}
