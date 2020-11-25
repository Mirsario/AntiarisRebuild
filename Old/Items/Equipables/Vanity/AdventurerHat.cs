using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class AdventurerHat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 12;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = Item.sellPrice(0, 0, 1, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adventurer's Hat");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "冒险家的帽子");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шляпа путешественника");
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}
	}
}

