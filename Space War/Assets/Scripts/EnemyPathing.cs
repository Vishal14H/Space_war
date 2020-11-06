using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move() 
    {
        if (waypointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}