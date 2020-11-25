using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class Shadowflame : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 26;
			item.rare = ItemRarityID.Pink;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 0, 90);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Теневое пламя");
		}
	}
}
