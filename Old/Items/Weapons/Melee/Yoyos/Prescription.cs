using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class Prescription : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<Prescription>();
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 34;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.useStyle = ItemUseStyleID.HoldingOut;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prescription");
			Tooltip.SetDefault("Occasionally shoots out purple spheres at nearby enemies\nSpheres heal the player when hit enemy");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "处方药");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "有时对附近敌人所在区域发射紫色光球，当光球击中敌人时会治疗玩家");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Рецепт");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Иногда выстреливает фиолетовыми сферами по ближайшим врагам\nСферы восстанавливают здоровье по игроку, когда попадают по врагу");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.WoodYoyo, 1)
				.AddIngredient(ItemID.CrystalShard, 15)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddIngredient(ItemID.LifeCrystal, 3)
				.AddTile(134)
				.Register();
		}
	}
}
