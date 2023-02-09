using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;

    [SerializeField] private float jumpVelocity;
    [SerializeField] private int numberOfJumps = 2;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float stoppingDistance;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D rb;
    private float gravityScale;
    private int privateNumberOfJumps;

    int playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        privateNumberOfJumps = numberOfJumps;
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
        Jumping();
    }

    private void Walking()
    {
        if (Input.GetKey(KeyCode.D)) // detect while walking is the player input
        {
            transform.position += transform.right * Time.deltaTime * MovementSpeed; // Time.deltaTime, it does not depend on the performance of your computer
            transform.rotation = Quaternion.Euler(0, 0, 0); // set the rotation of game object
            playerDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * Time.deltaTime * MovementSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0); //change y rotation to 180
            playerDirection = -1;
        }
    }

    private void Jumping()
    {
        var isGrounded = CheckIfGrounded();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Space) && numberOfJumps > 0))
        {
            rb.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            numberOfJumps--;
        }
    }

    private bool CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider) {
            numberOfJumps = privateNumberOfJumps;
            return true;
        }

        else return false;
    }

    private bool CheckIfPlayerShouldStop(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, stoppingDistance, wallLayer);

        if (hit.collider) return true;
        else return false;
    }

    public int ReturnPlayerDirection()
    {
        return playerDirection;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Fruit"))
        {
            other.GetComponent<FruitCollectable>().CallPrint();
            Destroy(other.gameObject);
        }
    }
}