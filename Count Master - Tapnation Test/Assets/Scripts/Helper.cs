using UnityEngine;

public static class Helper
{
    public static Vector3 GetAngularPosition(int index, float radius, float angle)
    {
        float x = Mathf.Sqrt(index) * radius * Mathf.Cos(angle * index * Mathf.Deg2Rad);
        float z = Mathf.Sqrt(index) * radius * Mathf.Sin(angle * index * Mathf.Deg2Rad);
        return new Vector3(x, 0f, z);
    }
}