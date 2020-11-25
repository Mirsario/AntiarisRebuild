using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(EquipType.Legs)]
	public class CookieSamSweatpants : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 14;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CookieSam's Sweatpants");
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Спортивные штаны CookieSam");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "CookieSam运动裤");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充开发者！”");
		}
	}
}
