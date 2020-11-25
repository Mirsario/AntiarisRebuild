using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Bags
{
	public class DeadlyJonesTreasureBag : ModItem
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

		public override int BossBagNPC => ModContent.NPCType<DeadlyJones>();

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
			player.QuickSpawnItem(ItemID.GoldCoin, 8);
			player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(4, 12));
			player.QuickSpawnItem(ModContent.ItemType<RoyalWeaponParts>(), 6);
			player.QuickSpawnItem(ModContent.ItemType<DavysMap>());
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<DeadlyJonesMask>());
			}
		}
	}
}