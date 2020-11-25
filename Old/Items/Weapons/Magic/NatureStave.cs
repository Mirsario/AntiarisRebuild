using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class NatureStave : ModItem
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
			item.damage = 12;
			item.magic = true;
			item.mana = 7;
			item.width = 54;
			item.height = 66;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<NatureStaveCentral>();
			item.shootSpeed = 22f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature Stave");
			Tooltip.SetDefault("Summons a leaf storm around the cursor");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "大自然法杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在你的光标周围触发自然风暴");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох природы");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает лиственный шторм вокруг курсора");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, -6);
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 25)
				.AddIngredient(null, "Leaf", 15);
				.AddIngredient(null, "NatureEssence", 12)
				.AddIngredient(ItemID.Amethyst)
				.AddTile(16)
				.Register();
		}
	}
}
