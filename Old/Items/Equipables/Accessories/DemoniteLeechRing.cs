using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
	public class DemoniteLeechRing : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 40;
			item.value = Item.sellPrice(0, 0, 90, 15);
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonite Leech Ring");
			Tooltip.SetDefault("Summons a magical circle around the player\nKilling an enemy in the circle restores 5% of health\n10% decreased maximum amount of health");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "血蛭魔戒");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、在玩家周围召唤一个魔法圈\n2、在魔法圈内击杀敌人可以恢复 5% 的体力\n3、减少 10% 最大体力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Демонитовое кольцо кровососа");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает магическое кольцо вокруг игрока\nУбийство врага в кольце восстанавливает 5% здоровья\nНа 10% понижает максимальное количество здоровья");
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (player.GetModPlayer<AntiarisPlayer>(mod).ringEquip)
				return false;
			return true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).ringEquip = true;
			player.GetModPlayer<AntiarisPlayer>(mod).hRing = true;
			player.statLifeMax2 -= player.statLifeMax2 / 10;
			if (!hideVisual)
				for (int k = 0; k < 2; k++)
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType<LifeRingEffect>(), 0, 0.0f, player.whoAmI, k, 0.0f);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteBar, 15)
				.AddIngredient(ItemID.LifeCrystal, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
