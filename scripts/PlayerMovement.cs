using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forewardForce = 2000f;
    [SerializeField] float SidewaysForce = 200f;
    [SerializeField] bool endless = false;
    [SerializeField] bool leftTouchPressed = false;
    [SerializeField] bool rightTouchPressed = false;

    private float screenWidth;

    PlayerCollision PC;
    
    private void Start()
    {
        screenWidth = Screen.width;
        PC = FindObjectOfType<PlayerCollision>();
    }

    void Update()
    {
        if (!endless)
        rb.AddForce(0, 0, forewardForce * Time.deltaTime);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) || leftTouchPressed)
        {
            rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || rightTouchPressed)
        {
            rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1)
        {
            PC.isPlayerAlive = false;

            FindObjectOfType<GameManager>().gameOver();

            this.enabled = false;
        }
        
    }
    public void leftMoveDown()
    {
        leftTouchPressed = true;
        rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        Debug.Log("Left down");
    }
    public void rightMoveDown()
    {
        rightTouchPressed = true;
        rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        Debug.Log("Right down");
    }
    public void leftMoveUp()
    {
        leftTouchPressed = false;
        Debug.Log("left UP");
    }
    public void rightMoveUp()
    {
        rightTouchPressed = false;
        Debug.Log("right UP");
    }

}
