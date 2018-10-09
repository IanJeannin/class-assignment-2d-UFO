using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    private int locked=0;
    public int dashMovement=10;

    private void Start()
    {
        speed = 10;
        SetCountText();
        count = 0;
        winText.text = "";
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (locked == 0)
        {
            speed = 10;
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                Dash();
            }
            rb2d.AddForce(movement * speed);
        }
        else
        {
            //speed = 0;
            //rb2d.AddRelativeForce(movement*speed);
            rb2d.Sleep();
            locked--;
        }
    }

    private void Dash()
    {
        
        if(Input.GetButton("Right")==true)
        {
            if(Input.GetButton("Up")==true)
            {
                Vector2 dash = new Vector2(dashMovement, dashMovement);
                rb2d.MovePosition(rb2d.position + dash);
            }
            else if(Input.GetButton("Down")==true)
            {
                Vector2 dash = new Vector2(dashMovement, -dashMovement);
                rb2d.MovePosition(rb2d.position + dash);
            }
            else
            {
                Vector2 dash = new Vector2(dashMovement, 0);
                rb2d.MovePosition(rb2d.position + dash);
            }
        }
        else if(Input.GetButton("Left")==true)
        {
            if (Input.GetButton("Up") == true)
            {
                Vector2 dash = new Vector2(-dashMovement, dashMovement);
                rb2d.velocity = new Vector2(-dashMovement*40, dashMovement*40);
                //rb2d.MovePosition(rb2d.position + dash);
            }
            else if(Input.GetButton("Down")==true)
            {
                Vector2 dash = new Vector2(-dashMovement, -dashMovement);
                rb2d.MovePosition(rb2d.position + dash);
            }
            else
            {
                Vector2 dash = new Vector2(-dashMovement, 0);
                rb2d.MovePosition(rb2d.position + dash);
            }
        }
        else
        {
            if (Input.GetButton("Up") == true)
            {
                Vector2 dash = new Vector2(0, dashMovement);
                rb2d.MovePosition(rb2d.position + dash);
            }
            else if (Input.GetButton("Down") == true)
            {
                Vector2 dash = new Vector2(0, -dashMovement);
                rb2d.MovePosition(rb2d.position + dash);
            }
        }

        locked = 10;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
           
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=9)
        {
            winText.text = "You win!";
        }
    }
}
