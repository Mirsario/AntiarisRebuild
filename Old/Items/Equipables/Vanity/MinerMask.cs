using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class MinerMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 18;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miner Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "矿工面具");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска шахтёра");
		}
	}
}
