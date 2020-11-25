using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class MonsterSkull : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.maxStack = 1;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<MonsterSkull>();
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Monster Skull");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "古生物骸骨");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Череп монстра");
		}
	}
}
