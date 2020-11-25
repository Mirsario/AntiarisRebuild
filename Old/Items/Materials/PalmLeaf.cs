using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class PalmLeaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 32;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "棕榈叶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пальмовый лист");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
