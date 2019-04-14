using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PauseUI;
    private bool pause = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {

            pause = !pause;
        }

        if (pause) {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!pause) {

            PauseUI.SetActive(false);
            Time.timeScale = 1;


        }
    }


    public void Resume() {
        pause = false;
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
