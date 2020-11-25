using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Miscellaneous
{
	public class AntlionQueenClaw : ModItem
	{
		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 24;
			item.width = 58;
			item.height = 62;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 9;
			item.crit = 8;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.expert = true;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<FriendlySandnado>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Queen Claw");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Клешня Королевы муравьиных львов");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁后爪牙");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、引起沙暴\n2、被卷入沙暴的敌人会被气流抛向空中\n3、被沙暴的气流抛向空中的玩家回复生命值和法力值");
			Tooltip.SetDefault("Summons a sand tornado\nTornado deals damage to enemies and tosses them into the air\nTornado can toss players into the air while restoring health and mana");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает песчаное торнадо\nТорнадо наносит урон врагом и подбрасывает их в воздух\nТорнадо может подбросить игрока в воздух, восстанавливая ману и здоровье");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position = Main.MouseWorld;
			int posX = (int)(position.Y / 16f);
			int posY = (int)(position.X / 16f);
			int size = 100;
			if (posY < 10)
			{
				posY = 10;
			}
			if (posY > Main.maxTilesX - 10)
			{
				posY = Main.maxTilesX - 10;
			}
			if (posX < 10)
			{
				posX = 10;
			}
			if (posX > Main.maxTilesY - size - 10)
			{
				posX = Main.maxTilesY - size - 10;
			}
			for (int finPos = posX; finPos < posX + size; finPos++)
			{
				Tile tile = Main.tile[posY, finPos];
				if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
				{
					posX = finPos;
					break;
				}
			}
			if (player.ownedProjectileCounts[type] <= 2)
			{
				Projectile.NewProjectile(posY * 16 + 8, posX * 16 - 56, 0f, 0f, type, damage, knockBack, Main.myPlayer, 16f, 15f);
			}
			return false;
		}
	}
}
