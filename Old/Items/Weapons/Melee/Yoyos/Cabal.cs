using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class Cabal : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 13;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<Cabal1>();
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 36;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.useStyle = ItemUseStyleID.HoldingOut;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cabal");
			Tooltip.SetDefault("Throws out two yoyos at the same time");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "政治阴谋");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "同时抛出两个yoyo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Интрига");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выпускает сразу два йо-йо одновременно");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Cabal2>(), damage, knockBack, player.whoAmI);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DarkShard, 1)
				.AddIngredient(ItemID.LightShard, 1)
				.AddIngredient(ItemID.WoodYoyo, 2)
				.AddIngredient(ItemID.SoulofLight, 6)
				.AddIngredient(ItemID.SoulofNight, 6)
				.AddTile(134)
				.Register();
		}
	}
}
