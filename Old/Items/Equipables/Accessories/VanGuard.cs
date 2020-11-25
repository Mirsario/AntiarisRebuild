using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class VanGuard : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 50;
			item.height = 36;
			item.rare = ItemRarityID.Yellow;
			item.defense = 5;
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vanguard");
			Tooltip.SetDefault("Increases stats of players on your team\nAbsorbs 25% of damage done to players on your team");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "先卫");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、提升你所在队伍其它队员的所有类型伤害、近战攻速、移动速度\n2、吸收队友所承受的25%的伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Защитник");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Повышает характеристики игроков в вашей команде\nБлокирует 25% урона, нанесенного членам команды");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<VanGuard>(), 2);
			player.noKnockback = true;
			player.hasPaladinShield = true;
			Player player2 = Main.LocalPlayer;
			if (player != player2 && player.miscCounter % 10 == 0)
			{
				if (player2.team == player.team && player.team != 0)
				{
					float local = player.position.X - player2.position.X;
					float distance = (float)(player.position.Y - player2.position.Y);
					if (Math.Sqrt(local * local + distance * (double)distance) < 800.0)
					{
						player2.AddBuff(ModContent.BuffType<VanGuardAura>(), 20, true);
						player2.AddBuff(43, 20, true);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PaladinsShield)
				.AddIngredient(null, "Warbanner")
				.AddTile(114)
				.Register();
		}
	}
}