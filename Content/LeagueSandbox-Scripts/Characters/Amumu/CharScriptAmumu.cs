using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Scripting.CSharp;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using LeagueSandbox.GameServer.GameObjects.SpellNS;
using LeagueSandbox.GameServer.API;
using GameServerLib.GameObjects.AttackableUnits;

namespace CharScripts
{
    public class CharScriptAmumu : ICharScript
    {
        Spell Spell;
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Spell = spell;
            {
                ApiEventManager.OnHitUnit.AddListener(this, owner, OnHitUnit, false);
            }
        }
        public void OnHitUnit(DamageData damageData)
        {
            var owner = Spell.CastInfo.Owner;
            var target = damageData.Target;
            AddBuff("CursedTouch", 2.5f, 1, Spell, target, owner);
        }
        public void OnDeactivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnHitUnit.RemoveListener(this);
        }
    }
}