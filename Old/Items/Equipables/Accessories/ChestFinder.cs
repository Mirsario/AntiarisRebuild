using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	public class ChestFinder : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chest Finder");
			Tooltip.SetDefault("Reveals nearby wooden and gold chests on map");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "箱子搜寻者");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "显示附近的木箱子和金箱子");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Поисковик сундуков");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Отображает ближайшие деревянные и золотые сундуки на карте");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.foundChest = true;
		}

		public override void UpdateInventory(Player player)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.foundChest = true;
		}
	}
}