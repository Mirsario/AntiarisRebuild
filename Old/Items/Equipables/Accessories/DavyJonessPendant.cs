using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	public class DavyJonessPendant : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Davy Jones's Pendant");
			Tooltip.SetDefault("Upon taking fatal damage, restore 200 health");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "戴维·琼斯的垂饰");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "当遭受致命伤害时，恢复 200 点生命值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кулон Дэйви Джонса");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "При получении фатального урона, восстанавливает 200 здоровья");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.davyJonessPendant = true;
		}
	}
}
