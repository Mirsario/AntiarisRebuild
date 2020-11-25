using Antiaris.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class SwordOfBlackWhite : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.damage = 56;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.4f;
			item.value = Item.sellPrice(0, 11, 25, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<YinYang>();
			item.shootSpeed = 4.4f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword of Black & White");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "阴阳长剑");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“汇阳合阴 心安觉天静”——《随缘》");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Меч чёрного и белого");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NightsEdge)
				.AddIngredient(ItemID.LightShard, 2)
				.AddIngredient(ItemID.DarkShard, 2)
				.AddIngredient(ItemID.SoulofNight, 9)
				.AddIngredient(ItemID.SoulofLight, 9)
				.AddTile(134)
				.Register();
		}
	}
}
