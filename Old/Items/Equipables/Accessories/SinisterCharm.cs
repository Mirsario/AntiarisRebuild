using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class SinisterCharm : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 40;
			item.rare = ItemRarityID.Lime;
			item.value = Item.buyPrice(0, 8, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sinister Charm");
			Tooltip.SetDefault("Minions inflict shadowflame on enemies\nIncreases your max number of minions\n10% increased minion damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "凶兆饰物");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、召唤物会对敌人施加暗影火\n2、增加召唤物上限\n3、增加 10% 召唤物伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зловещее ожерелье");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Миньоны накладывают на врагов теневое пламя\nУвеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 10%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.shadowflameCharm = true;
			player.minionDamage += 0.1f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "ShadowflameCharm")
				.AddIngredient(null, "PrimeNecklace")
				.AddTile(114)
				.Register();
		}
	}
}
