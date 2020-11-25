using Antiaris.NPCs.Town;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace Antiaris.Items.Quests
{
	public class AdventurersFishingRod : QuestItem
	{
		public AdventurersFishingRod()
		{
			questItem = true;
			uniqueStack = true;
			maxStack = 1;
			rare = -11;
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.GoldenFishingRod);
			item.width = 40;
			item.height = 34;
			item.fishingPole = 100;
			item.shoot = ProjectileID.None;
			item.useAnimation = 30;
			item.useTime = 30;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adventurer's Fishing Rod");
			Tooltip.SetDefault("'It doesn't look too strong...'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "冒险家鱼竿");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“看起来不太强...”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Удочка Путешественника");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Не выглядит слишком крепкой...'");
		}

		public override bool UseItem(Player player)
		{
			string RodBroken = Language.GetTextValue("Mods.Antiaris.RodBroken", Main.LocalPlayer.name);
			if (player.itemAnimation >= 20)
			{
				QuestSystem.BrokenRod = true;
				item.stack = 0;
				Item.NewItem((int)player.position.X - 64, (int)player.position.Y, player.width, player.height, ModContent.ItemType<AdventurersFishingRodPart1>(), 1, false, 0, false, false);
				Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<AdventurersFishingRodPart2>(), 1, false, 0, false, false);
				Item.NewItem((int)player.position.X + 60, (int)player.position.Y, player.width, player.height, ModContent.ItemType<AdventurersFishingRodPart3>(), 1, false, 0, false, false);
				Main.NewText(RodBroken, 255, 255, 255);
				SoundEngine.PlaySound(3, (int)player.position.X, (int)player.position.Y, 4);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "AdventurersFishingRodPart1")
				.AddIngredient(null, "AdventurersFishingRodPart2")
				.AddIngredient(null, "AdventurersFishingRodPart3")
				.AddTile(18)
				.Register();
		}
	}
}
