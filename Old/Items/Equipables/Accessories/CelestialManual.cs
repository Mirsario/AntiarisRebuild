using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	public class CelestialManual : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.accessory = true;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Manual");
			Tooltip.SetDefault("Using Adventurer's symbols will restore life");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "神圣手册");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用“特殊能力”类型的饰品将回复生命值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Небесное руководство");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использование символов Путешественника восстановит здоровье");
		}
	}
}