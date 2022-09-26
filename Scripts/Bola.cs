using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D bola;

	public GameManager GameManager;
	public int inclinarange;
    public int power;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bola = GetComponent<CircleCollider2D>();
        Vector2 Vinit = new Vector2 (power, 0);
        rb.velocity = Vinit;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
		float	inclina;
		Vector2 Vresult;

		if (other.gameObject.name == "J1" || other.gameObject.name == "J2")
		{
			power = -power;
			inclina = Random.Range(-inclinarange, inclinarange);
		}
		else if (rb.velocity.y > 0)
			inclina = Random.Range(-inclinarange, 0);
		else
			inclina = Random.Range(0, inclinarange);
		if (inclina == 0)
			inclina = Random.Range(-1, 1);
		Vresult = new Vector2 (power, inclina);
        rb.velocity = Vresult;
    }

	private void LateUpdate()
	{
		if (transform.position.x < -9)
		{
			GameManager.Score++;
			Debug.Log(GameManager.Score);
			GameManager.ChangeScene("");
		}
		else if (transform.position.x > 9)
		{
			GameManager.Score--;
			Debug.Log(GameManager.Score);
			GameManager.ChangeScene("");
		}
	}
}
