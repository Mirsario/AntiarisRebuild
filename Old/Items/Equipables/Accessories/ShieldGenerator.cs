using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class ShieldGenerator : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 34;
			item.value = Item.sellPrice(0, 11, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Generator");
			Tooltip.SetDefault("Deflects enemy's projectiles\nProjectiles still deal damage to player");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "护盾发生器");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、反射敌人的抛射物\n2、抛射物仍然能够伤害玩家");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Генератор щита");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Отражает снаряды врагов\nСнаряды всё равно наносят урон игроку");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.mirrorShield = true;
			if (!player.dead)
			{
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Shield>()] < 1)
					Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<Shield>(), 0, 0, player.whoAmI);
			}
		}
	}
}
