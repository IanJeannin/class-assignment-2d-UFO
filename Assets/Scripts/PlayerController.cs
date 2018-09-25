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

    private void Start()
    {

        SetCountText();
        count = 0;
        winText.text = "";
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        rb2d.AddForce(movement*speed);
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
