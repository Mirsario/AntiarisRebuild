using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Content.Items.Materials
{
	public class RoyalWeaponParts : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 26;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Weapon Parts");
			Tooltip.SetDefault("'A part of Davy's past'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "皇家武器零件");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“戴维过去的一部分”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Королевские части оружия");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Часть прошлого Дэйви'");
		}
	}
}
