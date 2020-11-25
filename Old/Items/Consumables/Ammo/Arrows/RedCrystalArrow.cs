using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
	public class RedCrystalArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 20;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 18;
			item.height = 46;
			item.shoot = ModContent.ProjectileType<RedCrystalArrow>();
			item.shootSpeed = 7.0f;
			item.knockBack = 8.0f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Pink;
			item.ammo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Crystal Arrow");
			Tooltip.SetDefault("Increased damage at the cost of piercing");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличенный урон ценой проникания");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Красная кристальная стрела");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "红水晶箭");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}
	}
}
