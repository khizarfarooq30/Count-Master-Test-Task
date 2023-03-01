using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float amplitude = 1f;  
    public float frequency = 1f; 
    public float speed = 1f;     

    private float startX;         
    private float currTime;      

    private void Start()
    {
        startX = transform.position.x; 
    }

    private void Update()
    {
        float x = startX + amplitude * Mathf.Sin(currTime * frequency);
        var position = transform.position;
        position = Vector3.MoveTowards(position, new Vector3(x, position.y, position.z), speed * Time.deltaTime);
        transform.position = position;
        currTime += Time.deltaTime;
    }

}
