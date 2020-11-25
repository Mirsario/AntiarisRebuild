using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class RubyRose : ModItem
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
			item.damage = 14;
			item.magic = true;
			item.mana = 4;
			item.width = 40;
			item.height = 56;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 18, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<RubyRoseBolt>();
			item.shootSpeed = 8f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruby Rose");
			Tooltip.SetDefault("Shoots ruby bolts with little spread\nBolts can restore some health");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "玫瑰红珀");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、不稳定的发射跟踪性红珀箭\n2、红珀箭击中敌人后有概率将造成伤害的一部分回复生命值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Рубиновая роза");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает рубиновыми снарядами с небольшим разбросом\nСнаряды могут восстановить немного здоровья");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 75f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 15)
				.AddIngredient(ItemID.Ruby)
				.AddIngredient(null, "NatureEssence", 8)
				.AddIngredient(null, "Leaf", 10)
				.AddTile(16)
				.Register();
		}
	}
}
