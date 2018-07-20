using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;

namespace BigRedPlanetGames.WereAlive
{
    [Serializable]
    public class GameController : MonoBehaviour
    {
        private int health, food, damage;
        private int health2, food2, damage2;
        public int partySize;
        public int characterName = (int)CharacterName.BobSaget;
        public int characterName2 = (int)CharacterName.ChrisJohnson;
        public Dictionary<string, GameObject> Party = new Dictionary<string, GameObject>();
        public Dictionary<string, int> resources, characterData;
        public Dictionary<string, int> resources2, characterData2;
        public List<Character> character;
        public static GameController instance { get; private set; }
        private static string gameDataFilePath = "D:/Test/";
        string[] filePaths = Directory.GetFiles(gameDataFilePath, "*.json");
        Dictionary<string, Dictionary<string, int>> player1Data = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, Dictionary<string, int>> player2Data = new Dictionary<string, Dictionary<string, int>>();

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SaveData();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                LoadData();
            }
        }
        private void Start()
        {
            //for (int i = 0; i < partySize; i++)
            {
                resources = new Dictionary<string, int>()
        {
            {"health", health },
            {"food", food },
            {"damage", damage }
        };
                characterData = new Dictionary<string, int>()
        {
            {"characterName", characterName }
        };
                resources2 = new Dictionary<string, int>()
        {
            {"health2", health2 },
            {"food2", food2 },
            {"damage2", damage2 }
        };
                characterData2 = new Dictionary<string, int>()
        {
            {"characterName2", characterName2 }
        };
                player1Data.Add("resources", resources);
                player1Data.Add("characterData", characterData);
                player2Data.Add("resources2", resources2);
                player2Data.Add("characterData2", characterData2);
            }
            LoadData();
        }
        private void LoadData()
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (File.Exists(filePaths[i]))
                {
                    Dictionary<string, int> loadedData = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(filePaths[i]));
                    foreach (string key in loadedData.Keys) //TODO turn into switch/case
                    {
                        if (resources.ContainsKey(key))
                        {
                            resources[key] = loadedData[key];
                        }
                        else if (characterData.ContainsKey(key))
                        {
                            characterData[key] = loadedData[key];
                        }
                        if (resources2.ContainsKey(key))
                        {
                            resources2[key] = loadedData[key];
                        }
                        else if (characterData2.ContainsKey(key))
                        {
                            characterData2[key] = loadedData[key];
                        }
                        if (character[0].characterSkills.ContainsKey(key))
                        {
                            character[0].characterSkills[key] = loadedData[key];
                        }
                        if (character[1].characterSkills.ContainsKey(key))
                        {
                            character[1].characterSkills[key] = loadedData[key];
                        }
                    }
                }
            }
            SetData();
            Debug.Log("We are done with Loading Data");
        }
        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Health/Food + 100"))
            {
                resources["health"] += 100;
                resources["food"] += 100;
                resources2["health2"] += 50;
                resources2["food2"] += 50;
                SetData();
            }
            if (GUI.Button(new Rect(10, 110, 150, 100), "Damage + 10"))
            {
                resources["damage"] += 10;
                resources2["damage2"] += 20;
                SetData();
            }
            if (GUI.Button(new Rect(1000, 310, 150, 100), "Shooting + 1"))
            {
                character[0].characterSkills["Shooting"] += 1;
                character[1].characterSkills["Shooting"] += 3;
                SetData();
            }
            if (GUI.Button(new Rect(160, 10, 150, 100), "Save Data"))
            {
                SaveData();
            }
            if (GUI.Button(new Rect(160, 110, 150, 100), "Load Data"))
            {
                LoadData();
            }

            GUI.Label(new Rect(50, 210, 150, 100), text:"Health: " + resources["health"]);
            GUI.Label(new Rect(50, 310, 150, 100), text:"Food: " + resources["food"]);
            GUI.Label(new Rect(50, 410, 150, 100), text:"Damage: " + resources["damage"]);
            GUI.Label(new Rect(50, 510, 150, 100), text:"Character Name: " + characterData["characterName"]);

            GUI.Label(new Rect(250, 210, 150, 100), text: "Health2: " + resources2["health2"]);
            GUI.Label(new Rect(250, 310, 150, 100), text: "Food2: " + resources2["food2"]);
            GUI.Label(new Rect(250, 410, 150, 100), text: "Damage2: " + resources2["damage2"]);
            GUI.Label(new Rect(250, 510, 150, 100), text: "Character Name2: " + characterData2["characterName2"]);

            GUI.Label(new Rect(50, 610, 150, 100), text:"Character Shooting: " + character[0].characterSkills["Shooting"]);
            GUI.Label(new Rect(50, 710, 150, 100), text:"Character Shooting2: " + character[1].characterSkills["Shooting"]);
        }
        private void SetData()
        {
            // winston data
            player1Data["resources"] = new Dictionary<string, int>(resources);
            player1Data["characterData"] = new Dictionary<string, int>(characterData);
            player1Data["characterSkills"] = new Dictionary<string, int>(character[0].characterSkills);
            //izzy data
            player2Data["resources2"] = new Dictionary<string, int>(resources2);
            player2Data["characterData2"] = new Dictionary<string, int>(characterData2);
            player2Data["characterSkills2"] = new Dictionary<string, int>(character[1].characterSkills);

            health = resources["health"];
            food = resources["food"];
            damage = resources["damage"];

            health2 = resources2["health2"];
            food2 = resources2["food2"];
            damage2 = resources2["damage2"];

            characterName = characterData["characterName"];
            characterName2 = characterData2["characterName2"];

            character[0].skills.shooting = character[0].characterSkills["Shooting"];
            character[1].skills.shooting = character[1].characterSkills["Shooting"];
        }
        private void SaveData()
        {
            player1Data.Clear();
            player2Data.Clear();
            SetData();

            int count = 0;
            foreach (Dictionary<string, int> dictionary in player1Data.Values)
            {
                string filename = "data" + count + ".json";
                string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
                File.WriteAllText(gameDataFilePath + filename, json);
                count++;
            }
            foreach (Dictionary<string, int> dictionary in player2Data.Values)
            {
                string filename = "data" + count + ".json";
                string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
                File.WriteAllText(gameDataFilePath + filename, json);
                count++;
            }
            Debug.Log("Saved game!");
        }
    }
}