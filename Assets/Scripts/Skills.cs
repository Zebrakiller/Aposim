using UnityEngine;
namespace BigRedPlanetGames.WereAlive
{
    [CreateAssetMenu(fileName = "CharacterSkills", menuName = "Character/CharacterSkills", order = 1)]
    [System.Serializable]
    public class Skills : ScriptableObject
    {
        public int shooting, melee, social, animals, medicine, cooking, construction, growing, mining, artistic, crafting, intellectual;
    }
}
