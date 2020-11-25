using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class Buckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 4;
			item.width = 14;
			item.maxStack = 999;
			item.height = 14;
			item.rare = ItemRarityID.White;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 1.4f;
			item.ammo = ModContent.ItemType<Buckshot>();
			item.value = Item.sellPrice(0, 0, 0, 4);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "用于火铳");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Buckshot>();
		}
	}
}
