﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Miscellaneous
{
	public class RedCrystalScythe : ModItem
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
			item.damage = 28;
			item.melee = true;
			item.width = 54;
			item.height = 56;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 10, 5, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<CrystalScythe>();
			item.shootSpeed = 7f;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Crystal Scythe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Красная кристальная коса");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "红水晶镰刀");
		}
	}
}
