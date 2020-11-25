using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class GildedKey : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 38;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 2, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Key");
			Tooltip.SetDefault("Opens Gilded Chests in Pirate's Coves");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "镀金之匙");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "可以打开海盗洞窟中的镀金箱");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Позолоченный ключ");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Открывает Позолоченные сундуки в Пиратских бухтах");
		}
	}
}