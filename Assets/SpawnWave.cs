using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObject Resources;
    public GameObject CrewMember;
    public float PositionOffset = 2;

    private void Start()
    {
        var shipResources = Resources.GetComponent<ShipResources>();

        var xOffset = 0f;
        for (var i = 0; i < shipResources.Crew; i++)
        {
            Instantiate(CrewMember, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), transform.rotation);
            xOffset += PositionOffset;
        }
    }
}
