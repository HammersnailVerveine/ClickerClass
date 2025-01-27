﻿using Terraria;

namespace ClickerClass.Utilities
{
	internal static partial class NPCHelper
	{
		/// <summary>
		/// Check if this NPC is tied to the healthpool of another NPC. Sets the parent if it exists.
		/// </summary>
		public static bool IsChild(this NPC npc, out NPC parent)
		{
			bool child = npc.realLife != npc.whoAmI && npc.realLife >= 0 && npc.realLife <= Main.maxNPCs;
			parent = child ? Main.npc[npc.realLife] : null;
			return child;
		}

		/// Copy of NPC.CanBeChasedBy without the active check. Use in contexts where the NPC might not be active anymore (such as OnHitNPC).
		/// </summary>
		/// <param name="npc">The NPC.</param>
		/// <param name="attacker">The attacker (unused).</param>
		/// <param name="ignoreDontTakeDamage">If dontTakeDamage should be ignored.</param>
		/// <returns>True if chaseable, max life > 5, not friendly, and can take damage.</returns>
		public static bool IsHostile(this NPC npc, object attacker = null, bool ignoreDontTakeDamage = false)
		{
			if (/*npc.active && */!npc.friendly && npc.lifeMax > 5 && npc.chaseable && (!npc.dontTakeDamage || ignoreDontTakeDamage))
				return !npc.immortal;

			return false;
		}
	}
}
