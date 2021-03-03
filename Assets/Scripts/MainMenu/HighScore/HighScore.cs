using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{

    #region SIngleton:HighScore
    public static HighScore instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

   
    [SerializeField]
    public List<Player> players;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
