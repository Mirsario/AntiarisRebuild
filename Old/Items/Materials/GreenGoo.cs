using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class GreenGoo : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.width = 22;
			item.height = 24;
			item.rare = ItemRarityID.Green;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 0, 75);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Goo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "绿色凝胶");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зеленая слизь");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.FloatsInWater);
		}*/
	}
}
