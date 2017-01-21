using UnityEngine;

public class WaveBehaviour : MonoBehaviour, IWaveBehaviour
{
    public int WavePower = 215;

    public void Wave()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * WavePower);
    }
}

public interface IWaveBehaviour
{
    void Wave();
}