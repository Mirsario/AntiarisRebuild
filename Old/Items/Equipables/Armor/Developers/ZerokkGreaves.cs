using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(new EquipType[] { EquipType.Legs })]
	public class ZerokkGreaves : ModItem
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
			DisplayName.SetDefault("Zerokk's Greaves");
			Tooltip.SetDefault("'Great for impersonating former developers!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Поножи Zerokk");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за бывшего разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Zerokk的护胫甲");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充前任开发者！”");
		}
	}
}
