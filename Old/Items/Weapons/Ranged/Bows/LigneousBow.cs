using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
	public class LigneousBow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 6;
			item.DamageType = DamageClass.Ranged;
			item.width = 24;
			item.height = 50;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<LigneousArrow>();
			item.shootSpeed = 7f;
			item.value = Item.sellPrice(0, 0, 14, 0);
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ligneous Bow");
			Tooltip.SetDefault("Uses arrows as ammo\nTransforms arrows into lingeous arrows\nLingeous arrows explode into magic bushes that damage enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "木本植物");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、将所有的箭变成木本植物\n2、木本植物箭接触物体爆炸后会出现魔法灌木丛伤害敌人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Древесный лук");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует стрелы в качестве патронов\nПревращает стрелы в древесные стрелы\nДревесные стрелы взрываются в магические кусты, наносящие урон врагам");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Bow);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = ModContent.ProjectileType<LigneousArrow>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "NatureEssence", 15)
				.AddIngredient(null, "Leaf", 22)
				.AddIngredient(ItemID.Wood, 30)
				.AddTile(16)
				.Register();
		}
	}
}
