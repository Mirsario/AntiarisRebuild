using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(new EquipType[] { EquipType.Head })]
	public class ZerokkHat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 24;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zerokk's Hat");
			Tooltip.SetDefault("'Great for impersonating former developers!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шапка Zerokk");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за бывшего разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Zerokk的帽子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充前任开发者！”");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ZerokkChestguard>() && legs.type == ModContent.ItemType<ZerokkGreaves>();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
	}
}
