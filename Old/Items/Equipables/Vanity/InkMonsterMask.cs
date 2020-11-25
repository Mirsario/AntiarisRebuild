using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class InkMonsterMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 40;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ink Monster Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "墨水怪兽的面具");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска чернильного монстра");
		}
	}
}
