using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectShip : MonoBehaviour
{
    [SerializeField]
    private Object[] ships;


    private void Start()
    {

    }

    private void Update()
    {
    }

    public void selectShip(int index)
    {
        if(index == 0)
        {
            Instantiate(ships[0]);
        }
    }
}