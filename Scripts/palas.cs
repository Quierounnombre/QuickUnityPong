using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palas : PlayerControls
{
    public GameObject   secondary;
    public bool         is_primary;
    public string       second_dir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<BoxCollider2D>();
		if (is_primary)
			secondary.SetActive(true);
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
    	if (is_primary)
    	{
    		float vertical = Input.GetAxis(Dir);
        	Vector2 movement = new Vector2 (0, vertical * speed);
        	if(vertical != 0)
        	    rb.velocity = movement;
		}
		else
		{
			float vertical2 = Input.GetAxis(second_dir);
			Vector2 movement = new Vector2 (0, -(vertical2 * speed));
			if (vertical2 != 0)
				rb.velocity = movement;
		}
	}
}
