using Antiaris.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class StaffOfBlackWhite : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.damage = 41;
			item.magic = true;
			item.mana = 13;
			item.width = 52;
			item.height = 52;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2.3f;
			item.value = Item.sellPrice(0, 4, 25, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<YinYangCentral>();
			item.shootSpeed = 5.0f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Staff of Black & White");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "阴阳杖");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох чёрного и белого");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MagicMissile)
				.AddIngredient(ItemID.LightShard, 2)
				.AddIngredient(ItemID.DarkShard, 2)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddTile(134)
				.Register();
		}
	}
}
