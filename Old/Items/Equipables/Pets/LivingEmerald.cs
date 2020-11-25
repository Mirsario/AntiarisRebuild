using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class LivingEmerald : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shoot = mod.ProjectileType(GetType().Name);
			item.width = 28;
			item.height = 28;
			item.UseSound = SoundID.Item8;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 4);
			item.buffType = mod.BuffType(GetType().Name);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Emerald");
			Tooltip.SetDefault("Summons a bouncy emerald");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "活翡翠");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个弹弹翡翠");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Живой изумруд");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает прыгающий изумруд");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}