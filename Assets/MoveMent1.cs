using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody2D rgb;
    float speedAmount = 15f;
    public float jumpForce = 0.1f;

    bool canDoubleJump = true; // Add a flag to track if the player can double jump
    bool oyunDevam = true;
    bool isDeath=false;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oyunDevam && isDeath ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (oyunDevam)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
            transform.position += velocity * speedAmount * Time.deltaTime;
            doubleJumper();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

    void doubleJumper()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Mathf.Approximately(rgb.velocity.y, 0) || canDoubleJump) // Check if the player is on the ground or can double jump
            {
                if (!Mathf.Approximately(rgb.velocity.y, 0) && canDoubleJump)
                {
                    canDoubleJump = false; // Disable double jump after the first jump
                }
                rgb.velocity = new Vector3(rgb.velocity.x, 0); // Reset vertical velocity to avoid adding up
                rgb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

            }
        }
    }

    // OnCollisionStay2D is called once per frame for every collider2D/rigidbody2D that is touching rigidbody2D/collider2D
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            canDoubleJump = true;


        }
        if (col.gameObject.tag == "coin")
        {
            print("tebrikler");
            oyunDevam = false;

        }
        if (col.gameObject.tag == "DGround")
        {
            isDeath= true;
        }
    }

}
