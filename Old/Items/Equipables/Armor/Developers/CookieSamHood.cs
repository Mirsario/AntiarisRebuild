using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(EquipType.Head)]
	public class CookieSamHood : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CookieSam's Hood");
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Капюшон CookieSam");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "CookieSam的兜帽");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充开发者！”");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CookieSamRobe>() && legs.type == ModContent.ItemType<CookieSamPants>();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
	}
}
