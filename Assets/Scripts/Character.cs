using System.Collections.Generic;
using UnityEngine;
namespace BigRedPlanetGames.WereAlive
{
    public class Character : MonoBehaviour
    {
        public CharacterData characterData;
        public Skills skills;
        public Dictionary<string, int> characterSkills;

        void Start()
        {
            skills = new Skills();
            characterSkills = new Dictionary<string, int>()
        {
            { "Shooting", skills.shooting },
            { "Melee", skills.melee },
            { "Social", skills.social },
            { "Animals", skills.animals },
            { "Medicine", skills.medicine },
            { "Cooking", skills.cooking },
            { "Construction", skills.construction },
            { "Growing", skills.growing },
            { "Mining", skills.mining },
            { "Artistic", skills.artistic },
            { "Crafting", skills.crafting },
            { "Intellectual", skills.intellectual }
        };
    }
        
        void Update() // disable click to move to stop from controlling them
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Winston" || hit.transform.name == "Izzy")
                {
                    if (Input.GetMouseButtonDown(0)) //if we click on the player
                    {
                        hit.transform.gameObject.SendMessageUpwards("SwitchCharacter", true, SendMessageOptions.DontRequireReceiver);
                    }
                }
                else
                {
                    Debug.Log("This isn't a Player");
                }
            }
        }
    }
}
