using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] GameObject[] platforms;
    [SerializeField] ParticleSystem collisionParticles;
    [SerializeField] AudioSource src;
    public bool isPlayerAlive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            isPlayerAlive = false;

            src.Play();//play hit sound

            collisionParticles.Play();//trigger hit particles

            movement.enabled = false;

            FindObjectOfType<GameManager>().gameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            FindObjectOfType<GameManager>().nextLevelScr();
        }

        if (other.CompareTag("spawnSection"))
        {
            Instantiate(platforms[Random.Range(0,4)], new Vector3(0, 0, 500), Quaternion.identity);
        }
    }
}
