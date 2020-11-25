using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class TowerKeeperMask1 : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 26;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tower Keeper Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "守塔魔像面具");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска Хранителя башни");
		}
	}
}