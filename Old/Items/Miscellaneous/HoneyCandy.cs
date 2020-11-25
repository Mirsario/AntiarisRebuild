using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
	public class HoneyCandy : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Star);
			item.width = 18;
			item.height = 18;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Candy");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовая конфетка");
		}

		public override bool ItemSpace(Player player)
		{
			return true;
		}

		public override bool CanPickup(Player player)
		{
			return true;
		}

		public override bool OnPickup(Player player)
		{
			SoundEngine.PlaySound(2, (int)player.position.X, (int)player.position.Y, 2);
			player.statLife += 10;
			player.AddBuff(BuffID.Honey, 300);
			if (Main.myPlayer == player.whoAmI)
				player.HealEffect(10);
			return false;
		}
	}
}
