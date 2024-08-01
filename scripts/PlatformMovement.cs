using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 70f;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, moveSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("despawnSection"))
        {
            Destroy(gameObject);
        }
    }
}
