using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class BearMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 226;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bear Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "熊面具");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска медведя");
		}
	}
}
