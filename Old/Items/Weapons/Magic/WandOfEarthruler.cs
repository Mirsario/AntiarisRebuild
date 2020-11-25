using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class WandOfEarthruler : ModItem
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
			item.damage = 21;
			item.magic = true;
			item.mana = 4;
			item.width = 36;
			item.height = 36;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0.0f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item69;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<NatureBeam>();
			item.shootSpeed = 6f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of Earthruler");
			Tooltip.SetDefault("Casts a damaging beam of earth energy\n'Forged with Terra'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "自然统领之杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "发射具有破坏性的自然能量射线\n“大地之造物”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох природы");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выпускает наносящий урон луч земной энергии\n'Сковано из Терры'");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Bone, 3)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Lens, 3)
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddIngredient(ItemID.Emerald, 10)
				.AddIngredient(ItemID.ManaCrystal)
				.AddTile(TileID.DemonAltar)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Bone, 3)
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddIngredient(ItemID.Lens, 3)
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddIngredient(ItemID.Emerald, 10)
				.AddIngredient(ItemID.ManaCrystal)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}
