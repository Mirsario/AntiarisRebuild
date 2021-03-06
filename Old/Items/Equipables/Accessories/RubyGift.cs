using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Face })]
	public class RubyGift : ModItem
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
			item.value = Item.sellPrice(0, 2, 25, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Gift");
			Tooltip.SetDefault("Healing and ruby flames appear around when not moving\nIncreases health restored by healing flames by 3");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Рубиновый дар");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Лечащие и рубиновые огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 3");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "红宝石的恩赐");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不移动时周围会燃起使你回复体力的红宝石火焰\n2、每一个红宝石火焰可以使你回复 3 点体力");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 3;
			player.GetModPlayer<AntiarisPlayer>(mod).rubyG = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NaturesGift, 1)
				.AddIngredient(ItemID.Ruby, 8)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
