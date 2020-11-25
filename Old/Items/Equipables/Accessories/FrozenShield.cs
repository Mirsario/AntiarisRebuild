using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class FrozenShield : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 44;
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.accessory = true;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Shield");
			Tooltip.SetDefault("When above 25% life, absorbs 25% of damage done to players on your team\nWhen below 50% life, grants a protective shell that reduces damage by 25%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "急冻盾牌");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、生命值高于总值的 25%时，吸收队友 25% 的伤害\n2、当生命值低于 50% 时，将获得减少 25% 伤害的冰坚壳");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ледяной щит");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Поглощает 25% урона, нанесенного игрокам в вашей команде, если здоровье выше 25%\nПризывает защитный панцирь, снижающий полученный урон на 25%, если здоровье ниже 50%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noKnockback = true;
			if (player.statLife <= player.statLifeMax2 * 0.5)
			{
				player.AddBuff(62, 5, true);
			}
			if (player.statLife > player.statLifeMax2 * 0.25)
			{
				player.hasPaladinShield = true;
				if (player != Main.LocalPlayer && player.miscCounter % 10 == 0)
				{
					if (Main.LocalPlayer.team == player.team && player.team != 0)
					{
						float local = player.position.X - Main.LocalPlayer.position.X;
						float num = (float)(player.position.Y - Main.LocalPlayer.position.Y);
						if (Math.Sqrt(local * local + num * (double)num) < 800.0)
						{
							Main.LocalPlayer.AddBuff(43, 20, true);
						}
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PaladinsShield)
				.AddIngredient(ItemID.FrozenTurtleShell)
				.AddTile(114)
				.Register();
		}
	}
}