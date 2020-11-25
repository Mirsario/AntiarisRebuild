using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class PrivateerDagger : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 17;
			item.thrown = true;
			item.width = 14;
			item.height = 32;
			item.noUseGraphic = true;
			item.useTime = 10;
			item.reuseDelay = 8;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<PrivateerDagger>();
			item.shootSpeed = 14f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Privateer Dagger");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Нож капера");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "私掠者的匕首");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、抛出两个击中敌人会反弹的飞刀\n2、被其击中的敌人施加一个Debuff，获得Debuff后被击杀的敌人掉落的钱币更多");
			Tooltip.SetDefault("Shoots out two daggers that can bounce off enemies\nHas a chance to inflict Midas on enemies");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает двумя ножами, которые могут отскакивать от врагов\nИмеет шанс наложить эффект Мидаса на врагов");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "RoyalWeaponParts", 6)
				.AddTile(16)
				.Register();
		}
	}
}
