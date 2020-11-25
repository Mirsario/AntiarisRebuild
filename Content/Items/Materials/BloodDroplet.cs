using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Content.Items.Materials
{
	public class BloodDroplet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Droplet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "血滴");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Капля крови");
		}
	}
}
