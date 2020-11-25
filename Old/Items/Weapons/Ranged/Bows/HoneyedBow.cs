using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
	public class HoneyedBow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 40;
			item.DamageType = DamageClass.Ranged;
			item.width = 20;
			item.height = 42;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6f;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honeyed Bow");
			Tooltip.SetDefault("Transforms arrows into honeyed arrows");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовый лук");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Превращает стрелы в медовые");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Bow);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<HoneyedArrow>();
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Antiaris:CopperBow")
				.AddIngredient(null, "HoneyExtract", 16)
				.AddIngredient(ItemID.HoneyBlock, 8)
				.AddIngredient(ItemID.BottledHoney, 5)
				.AddTile(134)
				.Register();
		}
	}
}
