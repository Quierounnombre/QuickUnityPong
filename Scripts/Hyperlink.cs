using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
	public string	link;
	public void	open_url()
	{
		Application.OpenURL(link);
	}
}
