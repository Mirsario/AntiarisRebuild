using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class ScientistCoat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 26;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = Item.buyPrice(0, 30, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scientist Coat");
			Tooltip.SetDefault("'100% increased mad scientist skills'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Халат учёного");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'На 100% увеличивает навыки безумного учёного'");
		}
	}
}
