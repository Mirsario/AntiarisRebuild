using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Face })]
	public class DiamondGift : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.accessory = true;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Gift");
			Tooltip.SetDefault("Healing and diamond flames appear around when not moving\nIncreases health restored by healing flames by 4\n33% decreased flames appearance cooldown");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Алмазный дар");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Лечащие и аметистовые огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 4\nНа 33% снижает кулдаун появление огоньков");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "钻石的恩赐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不移动时周围会燃起使你回复体力的钻石火焰\n2、每一个钻石火焰可以使你回复 4 点体力\n3、减少 33% 火焰生成冷却时间");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 4;
			player.GetModPlayer<AntiarisPlayer>(mod).diamondG = true;
			player.GetModPlayer<AntiarisPlayer>(mod).giftCooldown2 += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NaturesGift, 1)
				.AddIngredient(ItemID.Diamond, 8)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
