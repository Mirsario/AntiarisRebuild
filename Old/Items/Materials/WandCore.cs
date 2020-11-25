using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class WandCore : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 1, 15, 35);
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand Core");
			Tooltip.SetDefault("'Filled with energy'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "法杖核心");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“充满能量”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Стержень для посоха");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Наполнен энергией'");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
		}*/
	}
}
