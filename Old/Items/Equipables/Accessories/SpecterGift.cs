using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Face })]
	public class SpecterGift : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.width = 52;
			item.height = 56;
			item.accessory = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Specter Gift");
			Tooltip.SetDefault("Rainbow flames appear around when not moving\nIncreases health restored by healing flames by 6\n66% decreased flames appearance cooldown");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Спектральный дар");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Радужные огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 6\nНа 66% снижает кулдаун появление огоньков");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "虹彩的恩赐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不移动时周围会燃起使你回复体力的虹彩火焰\n2、每一个虹彩火焰可以使你回复 6 点体力\n3、减少 66% 火焰生成冷却时间");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).specterG = true;
			player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 6;
			player.GetModPlayer<AntiarisPlayer>(mod).giftCooldown2 += 2;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			base.ModifyTooltips(list);
			foreach (TooltipLine TooltipLine in list)
			{
				if (TooltipLine.mod == "Terraria" && TooltipLine.Name == "ItemName")
					TooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "AmethystGift", 1)
				.AddIngredient(null, "DiamondGift", 1)
				.AddIngredient(null, "EmeraldGift", 1)
				.AddIngredient(null, "RubyGift", 1)
				.AddIngredient(null, "SapphireGift", 1)
				.AddIngredient(null, "TopazGift", 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
