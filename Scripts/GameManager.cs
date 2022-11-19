using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Puntuacion Puntuacion;

    public AudioClip Musica;

    public static int Score = 0;
    public AudioClip duck;

	private static int stored_red_player = 1;
	private static int stored_blue_player = 1;
    public int red_player;
    public int blue_player;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
		red_player = stored_red_player;
		blue_player = stored_blue_player;
    }

    public void ChangeScene(string sc)
    {
		stored_blue_player = blue_player;
		stored_red_player = red_player;
        if (sc == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.instance.Awake();
        }
        else 
        {
            if (sc != "Exit")
            {
                SceneManager.LoadScene(sc);
	        	new_game();
	        }
            else
            {
                Application.Quit();
            };
        }
    }

    public void resume(){
        Time.timeScale=1;
        TextMeshProUGUI[] texts=Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        Button[] buttons=Resources.FindObjectsOfTypeAll<Button>();
        foreach(var i in texts){
            if(i.gameObject.CompareTag("PauseMenu"))
                i.gameObject.SetActive(false);
        }

        foreach(var j in buttons){
            if(j.gameObject.CompareTag("PauseMenu"))
                j.gameObject.SetActive(false);
        }
    }

    public void pause(){
        Time.timeScale=0;
        TextMeshProUGUI[] texts=Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        Button[] buttons=Resources.FindObjectsOfTypeAll<Button>();
        foreach(var i in texts)
        {
            if(i.gameObject.CompareTag("PauseMenu"))
            {
                i.gameObject.SetActive(true);
            }
        }

        foreach(var j in buttons)
        {
            if(j.gameObject.CompareTag("PauseMenu"))
			{
                j.gameObject.SetActive(true);
			}
        }

    }

    public void lose_game(bool isred)
    {
        Time.timeScale = 0;
        TextMeshProUGUI[] texts = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();
        foreach(var i in texts)
        {
            if (isred)
            {
                if (i.gameObject.CompareTag("GameoverMenu_red"))
                    i.gameObject.SetActive(true);
            }
            else
            {
                if (i.gameObject.CompareTag("GameoverMenu_blue"))
                    i.gameObject.SetActive(true);
            }
        }

        foreach(var j in buttons)
        {
            if (j.gameObject.CompareTag("GameoverMenu"))
                j.gameObject.SetActive(true);
        }
    }

	public void new_game()
	{
        int flag = 2;
		Time.timeScale = 1;
		TextMeshProUGUI[] texts = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        foreach(var i in texts)
        {
            if (i.gameObject.CompareTag("GameoverMenu_red"))
                    i.gameObject.SetActive(false);
			if (i.gameObject.CompareTag("GameoverMenu_blue"))
                    i.gameObject.SetActive(false);
        }
        foreach(var j in buttons)
        {
            if (j.gameObject.CompareTag("GameoverMenu"))
                j.gameObject.SetActive(false);
        }
        if (Score < 0)
        {
            Score = -Score;
            flag = -flag;
        }
        while(Score != 0)
        {
            Puntuacion.move_score(flag);
            Score--;
        }
    }
    private void LateUpdate()
    {
        if (Score >= 5)
            lose_game(false);
        else if (Score <= -5)
			lose_game(true);
    }
}
