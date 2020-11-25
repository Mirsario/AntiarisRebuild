using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class DoubleHeadedSnake : ModItem
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
			item.damage = 43;
			item.melee = true;
			item.width = 62;
			item.height = 62;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 8f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Double Headed Snake");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Двухголовая змея");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "双头蛇");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "击中敌人时有概率使所有敌人沾染剧毒");
			Tooltip.SetDefault("Has a chance to inflict Venom on all enemies on hit");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Имеет шанс отравить всех врагов при ударе");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(5) == 0)
			{
				foreach (NPC npc in Main.npc)
				{
					for (int k = 0; k < 200; k++)
					{
						if (Main.npc[k].lifeMax > 0 && Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].damage > 0 && !Main.npc[k].dontTakeDamage)
						{
							Main.npc[k].AddBuff(70, 120);
						}
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteBar, 12)
				.AddIngredient(null, "ShadowChargedCrystal", 14)
				.AddIngredient(ItemID.SoulofNight, 8)
				.AddIngredient(null, "WrathElement", 6)
				.AddTile(16)
				.Register();
		}
	}
}
