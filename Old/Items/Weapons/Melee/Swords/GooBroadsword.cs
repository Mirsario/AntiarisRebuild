﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class GooBroadsword : ModItem
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
			item.damage = 14;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Broadsword");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "凝胶宽刃剑");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Меч из слизи");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
			this.SetTag(ItemTags.BluntHit);
			this.SetTag(ItemTags.Flammable);
		}*/

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (!target.boss)
			{
				target.velocity.Y -= 5f;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LiquifiedGoo", 1)
				.AddRecipeGroup("Antiaris:WoodenSword")
				.AddTile(16)
				.Register();
		}
	}
}
