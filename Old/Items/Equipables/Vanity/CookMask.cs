using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class CookMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cook Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "厨师面具");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска повара");
		}
	}
}
