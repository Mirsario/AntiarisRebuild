using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class TreasureAmulet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 46;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Amulet");
			Tooltip.SetDefault("Allows to see the location of treasure and ore");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "财宝护身符");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "允许你看到财宝和矿石所在的位置");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Амулет сокровищ");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Позволяет видеть расположение ценных объектов и руды");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).findTreasure2 = true;
		}
	}
}
