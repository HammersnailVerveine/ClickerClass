using ClickerClass.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace ClickerClass.Items.Weapons.Clickers
{
	public class BurningSuperDeathClicker : ClickerWeapon
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();

			ClickEffect.Mania = ClickerSystem.RegisterClickEffect(Mod, "Mania", null, null, 8, new Color(200, 100, 0), delegate (Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, int type, int damage, float knockBack)
			{
				List<string> excluded = new List<string>
				{
					//ClickEffect.PartyTime,
				};

				List<ClickEffect> allowed = new List<ClickEffect>();

				foreach (var name in ClickerSystem.GetAllEffectNames())
				{
					if (!excluded.Contains(name) && ClickerSystem.IsClickEffect(name, out ClickEffect effect) && effect.PreHardMode)
					{
						allowed.Add(effect);
					}
				}

				if (allowed.Count == 0) return;

				ClickEffect random = Main.rand.Next(allowed);
				random.Action?.Invoke(player, source, position, type, damage, knockBack);
			},
			preHardMode: true);
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			SetRadius(Item, 2.75f);
			SetColor(Item, new Color(200, 100, 0));
			SetDust(Item, 6);
			AddEffect(Item, ClickEffect.Mania);

			Item.damage = 20;
			Item.width = 30;
			Item.height = 30;
			Item.knockBack = 1f;
			Item.value = 50000;
			Item.rare = 3;
		}
		
		public override void HoldItem(Player player)
		{
			player.GetModPlayer<ClickerPlayer>().itemBurningSuperDeath = true;
		}
	}
}
