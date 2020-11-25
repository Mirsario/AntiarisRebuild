using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class DavysMap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Davy's Map");
			Tooltip.SetDefault("Marks the location of the Pirate's Cove on the map when in the inventory");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "戴维的地图");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在物品栏时打开地图后标出海盗湾的所在地");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Карта Дэйви");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Отмечает местоположение Пиратской бухты на карте, если находится в инвентаре");
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 28;
			item.rare = ItemRarityID.Cyan;
			item.maxStack = 1;
			item.expert = true;
		}
	}
}
