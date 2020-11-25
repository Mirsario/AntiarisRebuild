using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Flamethrowers
{
	public class CursedFlamethrower : ModItem
	{
		public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask");
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale);
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.DamageType = DamageClass.Ranged;
			item.width = 98;
			item.height = 46;
			item.useTime = 6;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 1;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<CursedFlames>();
			item.shootSpeed = 8f;
			item.value = Item.buyPrice(0, 11, 0, 0);
			item.useAmmo = AmmoID.Gel;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Flamethrower");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "咒火喷火器");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Проклятый огнемёт");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 4);
		}

		public override bool ConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < item.useAnimation - 2);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Flamethrower)
				.AddIngredient(ItemID.CursedFlame, 15)
				.AddIngredient(ItemID.SoulofNight, 6)
				.AddIngredient(ItemID.HallowedBar, 10)
				.AddTile(134)
				.Register();
		}
	}
}
