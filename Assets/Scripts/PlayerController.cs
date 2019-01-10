using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    private int count;

    public Text countText;
    public Text winText;

    private bool jumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        jumping = false;
    }

    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float jump = 0.0f;
        if (!jumping && Input.GetKey(KeyCode.Space))
        {
            jumping = true;
            jump = 50.0f;
        }

        Vector3 movement;
        if (jumping)
        {
            movement = new Vector3(0.0f, jump, 0.0f);
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }
    
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Ground")
        {
            jumping = false;
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
