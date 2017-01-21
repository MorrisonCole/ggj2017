using UnityEngine;

public class RotationClamp : MonoBehaviour
{
    public int MinimumX;
    public int MaximumX;

    private void Update()
    {
        transform.localRotation = ClampRotationAroundXAxis(transform.localRotation);
    }

    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

        angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
