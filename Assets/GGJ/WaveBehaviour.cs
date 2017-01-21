using UnityEngine;

public class WaveBehaviour : MonoBehaviour
{
    public void Wave()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 5);
    }
}