using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int randomZ = 5;
    public int randomX = 5;
    public float speed = 5f;
    public Vector3 targetPosition;
    public void RandomPositionGen()
    {
        randomZ = UnityEngine.Random.Range(1, 26);
        randomX = UnityEngine.Random.Range(1, 26); 
    }
    
    void Start()
    {
        RandomPositionGen();
        targetPosition = new Vector3(randomX, 0f, randomZ);

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            RandomPositionGen();
            targetPosition = new Vector3(randomX, 0f, randomZ);
        }
    }

}