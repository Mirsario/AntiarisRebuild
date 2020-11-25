using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Boomerangs
{
	public class GoldBoomerang : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 24;
			item.height = 46;
			item.useTime = 20;
			item.shootSpeed = 10f;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3f;
			item.shoot = ModContent.ProjectileType<GoldBoomerang>();
			item.value = Item.sellPrice(0, 0, 16, 0);
			item.rare = ItemRarityID.Green;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Boomerang");
			Tooltip.SetDefault("Shoots magical sparks at nearby enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "金回旋镖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "对附近的敌人发射魔法火花");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Золотой бумеранг");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает магическими искрами в ближайших врагов");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Boomerang);
		}*/

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
				{
					return false;
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.WoodenBoomerang, 1)
				.AddIngredient(ItemID.GoldBar, 12)
				.AddIngredient(ItemID.Ruby, 3)
				.AddTile(16)
				.Register();
		}
	}
}
