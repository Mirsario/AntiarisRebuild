using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class PrivateerStave : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 17;
			item.magic = true;
			item.mana = 6;
			item.width = 78;
			item.height = 78;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 2f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Privateer's Stave");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох капера");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "私掠者的魔杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、发射水晶尖刺\n2、点击鼠标右键可以召唤一个水晶，它也会在你光标所在的区域发射水晶尖刺");
			Tooltip.SetDefault("Shoots out crystal spikes\n<right> to summon a crystal that will also shoot crystal spikes at your cursor");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает кристальными шипами\n<right>, чтобы призвать кристал, который будет выстреливать кристальными шипами в курсор");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				foreach (Projectile i in Main.projectile)
					if (i.type == ModContent.ProjectileType<RoyalCrystal>())
					{
						i.Kill();
					}
				item.shoot = ModContent.ProjectileType<RoyalCrystal>();
				item.shootSpeed = 0f;
			}
			else
			{
				item.shoot = ModContent.ProjectileType<RoyalCrystalSpike>();
				item.shootSpeed = 6f;
			}
			return base.CanUseItem(player);
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "RoyalWeaponParts", 6)
				.AddTile(16)
				.Register();
		}
	}
}
