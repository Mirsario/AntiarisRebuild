﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class HallowedBlunderbuss : ModItem
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
			item.damage = 65;
			item.DamageType = DamageClass.Ranged;
			item.width = 78;
			item.height = 32;
			item.useTime = 42;
			item.useAnimation = 42;
			item.crit = item.crit + 4;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 8;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(0, 5, 10, 0);
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 16f;
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Blunderbuss");
			Tooltip.SetDefault("Uses buckshots as ammo\n<right> to zoom out\n50% chance to not consume ammo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "神圣火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火铳弹当做弹药 \n2、点击鼠标 <right> 键观察远处。 \n3、50%的几率不消耗弹药。");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Святой мушкетон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nright> для приближения\n50% шанс не потратить пулю");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.HolyDamage);
		}*/

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.HallowedBar, 14)
				.AddTile(134)
				.Register();
		}
	}
}
