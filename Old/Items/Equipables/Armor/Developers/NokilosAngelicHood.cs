using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(EquipType.Head)]
	public class NokilosAngelicHood : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 12;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nokilos' Angelic Hood");
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ангельский капюшон Nokilos");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Nokilos的头盔");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充开发者！”");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NokilosAngelicChestplate>() && legs.type == ModContent.ItemType<NokilosAngelicGreaves>();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
	}
}
