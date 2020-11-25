using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(EquipType.Legs)]
	public class Zadum4iviiProtectiveGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zadum4ivii's Protective Greaves");
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Защитные поножи Zadum4ivii");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Zadum4ivii的护身胫甲");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充开发者！”");
		}
	}
}
