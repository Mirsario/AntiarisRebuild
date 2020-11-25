using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class TropicalLeaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tropical Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "热带叶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Тропический лист");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
