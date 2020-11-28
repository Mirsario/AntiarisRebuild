using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Antiaris.Content.Gores
{
	public class BoarGore : ModGore
	{
		public override void OnSpawn(Gore gore)
		{
			gore.Frame = new SpriteFrame(1, 4)
			{
				PaddingY = 0
			};
		}
	}
}
