using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class Note2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Note");
			Tooltip.SetDefault("'Somebody has written something on it.'\nUse to read");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "纸条");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "有人在上面写了些东西\n鼠标 <左> 键阅读");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Записка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Кто-то на ней что-то написал.'\nИспользуйте для прочтения");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.White;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.useTurn = true;
		}

		public override bool UseItem(Player player)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.OpenWindow3 = !aPlayer.OpenWindow3;
			return true;
		}
	}
}
