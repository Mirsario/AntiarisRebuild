using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class InfectedLeaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 20;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infected Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "腐化叶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Заражённый лист");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
