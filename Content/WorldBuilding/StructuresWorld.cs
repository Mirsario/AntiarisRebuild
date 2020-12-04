using System.Collections.Generic;
using Antiaris.Content.WorldBuilding.Structures;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Antiaris.Content.WorldBuilding
{
	public class StructuresWorld : ModWorld
	{
		private GuideHouseStructure GuideHouse;

		public override void Initialize()
		{
			GuideHouse = new GuideHouseStructure(Mod);
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int index = tasks.FindIndex(x => x.Name == "Planting Trees");
			if (index != -1)
			{
				tasks.Insert(index, new PassLegacy("[Antiaris] Guide House", GuideHouse.Generate));
			}
		}
	}
}
