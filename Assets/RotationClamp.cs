using UnityEngine;

public class RotationClamp : MonoBehaviour
{
    public int MinRotation;
    public int MaxRotation;

    private void Update()
    {
        var rotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(rotation.x, MinRotation, MaxRotation), rotation.y, rotation.z);
    }
}
