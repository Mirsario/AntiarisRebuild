using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class DarkMoon : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 76;
			item.melee = true;
			item.width = 54;
			item.height = 60;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 9f;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<TrueNightmareMagicCentral>();
			item.shootSpeed = 22f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Moon");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Тёмная луна");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "至白之夜");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在光标周围召唤一圈梦魇火焰\n“黑暗面，真相，无法逃脱的悲剧”");
			Tooltip.SetDefault("Summons a circle of nightmare flames around the cursor");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает кольцо из кошмарного пламени вокруг курсора");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "Nightfall", 1)
				.AddIngredient(ItemID.BrokenHeroSword, 1)
				.AddTile(134)
				.Register();
		}
	}
}
