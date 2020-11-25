using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class LivingontheEdge : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Living on the Edge");
			Description.SetDefault("Davy Jones's Pendant won't save you from death");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "生死边缘");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "戴维·琼斯的垂饰现在救不了你的命");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Хождение по острию ножа");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Кулон Дэйви Джонса не спасёт вас от смерти");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			canBeCleared = false;
			Main.persistentBuff[Type] = true;
		}
	}
}
