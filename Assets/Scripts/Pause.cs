using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField]
    GameObject PausePanel;
    [HideInInspector]
    public bool isClicked;

    Ship_Gun ShipGun;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        ShipGun = FindObjectOfType<Ship_Gun>();
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            isClicked = true;
            ShipGun.enabled = false;
        }
    }

    public void ClickReturn()
    {
        if(isClicked)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            isClicked = false;
            ShipGun.enabled =true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
