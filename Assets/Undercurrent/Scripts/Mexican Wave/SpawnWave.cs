using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObject Resources;
    public float PositionOffset = 2;
    public float TimeBetweenWaves = 0.2f;

    private ShipResources shipResources;
    private List<GameObject> currentCrew;

    private void Start()
    {
        shipResources = Resources.GetComponent<ShipResources>();

        currentCrew = shipResources.GetCurrentCrew();
        currentCrew.Shuffle();

        var xOffset = -currentCrew.Count / 2f * PositionOffset;
        foreach (var crewMember in currentCrew)
        {
            crewMember.SetActive(true);
            crewMember.transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
            xOffset += PositionOffset;
        }

        StartWave(null);
    }

    public void StartWave(Action<float> onWaveEnd)
    {
        StartCoroutine(MexicanWave(onWaveEnd));
    }

    private IEnumerator MexicanWave(Action<float> onWaveEnd)
    {
        while (true)
        {
            foreach (var crewMember in currentCrew)
            {
                crewMember.GetComponentInChildren<IWaveBehaviour>().Wave(onWaveEnd);
                yield return new WaitForSeconds(TimeBetweenWaves);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
