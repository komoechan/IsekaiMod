﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes
{
    class EdgeLord
    {
        public static void Add()
        {
            // Archetype features
            var EdgeLordProficiencies = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordProficiencies");
            var SupersonicCombat = Resources.GetModBlueprint<BlueprintFeature>("SupersonicCombat");
            var EdgeLordFastMovement = Resources.GetModBlueprint<BlueprintFeature>("EdgeLordFastMovement");
            var ExtraStrike = Resources.GetModBlueprint<BlueprintFeature>("ExtraStrike");
            var CripplingStrike = Resources.GetBlueprint<BlueprintFeature>("b696bd7cb38da194fa3404032483d1db");
            var DispellingAttack = Resources.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c");

            // Removed features
            var IsekaiProtagonistProficiencies = Resources.GetModBlueprint<BlueprintFeature>("IsekaiProtagonistProficiencies");
            var IsekaiFastMovement = Resources.GetModBlueprint<BlueprintFeature>("IsekaiFastMovement");
            var FriendlyAuraFeature = Resources.GetModBlueprint<BlueprintFeature>("FriendlyAuraFeature");
            var TrueMainCharacter = Resources.GetModBlueprint<BlueprintFeature>("TrueMainCharacter");
            var TrainingArcSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("TrainingArcSelection");

            // Archetype
            var EdgeLordArchetype = Helpers.CreateBlueprint<BlueprintArchetype>("EdgeLordArchetype", bp => {
                bp.LocalizedName = Helpers.CreateString($"EdgeLordArchetype.Name", "Edge Lord");
                bp.LocalizedDescription = Helpers.CreateString($"EdgeLordArchetype.Description", "After reincarnating into Golarion, some protagonists use their newfound abilities "
                    + "to look cool and stylish. Their attacks become flashy and myriad, moving so fast that side characters would be lucky to even see the afterimage.");
                bp.LocalizedDescriptionShort = Helpers.CreateString($"EdgeLordArchetype.Description", "After reincarnating into Golarion, some protagonists use their newfound abilities "
                    + "to look cool and stylish. Their attacks become flashy and myriad, moving so fast that side characters would be lucky to even see the afterimage.");
                bp.RemoveSpellbook = false;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, IsekaiProtagonistProficiencies),
                    Helpers.LevelEntry(5, TrainingArcSelection),
                    Helpers.LevelEntry(8, IsekaiFastMovement),
                    Helpers.LevelEntry(9, FriendlyAuraFeature),
                    Helpers.LevelEntry(10, TrainingArcSelection),
                    Helpers.LevelEntry(15, TrainingArcSelection),
                    Helpers.LevelEntry(20, TrueMainCharacter),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.LevelEntry(1, EdgeLordProficiencies, SupersonicCombat),
                    Helpers.LevelEntry(5, ExtraStrike),
                    Helpers.LevelEntry(7, EdgeLordFastMovement),
                    Helpers.LevelEntry(8, CripplingStrike),
                    Helpers.LevelEntry(10, ExtraStrike, DispellingAttack),
                    Helpers.LevelEntry(15, ExtraStrike),
                    Helpers.LevelEntry(20, ExtraStrike),
                };
                bp.OverrideAttributeRecommendations = true;
                bp.RecommendedAttributes = new StatType[] { StatType.Dexterity, StatType.Charisma };
            });

            // Add Archetype to Class
            var IsekaiProtagonistClass = Resources.GetModBlueprint<BlueprintCharacterClass>("IsekaiProtagonistClass");
            IsekaiProtagonistClass.m_Archetypes = IsekaiProtagonistClass.m_Archetypes.AppendToArray(EdgeLordArchetype.ToReference<BlueprintArchetypeReference>());
        }
    }
}
