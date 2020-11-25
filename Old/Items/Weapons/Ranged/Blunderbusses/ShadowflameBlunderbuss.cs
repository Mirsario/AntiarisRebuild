using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class ShadowflameBlunderbuss : ModItem
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
			item.damage = 33;
			item.DamageType = DamageClass.Ranged;
			item.width = 100;
			item.height = 48;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame Blunderbuss");
			Tooltip.SetDefault("Uses buckshots as ammo\nShoots out shadowflame buckshots");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火铳弹当做弹药\n2、发射暗影火火铳弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мушкетон теневого пламени");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nВыстреливает картечью теневого пламени");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-9, -3);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<ShadowflameBuckshot>();
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddIngredient(null, "Shadowflame", 10)
				.AddTile(134)
				.Register();
		}
	}
}
