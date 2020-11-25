using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class ScientistWig : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = Item.buyPrice(0, 20, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scientist Wig");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Парик учёного");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "");
		}
	}
}
