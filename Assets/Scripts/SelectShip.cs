using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectShip : MonoBehaviour
{
    [SerializeField]
    private Object[] ships;

    private Shop shop;

    private void Awake()
    {
        shop = FindObjectOfType<Shop>();
        selectShip();
        
    }
    private void Start()
    {

       
    }

    private void Update()
    {
    }

    private void selectShip()
    {
        if (shop.selectedShip == 0)
        {
            Instantiate(ships[0]);
        } else if (shop.selectedShip == 1)
        {
            Instantiate(ships[1]);
        }
        else if (shop.selectedShip == 2)
        {
            Instantiate(ships[2]);
        }
        else if (shop.selectedShip == 3)
        {
            Instantiate(ships[3]);
        }
        else if (shop.selectedShip == 4)
        {
            Instantiate(ships[4]);
        }
        else if (shop.selectedShip == 5)
        {
            Instantiate(ships[5]);
        }
        else if (shop.selectedShip == 6)
        {
            Instantiate(ships[6]);
        }
        else if (shop.selectedShip == 7)
        {
            Instantiate(ships[7]);
        }
    }
}