using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObject Resources;
    public float PositionOffset = 2;
    public float TimeBetweenWaves = 0.2f;

    private ShipResources shipResources;

    private void Start()
    {
        shipResources = Resources.GetComponent<ShipResources>();

        var currentCrew = GetCurrentCrew();
        currentCrew.Shuffle();

        var xOffset = 0f;
        foreach (var crewMember in currentCrew)
        {
            crewMember.SetActive(true);
            crewMember.transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
            xOffset += PositionOffset;
        }

        StartCoroutine(MexicanWave(currentCrew));
    }

    private List<GameObject> GetCurrentCrew()
    {
        var currentCrew = new List<GameObject>();
        for (int i = 0; i < shipResources.Crew.transform.childCount; i++)
        {
            currentCrew.Add(shipResources.Crew.transform.GetChild(i).gameObject);
        }
        return currentCrew;
    }

    private IEnumerator MexicanWave(List<GameObject> currentCrew)
    {
        while (true)
        {
            foreach (var crewMember in currentCrew)
            {
                crewMember.GetComponentInChildren<WaveBehaviour>().Wave();
                yield return new WaitForSeconds(TimeBetweenWaves);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
