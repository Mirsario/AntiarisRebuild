using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class Nightfall : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 54;
			item.melee = true;
			item.width = 50;
			item.height = 54;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.5f;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<NightmareMagicCentral>();
			item.shootSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightfall");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сумерки");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "虚伪恶行");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一圈围绕着玩家旋转的梦魇之火\n“我听到了....像是孩子的悲鸣声...”");
			Tooltip.SetDefault("Summons a circle of nightmare flames around the player on swing");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "При взмахе призывает кольцо из кошмарного пламени вокруг игрока");
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
				.AddIngredient(ItemID.NightsEdge, 1)
				.AddIngredient(ItemID.SoulofNight, 12)
				.AddIngredient(null, "WrathElement", 6)
				.AddIngredient(ItemID.CursedFlame, 25)
				.AddTile(134)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.NightsEdge, 1)
				.AddIngredient(ItemID.SoulofNight, 12)
				.AddIngredient(null, "WrathElement", 6)
				.AddIngredient(ItemID.Ichor, 25)
				.AddTile(134)
				.Register();

			if (AntiarisMod.Thorium != null && ModContent.TryFind<ModItem>($"{AntiarisMod.Thorium.Name}/BloodThirster", out ModItem bloodThirster))
			{
				CreateRecipe()
					.AddIngredient(bloodThirster)
					.AddIngredient(ItemID.SoulofNight, 12)
					.AddIngredient(null, "WrathElement", 6)
					.AddIngredient(ItemID.Ichor, 25)
					.AddTile(134)
					.Register();
			}
		}
	}
}
