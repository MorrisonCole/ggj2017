using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class InitialCrewSpawner : MonoBehaviour
{
    public GameObject Crew;
    public GameObject Captain;
    public List<GameObject> CrewMembers;
    public Vector2 MinimumSize;
    public Vector2 MaximumSize;
    public int StartingCrew;

    public Text CrewCount;
    public Text FoodCount;

    private void Start()
    {
        for (var i = 0; i < StartingCrew; i++)
        {
            var randomCrewMember = Random.Range(0, CrewMembers.Count);
            var crewMember = Instantiate(CrewMembers[randomCrewMember], Crew.transform);
            crewMember.transform.localScale = new Vector3(Random.Range(MinimumSize.x, MaximumSize.x), Random.Range(MinimumSize.y, MaximumSize.y), crewMember.transform.localScale.z);
            crewMember.SetActive(false);
        }

        Instantiate(Captain, Crew.transform).SetActive(false);
    }
}

public static class ListExtensions
{
    private static readonly System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}