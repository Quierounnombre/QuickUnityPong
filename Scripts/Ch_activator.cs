using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_activator : MonoBehaviour
{
    public bool         is_red;
	public GameManager	gm;

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
        }
        else if (selected_character == 2)
        {
            this.GetComponent<Aguila>().enabled = true;
        }
        /*
        else if (selected_character == 3)
        {
            this.GetComponent<>().enabled = true;
        }
        else
        {
            this.GetComponent<>().enabled = true;
        }*/
    }
}
