using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class ForestClaymore : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 54;
			item.height = 66;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 0, 16, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forest Claymore");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Лесной клеймор");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "森林大砍刀");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "若击中敌人将在原地召唤一个可以伤害敌人的灌木丛");
			Tooltip.SetDefault("Hitting enemies will spawn a bush that damages enemies");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Удар по врагам призывает куст, наносящий урон врагам");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
			this.SetTag(ItemTags.Flammable);
			this.SetTag(ItemTags.BluntHit);
		}*/

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int k = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<LeafBush>(), damage / 3, knockback, player.whoAmI, 0.0f, 0.0f);
			Main.projectile[k].ranged = false;
			Main.projectile[k].melee = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "NatureEssence", 17)
				.AddIngredient(null, "Leaf", 28)
				.AddIngredient(ItemID.Wood, 35)
				.AddTile(16)
				.Register();
		}
	}
}
