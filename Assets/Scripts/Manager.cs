using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	private int tiempoTranscurrido = 0;
    private int tiempoInicio = 0;

    private bool pause = false;

    public Text tiempo;


    // Use this for initialization
    void Start () {
        tiempoInicio = (int)Time.time;
        pause = false;
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePause();
        UpdateTime();
    }

    void UpdatePause()
    {
        if (Input.GetKey(KeyCode.P))
        {
            pause = !pause;

            System.Threading.Thread.Sleep(250);
        }

        if (pause)
        {
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Q))
            {
                Application.Quit();
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void UpdateTime()
    {
        tiempoTranscurrido = (int) (Time.time - tiempoInicio);
        int segundos = tiempoTranscurrido % 60;
        int minutos = tiempoTranscurrido / 60;
        string seg = segundos.ToString();
        string min = minutos.ToString();

        if (segundos< 10)
        {
            seg = "0" + seg;
        }
        if (minutos< 10)
        {
            min = "0" + min;
        }

        tiempo.text = "Time: " + min + ":" + seg;
    }
}
