using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class PocketBlackhole : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 120;
			item.magic = true;
			item.mana = 12;
			item.width = 30;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			item.reuseDelay = 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Items/PocketBlackhole");
			item.noMelee = true;
			item.noUseGraphic = true;
			item.channel = true;
			item.knockBack = 0f;
			item.value = Item.buyPrice(0, 17, 0, 0);
			item.shoot = ModContent.ProjectileType<PocketBlackhole>();
			item.shootSpeed = 30f;
			item.rare = ItemRarityID.Red;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket Blackhole");
			Tooltip.SetDefault("'So small but so powerful!'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "袖珍黑洞");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“麻雀虽小，五脏俱全”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Карманная чёрная дыра");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Такая маленькая, но такая мощная!'");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LastPrism)
				.AddIngredient(ItemID.NebulaArcanum)
				.AddIngredient(3457, 14)
				.AddIngredient(3467, 12)
				.AddIngredient(null, "WrathElement", 12)
				.AddTile(412)
				.Register();
		}
	}
}
