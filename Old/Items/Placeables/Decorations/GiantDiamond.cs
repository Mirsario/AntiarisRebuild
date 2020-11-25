using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class GiantDiamond : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 40;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 50, 0, 0);
			item.createTile = ModContent.TileType<GiantDiamond>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Diamond");
			Tooltip.SetDefault("'Not to be confused with Unbreakable diamond'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "巨大钻石");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“不要与坚不可摧的钻石混淆”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гигантский алмаз");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Не путать с Несокрушимым алмазом'");
		}
	}
}