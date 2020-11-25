using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class TowerShield : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 28;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tower Shield");
			Tooltip.SetDefault("Has 33% chance to deflect enemy's projectiles\nProjectiles deal 50% less damage to player\nGrants immunity to knockback");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Башенный щит");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Имеет 33% шанс отразить снаряды врагов\nСнаряды наносят на 50% меньше урона игроку\nДаёт иммунитет к отбрасыванию");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.towerShield = true;
			player.noKnockback = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "EnchantedShard", 12)
				.AddIngredient(ItemID.CobaltShield)
				.AddTile(16)
				.Register();
		}
	}
}
