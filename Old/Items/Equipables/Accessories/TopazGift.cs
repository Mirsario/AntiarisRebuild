using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Face })]
	public class TopazGift : ModItem
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
			item.value = Item.sellPrice(0, 1, 35, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Topaz Gift");
			Tooltip.SetDefault("Healing and topaz flames appear around when not moving\nIncreases health restored by healing flames by 1");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Топазовый дар");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Лечащие и топазовые огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 1");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "黄玉的恩赐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不移动时周围会燃起使你回复体力的黄玉火焰\n2、每一个黄玉火焰可以使你回复 1 点体力");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 1;
			player.GetModPlayer<AntiarisPlayer>(mod).topazG = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NaturesGift, 1)
				.AddIngredient(ItemID.Topaz, 8)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
