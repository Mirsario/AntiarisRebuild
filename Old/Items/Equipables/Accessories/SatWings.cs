using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class SatWings : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 38;
			item.value = 10000;
			item.rare = ItemRarityID.Yellow;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sat's Wings");
			Tooltip.SetDefault("Allows flight and slow fall");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Sat的双翼");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "允许飞行和缓慢降落");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Крылья Сата");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Позволяют летать и медленно падать");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 150;
			if (!hideVisual)
			{
				if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame)
				{
					if (player.direction == 1)
					{
						for (int i = 0; i < 5; i++)
						{
							Dust.NewDust(player.position - new Vector2(24f, 0f), player.width, player.height, 62, 0, 0, 0, Color.White);
						}
					}

					if (player.direction == -1)
					{
						for (int i = 0; i < 5; i++)
						{
							Dust.NewDust(player.position + new Vector2(24f, 0f), player.width, player.height, 62, 0, 0, 0, Color.White);
						}
					}
				}
			}
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.35f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 14f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemonWings)
				.AddIngredient(null, "Shadowflame", 14)
				.AddIngredient(null, "WrathElement", 10)
				.AddIngredient(ItemID.SoulofFlight, 10)
				.AddTile(412)
				.Register();
		}
	}
}