using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Summoning
{
	public class PocketCursedMirror : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.maxStack = 20;
			item.rare = ItemRarityID.LightRed;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket Cursed Mirror");
			Tooltip.SetDefault("Summons the Tower Keeper");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Карманное проклятое зеркало");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает Хранителя башни");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "袖珍魔镜");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤守塔魔像");
		}


		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && player.ZoneCorrupt && !NPC.AnyNPCs(ModContent.NPCType<TowerKeeperNonActive>()) && !NPC.AnyNPCs(ModContent.NPCType<TowerKeeper>()) && !NPC.AnyNPCs(ModContent.NPCType<TowerKeeper2>());
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteBar, 12)
				.AddIngredient(ItemID.SoulofNight, 6)
				.AddIngredient(null, "MirrorShard", 4)
				.AddIngredient(null, "ShadowChargedCrystal", 3)
				.AddIngredient(ItemID.Glass, 10)
				.AddTile(16)
				.Register();
		}

		public override bool UseItem(Player player)
		{
			SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<TowerKeeper2>());
			}
			return true;
		}
	}
}
