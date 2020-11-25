using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class DeadlyJonesMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = Item.buyPrice(0, 10, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deadly Jones Mask");
			Tooltip.SetDefault("'Comes with a fancy beard!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска Дэдли Джонса");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'В комплект входит красивая борода!'");
		}
	}
}
