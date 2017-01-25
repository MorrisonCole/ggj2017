using System.Collections.Generic;
using UnityEngine;

namespace Undercurrent.Scripts.Resources
{
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
}
