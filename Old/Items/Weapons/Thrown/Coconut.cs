using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class Coconut : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 40;
			item.damage = 34;
			item.thrown = true;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Coconut>();
			item.shootSpeed = 10f;
			item.consumable = true;
			item.maxStack = 999;
			item.rare = ItemRarityID.White;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coconut");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "椰子");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кокос");
		}
	}
}
