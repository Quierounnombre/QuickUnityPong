using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    static float	position = -12.25f;

    void Start()
    {
		transform.position = new Vector2(position, transform.position.y);
    }

    public void    move_score(int v)
    {
        float 	current_x;
		Vector2	tmpvec;

        current_x = transform.position.x + v;
		tmpvec = new Vector2(current_x, transform.position.y);
		transform.position = tmpvec;
		position = current_x;
    }
}
