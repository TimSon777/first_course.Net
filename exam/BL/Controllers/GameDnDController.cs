using System.Collections.Generic;
using BL.Games.DnD.Creatures.Common;
using BL.Games.DnD.Input;
using BL.Games.DnD.Output;
using BL.Games.DnD.Settings;
using Microsoft.AspNetCore.Mvc;

namespace BL.Controllers
{
    [Route("[controller]")]
    public class GameDnDController : ControllerBase
    {
        private static readonly Dice CommonDice = new(20);

        [HttpPost]
        [Route("Play")]
        public ResultFight PostAsync([FromBody] GameData gameData)
        {
            var monster = gameData.Monster;
            monster.IsUser = false;
            var character = gameData.Character;
            character.IsUser = true;
            var diceMonster = new Dice(monster.Damage);
            var diceCharacter = new Dice(character.CountThrows);
            var initialHpCharacter = character.HitPoints;
            var initialHpMonster = monster.HitPoints;
            var motions = new List<Motion>();

            while (character.HitPoints > 0 && monster.HitPoints > 0)
            {
                if (character.HitPoints > 0)
                {
                    motions.Add(MakeMotion(character, monster, diceCharacter));
                }

                if (monster.HitPoints > 0)
                {
                    motions.Add(MakeMotion(monster, character, diceMonster));
                }
            }

            character.HitPoints = initialHpCharacter;
            monster.HitPoints = initialHpMonster;

            var result = new ResultFight
            {
                Character = character,
                Monster = monster,
                Motions = motions
            };

            return result;
        }

        public Motion MakeMotion(Characteristics striker, Characteristics defender, Dice dice)
        {
            var attacks = new List<Attack>();
            var points = CommonDice.Roll();


            for (var i = 0; i < striker.CountThrows && defender.HitPoints > 0; i++)
            {
                var isAttackSuccess = points != 1
                                      && (points + striker.AttackModifier >= defender.ArmorClass
                                          || points == 20);
                if (!isAttackSuccess)
                {
                    attacks.Add(new Attack
                    {
                        Damage = 0,
                        IsCriticalDamage = false,
                        IsCriticalMiss = points == 1
                    });
                    
                    continue;
                }
                var cf = points == 20 ? 2 : 1;

                var damage = cf * (dice.Roll() + striker.DamageModifier + striker.Weapon);
                defender.HitPoints -= damage;
                attacks.Add(new Attack
                {
                    Damage = damage,
                    IsCriticalDamage = points == 20,
                    IsCriticalMiss = false
                });
            }

            var motion = new Motion
            {
                IsUserMotion = striker.IsUser,
                Attacks = attacks
            };

            return motion;
        }
    }
}