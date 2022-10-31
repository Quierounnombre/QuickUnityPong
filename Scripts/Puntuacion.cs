using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    static float	position = -9.05f;
	static float	position_s = 0.001f;
    public bool		issquare;

    void Start()
    {
		if (issquare)
			transform.position = new Vector2(position_s, transform.position.y);
		else
			transform.position = new Vector2(position, transform.position.y);
    }

    public void    move_score(int v)
    {
        float 	current_x;
		Vector2	tmpvec;

    	current_x = transform.position.x + v;
		tmpvec = new Vector2(current_x, transform.position.y);
		transform.position = tmpvec;
		if (issquare)
			position_s = current_x;
		else
			position = current_x;
    }
}
