using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {


    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }

    public void About()
    {

        SceneManager.LoadScene("Sobre");

    }
}

