using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D bola;

	public Puntuacion Puntuacion;

	public GameManager GameManager;

    public float	power;

	public float	power_max;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bola = GetComponent<CircleCollider2D>();
        Vector2 Vinit = new Vector2 (power, Random.Range(power * 0.5f, -power * 0.5f));
        rb.velocity = Vinit;
    }

/*
    private void OnCollisionEnter2D(Collision2D other)
    {
		Vector2 Vresult;

		power = rb.velocity.x;
		if (power > power_max && power < -power_max)
		{
			if (power > 0)
				power = power_max;
			else
				power = power_max;
		}
		Vresult = new Vector2 (power, rb.velocity.y);
    	rb.velocity = Vresult;
    }
*/
	private void LateUpdate()
	{
		if (transform.position.x < -9)
		{
			GameManager.Score++;
			Puntuacion.move_score(-2);
			if (GameManager.Score >= 5)
				GameManager.ChangeScene("Exit");
			else;
				GameManager.ChangeScene("");
		}
		else if (transform.position.x > 9)
		{
			GameManager.Score--;
			Puntuacion.move_score(2);
			if (GameManager.Score <= -5)
				GameManager.ChangeScene("Exit");
			else;
				GameManager.ChangeScene("");
		}
	}
}
