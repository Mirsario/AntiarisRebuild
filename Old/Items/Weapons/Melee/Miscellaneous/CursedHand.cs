using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Miscellaneous
{
	public class CursedHand : ModItem
	{
		byte Uses = 0;

		public override bool CloneNewInstances => true;

		public override void SetDefaults()
		{
			item.damage = 45;
			item.melee = true;
			item.width = 46;
			item.height = 48;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 8;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Hand");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "咒怨钢爪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Проклятая рука");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.type == ModContent.ProjectileType<CursedHand>() && projectile.active && projectile.owner == player.whoAmI)
				{
					return false;
				}
			}
			Uses++;
			if (Uses == 4)
			{
				item.shoot = ModContent.ProjectileType<CursedHand>();
				item.shootSpeed = 13f;
				item.noUseGraphic = true;
				item.noMelee = true;
			}
			else if (Uses >= 5)
			{
				Uses = 0;
				item.shoot = ProjectileID.None;
				item.shootSpeed = 0f;
				item.noUseGraphic = false;
				item.noMelee = false;
			}
			return true;
		}
	}
}
