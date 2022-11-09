using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cl;
	public GameObject tooltiptext;
	public GameObject Contrary_Grid;
	public TextMeshProUGUI text;
	public GameManager Gm;
	public int selected_text;
	public Color selected;
	public Color white;
	private SpriteRenderer	rd;
	public bool	ch_selection_side;


    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        cl = GetComponent<BoxCollider2D> ();
		rd = GetComponent<SpriteRenderer> ();
    }

    private void OnMouseOver()
    {
		tooltiptext.SetActive(true);
		Contrary_Grid.SetActive(false);
		assign_text(selected_text);
    }

	private void OnMouseExit()
	{
		tooltiptext.SetActive(false);
		Contrary_Grid.SetActive(true);
	}

	private void OnMouseUp()
	{
		if (ch_selection_side)
			Gm.red_player = selected_text;
		else
			Gm.blue_player = selected_text;
		SpriteRenderer[] o_rd = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
		foreach(var i in o_rd)
		{
			if (i.gameObject.CompareTag("RedSelector") && ch_selection_side)
				i.color = white;
			else if (i.gameObject.CompareTag("BlueSelector") && !ch_selection_side)
				i.color = white;
		}
		rd.color = selected;
	}

	private void assign_text(int selected_text)
	{
		if (selected_text == 1) //Standar
		{
			text.text = "Una pala basica para una persona basica ^^";
		}
		else if (selected_text == 2) //Aguila
		{
			text.text = "Te gusta la velocidad, a mi tambien\n\npros: te mueves en todas direcciones usa AWSD o las \"flechitas\"\n\n cons: eres enano, pero furioso";
		}
		else if (selected_text == 3) //Ilusionista
		{
			text.text = "No tienes amigos y no te importa.\n\nCada 3 toques la bola es INVISIBLE\n\n disfruta farmeando noobs";
		}
		else if (selected_text == 4) //Ameba
		{
			text.text = "Tu numero de neuronas es igual al numero de golpes que te voy a dar en la cabeza\n\n tienes 2 palas una vertical y otra horizontal, ¿sabras manejarlas?";
		}
	}
}
