using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCharacter : MonoBehaviour
{
    [SerializeField]
    GameObject[] Character;

    private int liczba;

    // Start is called before the first frame update
    void Awake()
    {
        liczba=PlayerPrefs.GetInt("Select");
        GetObject();
    }

   private void GetObject()
   {
        if(liczba==1)
        {
            Instantiate(Character[0], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 2)
        {
            Instantiate(Character[1], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 3)
        {
            Instantiate(Character[2], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 4)
        {
            Instantiate(Character[3], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 5)
        {
            Instantiate(Character[4], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 6)
        {
            Instantiate(Character[5], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 7)
        {
            Instantiate(Character[6], new Vector2(0f, -4f), Quaternion.identity);
        }
        if (liczba == 8)
        {
            Instantiate(Character[7], new Vector2(0f, -4f), Quaternion.identity);
        }
    }
}
