using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public GameObject warningPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showWarning()
    {
        warningPanel.SetActive(true);
    }

    public void exitWarning()
    {
        warningPanel.SetActive(false);
    }
}
