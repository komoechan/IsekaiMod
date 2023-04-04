﻿using IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Overlord;
using IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Classes.IsekaiProtagonist.Archetypes {

    internal class OverlordArchetype {
        private static readonly LocalizedString Name = Helpers.CreateString(IsekaiContext, $"OverlordArchetype.Name", "Overlord");
        private static readonly LocalizedString Description = Helpers.CreateString(IsekaiContext, $"OverlordArchetype.Description",
            "After obtaining ungodly amounts of power, some protagonists become Overlords. They view the new world as theirs to play with, "
            + "and the new inhabitants as theirs to torment. Overlords seek to increase their power even further, often by establishing their own kingdom.");

        public static void Add() {
            // Archetype features
            var OverlordProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverlordProficiencies");
            var DarkAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "DarkAuraFeature");
            var OverpoweredAbilitySelectionOverlord = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "OverpoweredAbilitySelectionOverlord");
            var CorruptAuraFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "CorruptAuraFeature");
            var SecondFormFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondFormFeature");
            var IsekaiChannelNegativeEnergyFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiChannelNegativeEnergyFeature");

            // Removed features
            var IsekaiBonusFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiBonusFeatSelection");
            var IsekaiProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiProficiencies");
            var IsekaiAuraSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "IsekaiAuraSelection");
            var ReleaseEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "ReleaseEnergy");
            var Gifted = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "Gifted");
            var SecretPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecretPowerSelection");
            var HaxSelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "HaxSelection");
            var SignatureMoveSelectionBonus = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SignatureMoveSelectionBonus");
            var SecondReincarnation = BlueprintTools.GetModBlueprint<BlueprintFeature>(IsekaiContext, "SecondReincarnation");
            var OverpoweredAbilitySelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "OverpoweredAbilitySelection");
            var SpecialPowerSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "SpecialPowerSelection");

            // Archetype
            var OverlordArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(IsekaiContext, "OverlordArchetype", bp => {
                bp.LocalizedName = Name;
                bp.LocalizedDescription = Description;
                bp.LocalizedDescriptionShort = Description;
                bp.IsArcaneCaster = true;
                bp.IsDivineCaster = true;
                bp.ChangeCasterType = true;
                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, IsekaiBonusFeatSelection, IsekaiProficiencies, Gifted, LegacySelection.GetClassFeature()),
                    Helpers.CreateLevelEntry(2, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(3, ReleaseEnergy),
                    Helpers.CreateLevelEntry(4, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(6, IsekaiBonusFeatSelection, SignatureMoveSelectionBonus),
                    Helpers.CreateLevelEntry(8, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(10, IsekaiBonusFeatSelection, OverpoweredAbilitySelection, IsekaiAuraSelection, SecretPowerSelection),
                    Helpers.CreateLevelEntry(12, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(14, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(15, SecondReincarnation),
                    Helpers.CreateLevelEntry(16, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(18, IsekaiBonusFeatSelection),
                    Helpers.CreateLevelEntry(20, IsekaiBonusFeatSelection, HaxSelection),
                };
                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, OverlordProficiencies, OverpoweredAbilitySelectionOverlord, OverlordLegacySelection.getClassFeature()),
                    Helpers.CreateLevelEntry(3, IsekaiChannelNegativeEnergyFeature),
                    Helpers.CreateLevelEntry(5, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(9, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(10, CorruptAuraFeature, DarkAuraFeature),
                    Helpers.CreateLevelEntry(13, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(17, OverpoweredAbilitySelectionOverlord),
                    Helpers.CreateLevelEntry(20, SecondFormFeature),
                };
                bp.AddComponent<PrerequisiteAlignment>(c => {
                    c.Group = Prerequisite.GroupType.Any;
                    c.Alignment = AlignmentMaskType.Evil;
                });
                bp.m_ReplaceSpellbook = OverlordSpellbook.GetReference();
            });

            // Add Archetype to Class
            IsekaiProtagonistClass.RegisterArchetype(OverlordArchetype);
        }

        public static BlueprintArchetype Get() {
            return BlueprintTools.GetModBlueprint<BlueprintArchetype>(IsekaiContext, "OverlordArchetype");
        }

        public static BlueprintArchetypeReference GetReference() {
            return Get().ToReference<BlueprintArchetypeReference>();
        }
    }
}