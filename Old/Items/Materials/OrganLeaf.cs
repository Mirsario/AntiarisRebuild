using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class OrganLeaf : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 28;
			item.rare = ItemRarityID.White;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Organ Leaf");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "肝脏叶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Лист из органов");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
