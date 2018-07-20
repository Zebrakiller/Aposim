using System.Collections.Generic;
using UnityEngine;

public class Apartment : MonoBehaviour {
    int floorLevel;
    public Dictionary<string, Floor[]> Floors = new Dictionary<string, Floor[]>();
    public Dictionary<string, MeshRenderer[]> meshRenderers = new Dictionary<string, MeshRenderer[]>();
    void Start() {

        Floors = new Dictionary<string, Floor[]>() { { "Floor", GetComponentsInChildren<Floor>() } };
        for (int i = 0; i < Floors["Floor"].Length; i++)
        {
            meshRenderers.Add("Mesh" + floorLevel.ToString(), Floors["Floor"][floorLevel].GetComponentsInChildren<MeshRenderer>());
            RemoveActiveFloor(i);
            floorLevel++;
        }

        floorLevel = 0;
        SetActiveFloor(floorLevel);
    }
    private void RemoveActiveFloor(int floorLevel)
    {
        foreach (MeshRenderer mesh in meshRenderers["Mesh" + floorLevel.ToString()])
        {
            mesh.gameObject.SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && floorLevel < 11) 
        {
            RemoveActiveFloor(floorLevel);
            floorLevel++;
            SetActiveFloor(floorLevel);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && floorLevel > 0)
        {
            RemoveActiveFloor(floorLevel);
            floorLevel--;
            SetActiveFloor(floorLevel);
        }
    }

    private void SetActiveFloor(int floorLevel)
    {
        foreach (MeshRenderer mesh in meshRenderers["Mesh" + floorLevel.ToString()])
        {
            mesh.gameObject.SetActive(true);            
        }
    }
}
