using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class BoilingPoint : ModItem
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
			item.damage = 23;
			item.DamageType = DamageClass.Ranged;
			item.width = 66;
			item.height = 32;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 1, 10, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boiling Point");
			Tooltip.SetDefault("Uses buckshots as ammo\nBuckshots set enemies on fire");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "沸点");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用火铳弹当做弹药\n发射可以灼烧敌人的火铳弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Точка кипения");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nКартечь поджигает врагов");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.FireDamage);
		}*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.HellstoneBar, 20)
				.AddIngredient(ItemID.AshBlock, 35)
				.AddIngredient(null, "WrathElement", 7)
				.AddTile(18)
				.Register();
		}
	}
}
