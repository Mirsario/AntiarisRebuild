using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning
{
	public class StardustMothercellStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 200;
			item.mana = 10;
			item.width = 48;
			item.height = 48;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 21, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<StardustMothercell>();
			item.summon = true;
			item.sentry = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Mothercell Staff");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох материнской клетки звездной пыли");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "星尘母体细胞法杖");
			Tooltip.SetDefault("Summons a stardust mothercell\nMothercell shoot fast moving homing stardust energy at your enemies");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个快速向敌人发射跟踪性星尘能量的星尘母体细胞");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает материнскую клетку звёздной пыли\nКлетка стреляет во врагов быстродвигающейся самонаводящейся энергией звёздной пыли");
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				List<Projectile> projectileList = new List<Projectile>();
				for (int k = 0; k < 1000; k++)
				{
					if (Main.projectile[k].WipableTurret)
						projectileList.Add(Main.projectile[k]);
				}
				int projectiles = 0;
				while (projectileList.Count >= player.maxTurrets && ++projectiles < 1000)
				{
					Projectile projectile = projectileList[0];
					for (int k = 1; k < projectileList.Count; k++)
					{
						if (projectileList[k].timeLeft < projectile.timeLeft)
							projectile = projectileList[k];
					}
					projectile.Kill();
					projectileList.Remove(projectile);
				}
			}
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim(true);
			}
			return base.UseItem(player);
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			return player.altFunctionUse != 2;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RainbowCrystalStaff)
				.AddIngredient(ItemID.StardustCellStaff)
				.AddIngredient(3459, 14)
				.AddIngredient(3467, 12)
				.AddIngredient(null, "WrathElement", 12)
				.AddTile(412)
				.Register();
		}
	}
}
