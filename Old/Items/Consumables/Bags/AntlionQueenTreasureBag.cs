using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Bags
{
	public class AntlionQueenTreasureBag : ModItem
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

		public override int BossBagNPC => ModContent.NPCType<AntlionQueen>();

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
			player.QuickSpawnItem(ModContent.ItemType<AntlionQueenClaw>());
			player.QuickSpawnItem(ItemID.GoldCoin, 6);
			player.QuickSpawnItem(ModContent.ItemType<SandstormScroll>(), Main.rand.Next(2, 4));
			player.QuickSpawnItem(ModContent.ItemType<AntlionCarapace>(), Main.rand.Next(30, 50));

			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<AntlionQueenMask>());
			}
			switch (Main.rand.Next(4))
			{
				case 0:
					player.QuickSpawnItem(ModContent.ItemType<DesertRage>());
					break;
				case 1:
					player.QuickSpawnItem(ModContent.ItemType<ThousandNeedles>());
					break;
				case 2:
					player.QuickSpawnItem(ModContent.ItemType<AntlionLongbow>());
					break;
				case 3:
					player.QuickSpawnItem(ModContent.ItemType<AntlionStave>());
					break;
			}
			if (Main.rand.Next(20) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<AntlionQueenEgg>());
			}
		}
	}
}