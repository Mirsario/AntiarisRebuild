using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class CrystalGun : ModItem
	{
		private byte uses = 0;

		/*public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(Mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask");
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, Mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale);
		}*/

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.Shoot;
			item.useAnimation = 13;
			item.useTime = 13;
			item.width = 54;
			item.height = 32;
			item.shoot = ProjectileID.PurificationPowder;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.damage = 32;
			item.DamageType = DamageClass.Ranged;
			item.autoReuse = true;
			item.knockBack = 2.5f;
			item.shootSpeed = 7.0f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 7, 35, 0);
			item.rare = ItemRarityID.Pink;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Gun");
			Tooltip.SetDefault("Every second shot creates an additional bullet\n10% chance not to consume ammo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "水晶枪");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、开火时每秒都会额外发射一枚子弹\n2、10% 的概率不消耗弹药");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кристальная пушка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Каждый второй выстрел создает дополнительную пулю\n10% шанс не потратить пулю");
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .10f;
		}

		public override bool CanUseItem(Player player)
		{
			uses++;

			if (uses > 2)
			{
				uses = 1;
			}

			return true;
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(uses);
		}

		public override void NetReceive(BinaryReader reader)
		{
			uses = reader.ReadByte();
		}

		public override TagCompound Save()
		{
			return new TagCompound { { "u", uses } };
		}

		public override void Load(TagCompound tag)
		{
			uses = tag.GetByte("u");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (uses == 1)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.Ranged.CrystalBullet>(), damage - 5, knockBack, player.whoAmI, type, 0.0f);
			}
			else
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage + 5, knockBack, player.whoAmI);
			}

			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PhoenixBlaster)
				.AddIngredient<Materials.BlueBigCrystal>(5)
				.AddIngredient<Materials.GreenCrystalPixieDust>(20)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
