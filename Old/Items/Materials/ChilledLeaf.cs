using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class ChilledLeaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chilled Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "寒冰叶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Замёрзший лист");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
