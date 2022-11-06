using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : PlayerControls
{
	public int				number_of_balls;
	public SpriteRenderer   Sp_render;
    private void Start()
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

	private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bola")
        {
			if (number_of_balls < 3)
				number_of_balls++;
			else
			{
				Sp_render.color = new Color (255, 255, 255, 0);
			}
        }
	}
}
