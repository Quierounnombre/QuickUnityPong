using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character_activator : MonoBehaviour
{
    private void Start()
    {
        
    }
	public void activate(int selected_character)
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
