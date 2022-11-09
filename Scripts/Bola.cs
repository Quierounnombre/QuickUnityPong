using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D bola;
	public GameObject trail;

	public Puntuacion Puntuacion;

	public AudioSource[] bounce_sound;
    public SpriteRenderer   Sp_render;

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


    private void OnCollisionEnter2D(Collision2D other)
	{
		int	rand;

		rand = Random.Range(0, 6);
		bounce_sound[rand].Play();
		restore_color();
	}

	private void LateUpdate()
	{
		if (transform.position.x < -9.5f)
		{
			GameManager.Score++;
			Puntuacion.move_score(-2);
			GameManager.ChangeScene("");
		}
		else if (transform.position.x > 9.5f)
		{
			GameManager.Score--;
			Puntuacion.move_score(2);
			GameManager.ChangeScene("");
		}
	}

	private void restore_color()
	{
		Sp_render.color = new Color (1, 1, 1, 1);
		trail.SetActive(true);
	}
}
