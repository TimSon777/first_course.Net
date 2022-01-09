namespace UI.Models.UnionModels
{
    public class CharacterMonster
    {
        public readonly CharacterModel Character;

        public readonly MonsterModel Monster;

        public CharacterMonster(CharacterModel character, MonsterModel monster)
        {
            Character = character;
            Monster = monster;
        }

        public CharacterMonster()
        { }
    }
}