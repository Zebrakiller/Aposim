/// <summary>
/// Inherited from CharacterData (which is the master class for players and enemies), set the variables we need for our Characters.
/// We will be using the "trickle down effect" - only move the data a step up if all classes that are children of the parent need.
/// </summary>

using UnityEngine;

namespace BigRedPlanetGames.WereAlive {
    [System.Serializable]
    [CreateAssetMenu(fileName = "ColonistData", menuName = "Character/ColonistData", order = 2)]
    public class ColonistData : CharacterData
    {
        [Header("ColonistData")]
        public string characterName;
        public int charNumber;
        public Survivor survivor;
    }
}
