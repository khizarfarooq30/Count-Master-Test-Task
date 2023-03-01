using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Obstacle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;

        MeshCollider meshCollider = GetComponent<MeshCollider>();
        
        if (meshCollider != null)
        {
            Destroy(meshCollider);
        }
    }
}
