using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class Arthur : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 13;
			item.width = 30;
			item.height = 26;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<Arthur>();
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 12;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.crit = 16;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arthur");
			Tooltip.SetDefault("Critical strikes summon piercing enchanted swords flying a random direction");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Артур");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Критические удары призывают проникающие зачарованные мечи, летящие в случайном направлении");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "EnchantedShard", 10)
				.AddIngredient(ItemID.WoodYoyo)
				.AddTile(16)
				.Register();
		}
	}
}
