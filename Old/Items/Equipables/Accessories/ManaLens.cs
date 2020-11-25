using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class ManaLens : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 38;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Lens");
			Tooltip.SetDefault("Attacks has a chance to inflict Lovestruck effect on enemies\nGrants a chance to restore mana when hitting an enemy which is under Lovestruck effect");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔力晶状体");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、攻击有概率对敌人造成“坠入爱河”效果\n2、击中获得“坠入爱河”效果下的敌人时，有概率恢复魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Линза маны");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Атаки имеют шанс наложить эффект Влюблённости на врагов\nДаёт шанс восстановить ману при ударе по врагу, находящемуся под эффектом Влюблённости");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.manaPrism = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Glass, 25)
				.AddIngredient(ItemID.CrystalShard, 12)
				.AddIngredient(ItemID.ManaCrystal, 2)
				.AddIngredient(ItemID.SoulofLight, 6)
				.AddTile(125)
				.Register();
		}
	}
}