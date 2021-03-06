﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(EquipType.Body)]
	public class CookieSamJacket : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 18;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CookieSam's Jacket");
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пиджак CookieSam");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "CookieSam夹克");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充开发者！”");
		}

		public override void UpdateEquip(Player player)
		{
			if (player.name == "CookieSam")
			{
				player.meleeDamage += 19f;
				player.thrownDamage += 19f;
				player.rangedDamage += 19f;
				player.magicDamage += 19f;
				player.lifeRegen = +999;
				player.moveSpeed += 0.15f;
				player.moveSpeed += 999f;
				player.manaRegen = +999;
				player.manaCost -= 1f;
				player.statLifeMax = 500;
				player.statManaMax2 += 400;
				player.manaRegen = 1555;
				player.buffImmune[44] = true;
				player.buffImmune[46] = true;
				player.buffImmune[47] = true;
				player.buffImmune[20] = true;
				player.buffImmune[22] = true;
				player.buffImmune[24] = true;
				player.buffImmune[23] = true;
				player.buffImmune[30] = true;
				player.buffImmune[31] = true;
				player.buffImmune[32] = true;
				player.buffImmune[33] = true;
				player.buffImmune[35] = true;
				player.buffImmune[36] = true;
				player.buffImmune[69] = true;
				player.buffImmune[70] = true;
				player.buffImmune[80] = true;
				player.buffImmune[144] = true;
				player.maxMinions += 999;
			}
		}
	}
}
