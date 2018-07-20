using UnityEngine;

namespace BigRedPlanetGames.WereAlive
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Character/CharacterData", order = 1)]

    [System.Serializable]
    public class CharacterData : ScriptableObject
    {
        [Header("Character Data")]
        public int health;
        public int damage;
        public int food;
    }
}
