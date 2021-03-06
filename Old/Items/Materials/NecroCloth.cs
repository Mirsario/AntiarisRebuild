using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class NecroCloth : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 34;
			item.rare = ItemRarityID.Yellow;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 1, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necro Cloth");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "死灵之布");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Некро-ткань");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
		}*/
	}
}
