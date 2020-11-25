using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class AntlionQueenMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 32;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Queen Mask");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮女王面具");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска Королевы муравьиных львов");
		}
	}
}