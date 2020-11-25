using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class WandOfFirestorm : ModItem
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
			item.damage = 24;
			item.magic = true;
			item.mana = 14;
			item.width = 36;
			item.height = 36;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2.0f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item73;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<Hellbat>();
			item.shootSpeed = 6.0f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of Firestorm");
			Tooltip.SetDefault("Casts homing explosive bats at enemies\n'Forged with Ignis'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "炎暴法杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "发射跟踪敌人的自爆蝙蝠\n“炽焰之造物”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох огненного шторма");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выпускает самонаводящихся взрывоопасных мышей в противников\n'Сковано из Игниса'");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.FireDamage);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40.0f;
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Bone, 3)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Lens, 3)
				.AddIngredient(ItemID.Meteorite, 10)
				.AddIngredient(ItemID.Ruby, 10)
				.AddIngredient(ItemID.ManaCrystal)
				.AddTile(TileID.DemonAltar)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Bone, 3)
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddIngredient(ItemID.Lens, 3)
				.AddIngredient(ItemID.Meteorite, 10)
				.AddIngredient(ItemID.Ruby, 10)
				.AddIngredient(ItemID.ManaCrystal)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}
