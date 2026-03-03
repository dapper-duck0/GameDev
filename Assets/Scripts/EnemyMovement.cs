using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Random rnd = new Random();
    void start()
    {
        public Vector3 targetPosition = new Vector3(randomX, 0f, RandomZ); 
        public float speed = 5f;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            RandomPositionGen();
            public Vector3 targetPosition = new Vector3(randomX, 0f, RandomZ); 
        }
    }
    int RandomPositionGen()
    {
        int randomZ = rnd.Next(1, 26);
        int randomX = rnd.Next(1, 26);
    }
}