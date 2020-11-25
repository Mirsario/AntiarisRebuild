using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Content.Items.Materials
{
	public class BloodyChargedCrystal : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 10, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Charged Crystal");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蓄能血晶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кровавый заряжённый кристалл");
		}
	}
}
