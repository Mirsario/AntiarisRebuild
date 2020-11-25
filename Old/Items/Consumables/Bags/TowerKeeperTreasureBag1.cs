using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Bags
{
	public class TowerKeeperTreasureBag1 : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 36;
			item.height = 32;
			item.rare = ItemRarityID.Cyan;
			item.expert = true;
		}

		public override int BossBagNPC => ModContent.NPCType<TowerKeeper1>();

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("<right> to open");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宝藏袋");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "<right>来打开");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мешок с сокровищами");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "<right>, чтобы открыть");
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ItemID.GoldCoin, 11);
			player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(8, 13));
			player.QuickSpawnItem(ModContent.ItemType<MirrorShard>(), Main.rand.Next(10, 15));
			player.QuickSpawnItem(ModContent.ItemType<BloodyChargedCrystal>(), Main.rand.Next(15, 24));
			player.QuickSpawnItem(ModContent.ItemType<TimeParadoxCrystal>());
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<TowerKeeperMask1>());
			}
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<GuardianHeart>());
			}
		}
	}
}