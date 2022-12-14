using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float speed_increase;
    public string Dir;
    public Collider2D character;

    public GameManager GameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            GameManager.instance.pause();
        }
        if (Input.GetButton("j") && Time.timeScale != 0)
            GameManager.ChangeScene("");
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis(Dir);
        Vector2 movement = new Vector2 (0, vertical * speed);
        if(vertical != 0)
        {
            rb.velocity = movement;
        }
    }
}
