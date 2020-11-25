using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class FunnyMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Funny Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "滑稽果");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Забавная маска");
		}
	}
}
