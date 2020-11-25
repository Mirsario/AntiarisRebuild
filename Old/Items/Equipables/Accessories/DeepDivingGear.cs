using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class DeepDivingGear : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deep Diving Gear");
			Tooltip.SetDefault("Grants the ability to swim\nAutomatically uses oxygen tanks when needed\nProvides light when worn");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "深潜水装置");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、赋予游泳的能力2、\n必要时自动使用氧气罐3、\n佩戴时照亮周围");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Глубоководное снаряжение акваланга");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Позволяет плавать в воде\nАвтоматически использует баки с кислородом, когда необходимо\nОсвещает территорию вокруг игрока");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accDivingHelm = true;
			player.accFlipper = true;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.scuba = true;
			Lighting.AddLight(player.Top, Color.Blue.ToVector3() * 0.7f);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DivingGear)
				.AddIngredient(null, "ScubaGear")
				.AddIngredient(ItemID.MiningHelmet)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
