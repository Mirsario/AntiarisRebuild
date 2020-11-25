using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Face })]
	public class EmeraldGift : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emerald Gift");
			Tooltip.SetDefault("Healing and emerald flames appear around when not moving\nIncreases health restored by healing flames by 2");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Изумрудный дар");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Лечащие и изумрудные огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 2");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "翡翠的恩赐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不移动时周围会燃起使你回复体力的翡翠火焰\n2、每一个翡翠火焰可以使你回复 2 点体力");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 2;
			player.GetModPlayer<AntiarisPlayer>(mod).emeraldG = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NaturesGift, 1)
				.AddIngredient(ItemID.Emerald, 8)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
