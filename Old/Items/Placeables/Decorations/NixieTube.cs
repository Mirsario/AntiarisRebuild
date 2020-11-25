using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class NixieTube : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 14;
			item.useTime = 14;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.createTile = ModContent.TileType<NixieTube>();
			item.placeStyle = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nixie Tube");
			Tooltip.SetDefault("<right> placed tube to configure it\n'Shows the divergence value of world line'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "数码管");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "放置后 <right> 可以进行修改\n“显示世界线的分歧值”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Газоразрядный индикатор");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "<right> по установленному индикатору, чтобы настроить его\n'Показывает значение отклонения мировой линии'");
		}
	}
}