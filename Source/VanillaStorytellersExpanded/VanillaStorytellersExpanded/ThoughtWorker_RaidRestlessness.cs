﻿using RimWorld;
using Verse;

namespace VanillaStorytellersExpanded
{
	public class ThoughtWorker_RaidRestlessness : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p.FactionOrExtraMiniOrHomeFaction == Faction.OfPlayer)
            {
				var options = Find.Storyteller.def.GetModExtension<StorytellerDefExtension>();
				if (options != null && options.raidRestlessness != null)
				{
					var stageIndex = options.raidRestlessness.GetThoughtState();
					//Log.Message("this.def.stages.Count: " + this.def.stages.Count, true);
					//Log.Message("stageIndex: " + stageIndex, true);
					if (stageIndex == -1)
					{
						return ThoughtState.Inactive;
					}
					if (stageIndex > this.def.stages.Count - 1)
					{
						return ThoughtState.ActiveAtStage(this.def.stages.Count - 1);
					}
					return ThoughtState.ActiveAtStage(stageIndex);
				}
			}
			return ThoughtState.Inactive;
		}
	}
}
