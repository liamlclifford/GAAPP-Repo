using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneLoader : MonoBehaviour
{
    public ScreenController screenController;


    public void DoStuffButton()
    {
        //screenController.TurnOnSwitch();
        //Debug.Log("boop");
    }

    
    public void Home()
    {
       
        SceneManager.LoadScene(0);
    }

    public void nfcreaderAndWriter()
    {

        SceneManager.LoadScene(1);
    }

    public void gaappreader()
    {

        SceneManager.LoadScene(2);
    }


    public void LoadCharacterSelected()
    {

        SceneManager.LoadScene(3);
    }

    public void Loadshop()
    {

        SceneManager.LoadScene(4);
    }

    public void LoadScene(string thisScene)
    {
        SceneManager.LoadScene(thisScene);

    }
}
