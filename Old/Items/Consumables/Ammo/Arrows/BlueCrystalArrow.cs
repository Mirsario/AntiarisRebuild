using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
	public class BlueCrystalArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 12;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 18;
			item.height = 46;
			item.shoot = ModContent.ProjectileType<BlueCrystalArrow>();
			item.shootSpeed = 14.0f;
			item.knockBack = 3.0f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Pink;
			item.ammo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Crystal Arrow");
			Tooltip.SetDefault("Fast velocity and pierces enemies infinitely");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Голубая кристальная стрела");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Быстрая и бесконечно проникающая");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蓝水晶箭");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}
	}
}
