using System.Collections;
using UnityEditor;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] float Speed = 10f;

    int direction = 1;

    void Update()
    {
        Vector3 target = currentMovementTarget();

        platform.position = Vector3.Lerp(platform.position, target, Speed * Time.deltaTime);

        float distance = (target - (Vector3)platform.position).magnitude;

        if (distance <= 0.1)
        {
            direction *= -1;
        }
    }

    Vector3 currentMovementTarget()
    {
        if(direction == 1)
        {
            return startPos.position;
        }
        else
        {
            return endPos.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPos != null && endPos != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPos.position);
            Gizmos.DrawLine(platform.transform.position, endPos.position);
        }
    }
}
