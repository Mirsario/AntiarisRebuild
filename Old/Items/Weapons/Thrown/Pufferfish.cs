using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class Pufferfish : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 30;
			item.damage = 12;
			item.thrown = true;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Pufferfish>();
			item.shootSpeed = 9f;
			item.consumable = true;
			item.maxStack = 999;
			item.rare = ItemRarityID.White;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pufferfish");
			Tooltip.SetDefault("Sticks to enemies dealing damage\nExplodes into bubbles");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Иглобрюх");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Втыкается во врагов, нанося урон\nВзрывается в пузыри");
		}

		public override void PostUpdate()
		{
			if (item.wet)
			{
				if (item.velocity.Y > 0.86f)
				{
					item.velocity.Y = item.velocity.Y * 0.9f;
				}
				item.velocity.Y = item.velocity.Y - 0.6f;
				if (item.velocity.Y < -2f)
				{
					item.velocity.Y = -2f;
				}
			}
		}
	}
}
