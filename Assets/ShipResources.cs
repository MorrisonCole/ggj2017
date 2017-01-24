using System.Collections.Generic;
using UnityEngine;

public class ShipResources : MonoBehaviour
{
    public GameObject Crew;
    public int FoodCount;

    public List<GameObject> GetCurrentCrew()
    {
        var crew = new List<GameObject>();
        for (var i = 0; i < Crew.transform.childCount; i++)
        {
            crew.Add(Crew.transform.GetChild(i).gameObject);
        }
        return crew;
    }
}
