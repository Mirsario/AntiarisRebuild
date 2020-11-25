using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class Leaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "叶子");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Лист");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
