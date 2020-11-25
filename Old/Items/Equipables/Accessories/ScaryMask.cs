using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class ScaryMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(0, 18, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scary Mask");
			Tooltip.SetDefault("Increases minion size by 150%\n10% increased minion damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "惊惧之相");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、增加 150% 召唤物大小\n2、增加 10% 召唤物伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Страшная маска");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает размер миньонов на 150%\nУвеличивает урон миньонов на 10%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			player.minionDamage += 0.1f;
			aPlayer.bigMinions = true;
		}
	}
}
