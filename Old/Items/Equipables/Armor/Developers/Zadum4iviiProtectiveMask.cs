using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Developers
{
	[AutoloadEquip(EquipType.Head)]
	public class Zadum4iviiProtectiveMask : ModItem
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
			DisplayName.SetDefault("Zadum4ivii's Protective Mask");
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Защитная маска Zadum4ivii");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Zadum4ivii的护身面具");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“非常适合冒充开发者！”");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Zadum4iviiProtectiveBreastplate>() && legs.type == ModContent.ItemType<Zadum4iviiProtectiveGreaves>();
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMask = AntiarisGlowMasks.Zadum4iviiProtectiveMask;
			glowMaskColor = Color.White;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
			Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.8f, 0f, 0.8f);
		}
	}
}
