using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_activator : MonoBehaviour
{
    public bool             is_red;
    public SpriteRenderer   Sp_render;
	public Sprite[]			Sprite;
	public GameManager	    gm;

    private void Start()
    {
        if (is_red)
            activate(gm.red_player);
        else
            activate(gm.blue_player);
    }
	private void activate(int selected_character)
	{
        if (selected_character == 1)
        {
            this.GetComponent<PlayerControls>().enabled = true;
            this.transform.localScale = new Vector3(0.25f, 2.5f, 1);
			Sp_render.sprite= Sprite[0];
        }
        else if (selected_character == 2)
        {
            this.GetComponent<Aguila>().enabled = true;
            this.transform.localScale = new Vector3(0.75f, 1f, 1);
			Sp_render.sprite = Sprite[1];
        }
        else if (selected_character == 3)
        {
			this.GetComponent<Invisible>().enabled = true;
            this.transform.localScale = new Vector3(0.25f, 2f, 1);
			Sp_render.sprite= Sprite[0];
        }
		/*
        else
        {
            this.GetComponent<>().enabled = true;
        }*/
    }
}
