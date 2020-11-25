using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class EnchantedLeaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "附魔叶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зачарованный лист");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
