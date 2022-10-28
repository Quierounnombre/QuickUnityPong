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

    public Puntuacion[] Puntuacion;

    public AudioClip Musica;
    public static int Score = 0;

    public AudioClip duck;

    void Awake()
    {
    
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public void ChangeScene(string sc)
    {
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
            }
            else
            {
                Application.Quit();
            };
        }
    }
    public void resume(){
        Time.timeScale=1;
        Text[] texts=Resources.FindObjectsOfTypeAll<Text>();
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
        Text[] texts=Resources.FindObjectsOfTypeAll<Text>();
        Button[] buttons=Resources.FindObjectsOfTypeAll<Button>();
        foreach(var i in texts)
        {
            if(i.gameObject.CompareTag("PauseMenu"))
                i.gameObject.SetActive(true);
        }

        foreach(var j in buttons)
        {
            if(j.gameObject.CompareTag("PauseMenu"))
                j.gameObject.SetActive(true);
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
        adjust_score();
    }

    private void adjust_score()
    {
        var objectCount = Puntuacion.Length;
        int i = 0;
        int movement;

        movement = 2;
        if (Score < 0)
        {
            movement = -movement;
            Score = -Score;
        }
        while (Score != 0)
        {
            while (objectCount != i)
            {
                Puntuacion[i].move_score[movement];
                i++;
            }
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
