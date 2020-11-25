using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class ShadowflameCharm : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 38;
			item.rare = ItemRarityID.Pink;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame Charm");
			Tooltip.SetDefault("Minions inflict shadowflame on enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火饰物");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤物会对敌人施加暗影火");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Амулет теневого пламени");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Миньоны накладывают на врагов теневое пламя");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.shadowflameCharm = true;
		}
	}
}
