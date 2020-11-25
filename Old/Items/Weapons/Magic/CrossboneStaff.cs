using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class CrossboneStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 44;
			item.magic = true;
			item.mana = 9;
			item.width = 46;
			item.height = 46;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<ClumpofBones>();
			item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crossbone Staff");
			Tooltip.SetDefault("Summons an exploding clump of bones");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "交叉骨杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个爆炸骸骨丛");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох перекрещенных костей");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает взрывающуюся груду костей");
		}
	}
}
