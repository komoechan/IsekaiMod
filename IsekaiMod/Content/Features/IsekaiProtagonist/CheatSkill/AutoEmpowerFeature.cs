﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.CheatSkill
{
    class AutoEmpowerFeature
    {
        public static void Add()
        {
            var Icon_EmpowerSpell = Resources.GetBlueprint<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e").m_Icon;
            var AutoEmpowerBuff = Helpers.CreateBlueprint<BlueprintBuff>("AutoEmpowerBuff", bp => {
                bp.SetName("Cheat Skill — Auto Empower");
                bp.SetDescription("Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.SpellOnly;
                    c.Metamagic = Metamagic.Extend;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var AutoEmpowerAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("AutoEmpowerAbility", bp => {
                bp.SetName("Cheat Skill — Auto Empower");
                bp.SetDescription("Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.m_Buff = AutoEmpowerBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.MetamagicRod;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = false;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var AutoEmpowerFeature = Helpers.CreateBlueprint<BlueprintFeature>("AutoEmpowerFeature", bp => {
                bp.SetName("Cheat Skill — Auto Empower");
                bp.SetDescription("Every time you cast a spell, it becomes empowered, as though using the Empower Spell feat.");
                bp.m_Icon = Icon_EmpowerSpell;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { AutoEmpowerAbility.ToReference<BlueprintUnitFactReference>() };
                });
                bp.IsClassFeature = true;
            });
        }
    }
}
