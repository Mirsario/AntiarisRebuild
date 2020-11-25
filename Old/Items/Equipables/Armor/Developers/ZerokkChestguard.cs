using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(new EquipType[] { EquipType.Body })]
	public class ZerokkChestguard : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zerokk's Chestguard");
			Tooltip.SetDefault("'Great for impersonating former developers!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Нагрудник Zerokk'a");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за бывшего разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Zerokk的帽子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充前任开发者！”");
		}
	}
}