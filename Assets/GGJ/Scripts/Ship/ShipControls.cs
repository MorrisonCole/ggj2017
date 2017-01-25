using UnityEngine;

public class ShipControls : MonoBehaviour
{
    public float Speed = 1;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + Vector3.right * (Time.deltaTime * horizontal * Speed);
    }
}
