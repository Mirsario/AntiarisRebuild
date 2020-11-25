using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Bags
{
	public class RobberSack : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.width = 38;
			item.height = 42;
			item.rare = ItemRarityID.White;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Robber's Sack");
			Tooltip.SetDefault("<right> to open");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "土匪的袋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "<right>来打开");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сумка грабителя");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "<right>, чтобы открыть");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(15, 90));
			player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(15, 50));
			if (Main.rand.Next(25) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<IronCoin>(), Main.rand.Next(1, 2));
			}
			if (Main.rand.Next(3) == 0)
			{
				int rand = Main.rand.Next(0, 7);
				if (rand == 0)
				{
					player.QuickSpawnItem(703, Main.rand.Next(16, 24));
				}
				else if (rand == 1)
				{
					player.QuickSpawnItem(20, Main.rand.Next(16, 24));
				}
				else if (rand == 2)
				{
					player.QuickSpawnItem(22, Main.rand.Next(16, 24));
				}
				else if (rand == 3)
				{
					player.QuickSpawnItem(704, Main.rand.Next(16, 24));
				}
				else if (rand == 4)
				{
					player.QuickSpawnItem(21, Main.rand.Next(16, 24));
				}
				else if (rand == 5)
				{
					player.QuickSpawnItem(705, Main.rand.Next(16, 24));
				}
				else if (rand == 6)
				{
					player.QuickSpawnItem(19, Main.rand.Next(16, 24));
				}
				else if (rand == 7)
				{
					player.QuickSpawnItem(706, Main.rand.Next(16, 24));
				}
				if (Main.hardMode)
				{
					int rand2 = Main.rand.Next(0, 5);
					if (rand2 == 0)
					{
						player.QuickSpawnItem(381, Main.rand.Next(16, 24));
					}
					else if (rand2 == 1)
					{
						player.QuickSpawnItem(1184, Main.rand.Next(16, 24));
					}
					else if (rand2 == 2)
					{
						player.QuickSpawnItem(382, Main.rand.Next(16, 24));
					}
					else if (rand2 == 3)
					{
						player.QuickSpawnItem(1191, Main.rand.Next(16, 24));
					}
					else if (rand2 == 4)
					{
						player.QuickSpawnItem(1198, Main.rand.Next(16, 24));
					}
					else if (rand2 == 5)
					{
						player.QuickSpawnItem(391, Main.rand.Next(16, 24));
					}
				}
			}
			if (Main.rand.Next(3) == 0)
			{
				if (NPC.downedMechBossAny)
				{
					player.QuickSpawnItem(1225, Main.rand.Next(16, 24));
				}
			}
			if (Main.rand.Next(3) == 0)
			{
				if (NPC.downedPlantBoss)
				{
					player.QuickSpawnItem(1006, Main.rand.Next(16, 24));
				}
			}
			if (Main.rand.Next(7) == 0)
			{
				int rand3 = Main.rand.Next(0, 5);
				if (rand3 == 0)
				{
					player.QuickSpawnItem(ItemID.Sapphire, Main.rand.Next(3, 7));
				}
				else if (rand3 == 1)
				{
					player.QuickSpawnItem(ItemID.Ruby, Main.rand.Next(2, 4));
				}
				else if (rand3 == 2)
				{
					player.QuickSpawnItem(ItemID.Amethyst, Main.rand.Next(4, 8));
				}
				else if (rand3 == 3)
				{
					player.QuickSpawnItem(ItemID.Emerald, Main.rand.Next(3, 7));
				}
				else if (rand3 == 4)
				{
					player.QuickSpawnItem(ItemID.Topaz, Main.rand.Next(3, 7));
				}
				else if (rand3 == 5)
				{
					player.QuickSpawnItem(ItemID.Diamond, Main.rand.Next(2, 4));
				}
			}
		}
	}
}
