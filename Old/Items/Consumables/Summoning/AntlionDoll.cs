using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Summoning
{
	public class AntlionDoll : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
			item.rare = ItemRarityID.White;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Doll");
			Tooltip.SetDefault("Summons the Antlion Queen");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кукла муравьиного льва");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает Королеву муравьиных львов");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮玩偶");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤蚁后");
		}


		public override bool CanUseItem(Player player)
		{
			return player.ZoneDesert && NPC.downedQueenBee && !NPC.AnyNPCs(ModContent.NPCType<AntlionQueen>());
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Silk, 10)
				.AddIngredient(ItemID.AntlionMandible, 6)
				.AddIngredient(ItemID.ShadowScale, 15)
				.AddIngredient(null, "WrathElement", 3)
				.AddIngredient(null, "BloodDroplet", 10)
				.AddTile(86)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(ItemID.Silk, 10)
				.AddIngredient(ItemID.AntlionMandible, 6)
				.AddIngredient(ItemID.TissueSample, 15)
				.AddIngredient(null, "WrathElement", 3)
				.AddIngredient(null, "BloodDroplet", 10)
				.AddTile(86)
				.Register();
		}

		public override bool UseItem(Player player)
		{
			SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<AntlionQueen>());
			}
			return true;
		}
	}
}
