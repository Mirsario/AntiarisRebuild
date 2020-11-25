using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
	[AutoloadEquip(EquipType.Legs)]
	public class AntlionLeggings : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 4;
			item.value = Item.sellPrice(0, 1, 10, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Leggings");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮护腿");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Поножи муравьиного льва");
			Tooltip.SetDefault("4% increased minion damage\nIncreases movement speed\nGrants immunity to sandstorm wind");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, " 1、增加 4% 召唤伤害\n2、增加移动速度\n3、免疫沙尘暴天气");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает урон миньонов на 4%\nУвеличивает скорость передвижения\nДаёт иммунитет к ветру песчаной бури");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.04f;
			player.buffImmune[194] = true;
			player.accRunSpeed = 10f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.AntlionMandible, 2)
				.AddIngredient(ItemID.BeeGreaves)
				.AddIngredient(null, "AntlionCarapace", 14)
				.AddTile(16)
				.Register();
		}
	}
}
