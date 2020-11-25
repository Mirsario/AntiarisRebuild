using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class HoneyBadger : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Badger");
			Tooltip.SetDefault("Getting hit covers the player in a thick layer of honey for 5 seconds\nThe honey layer increases health regeneration and reduces damage taken by 30%\nGetting hit destroys the layer and makes it go on cooldown\nGrants immunity to knockback");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медоед");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Имеет шанс защитить игрока медовым слоем на 5 секунд при получении урона\nМедовый слой повышает восстановление здоровья и снижает получаемый урон\nПолучение урона уничтожает слой\nДаёт иммунитет к отбрасыванию");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.honeyBadger = true;
			player.noKnockback = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CobaltShield)
				.AddIngredient(null, "MellifiedSkull")
				.AddIngredient(null, "HoneyExtract", 14)
				.AddIngredient(ItemID.HoneyBlock, 10)
				.AddTile(114)
				.Register();
		}
	}
}