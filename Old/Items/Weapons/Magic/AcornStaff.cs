using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class AcornStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 6;
			item.magic = true;
			item.mana = 7;
			item.width = 32;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 18, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<MagicAcorn>();
			item.shootSpeed = 6f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Staff");
			Tooltip.SetDefault("Shoots an acorn\nAcorns can transform to acorn creatures that attack enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "橡子法杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、发射橡子\n2、橡子接触物块后会变成橡子生物攻击敌人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох желудей");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает жёлудями\nЖёлудь может превратиться в существо, которое атакует врагов");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 25)
				.AddIngredient(ItemID.Acorn, 8);
				.AddIngredient(null, "NatureEssence", 12)
				.AddTile(16)
				.Register();
		}
	}
}
