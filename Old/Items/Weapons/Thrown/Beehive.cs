using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class Beehive : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 30;
			item.thrown = true;
			item.width = 32;
			item.height = 32;
			item.noUseGraphic = true;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<Beehive>();
			item.shootSpeed = 6f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 0, 0, 60);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beehive");
			Tooltip.SetDefault("Explodes into a swarm of wasps");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пчелиный улей");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Взрывается в рой ос");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}

		public override void AddRecipes()
		{
			CreateRecipe(25)
				.AddIngredient(ItemID.Beenade, 25)
				.AddIngredient(null, "HoneyExtract")
				.AddTile(134)
				.Register();
		}
	}
}
