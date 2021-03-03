using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour
{
    public void Load()
    {
         SceneManager.LoadScene("Level");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowWarning()
    {
        //FindObjectOfType<SelectShip>().ShowWarning();
    }


}
