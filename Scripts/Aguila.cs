using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguila : PlayerControls
{
    private float	start_pos;
    public string   H_Dir;
    void Start()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		start_pos = transform.position.x;
		rb = GetComponent<Rigidbody2D>();
        character = GetComponent<BoxCollider2D>();
		if (start_pos < 0)
			start_pos = -start_pos;
    }

	private bool check_pos()
	{
		float	current_pos;
		int		limiter;

		limiter = 5;
		current_pos = transform. position.x;
		if (current_pos < 0)
			current_pos = -current_pos;
		if (start_pos - limiter >= current_pos)
			return (false);
		if (start_pos + limiter <= current_pos)
			return (false);
		return (true);
	}

	private void breaks()
	{
		float	over_pos;
		int		correction;
		float	y_pos;

		correction = 1;
		over_pos = transform.position.x;
		y_pos = transform.position.y;
		rb.velocity = new Vector2 (0, 0);
		if (over_pos > 0)
			transform.position = new Vector2 (over_pos + correction, y_pos);
		else
			transform.position = new Vector2 (over_pos - correction, y_pos);
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
        if (check_pos())
		{
        	float horizontal = Input.GetAxis(H_Dir);
			float vertical = Input.GetAxis(Dir);
        	Vector2 movement = new Vector2 (horizontal * speed, vertical * speed);
       	 	if(horizontal != 0 || vertical != 0)
      		{
      			rb.velocity = movement;
		  	}
		}
		else
		{
			rb.velocity = new Vector2 (0, 0);
			breaks();
		}
    }
}
