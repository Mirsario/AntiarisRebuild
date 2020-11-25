using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Face })]
	public class AmethystGift : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 28;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Gift");
			Tooltip.SetDefault("Healing and amethyst flames appear around when not moving\nIncreases health restored by healing flames by 1");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Аметистовый дар");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Лечащие и аметистовые огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 1");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "紫水晶的恩赐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不移动时周围会燃起使你回复体力的紫水晶火焰\n2、每一个紫水晶火焰可以使你回复 1 点体力");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 1;
			player.GetModPlayer<AntiarisPlayer>(mod).amethystG = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NaturesGift, 1)
				.AddIngredient(ItemID.Amethyst, 8)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
