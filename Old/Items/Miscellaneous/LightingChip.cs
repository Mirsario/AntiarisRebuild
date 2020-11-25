using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class LightingChip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lighting Chip");
			Tooltip.SetDefault("Can be inserted into Nixie Tube to make its symbol more luminous");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "照明芯片");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "可以插入数码管，使其符号更明亮");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Чип свечения");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Можно вставить в Газоразрядный индикатор, чтобы сделать его символ более светящимся");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 22;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 0, 80, 0);
		}
	}
}
