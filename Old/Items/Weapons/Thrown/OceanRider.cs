using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class OceanRider : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 35;
			item.thrown = true;
			item.width = 52;
			item.height = 52;
			item.noUseGraphic = true;
			item.useTime = 25;
			item.useAnimation = 25;
			item.shoot = ModContent.ProjectileType<OceanRider>();
			item.shootSpeed = 9f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.maxStack = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Rider");
			Tooltip.SetDefault("Throws a spear that leaves homing bubbles behind");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Океанский ездок");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Бросает копьё, которое оставляет за собой самонаводящиеся пузыри");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}
	}
}
