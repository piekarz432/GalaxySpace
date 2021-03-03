using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject highScoreScrollView;

    [SerializeField]
    private GameObject highScoreLine;

    private GameObject item;

    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openHighScore()
    {
        gameObject.SetActive(true);
    }

    public void exitHighScore()
    {
        gameObject.SetActive(false);

    }

    public void createHighScore()
    { 
        for (int i = 0; i < HighScore.instance.players.Count; i++)
        {
            item = Instantiate(highScoreLine, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), highScoreScrollView.GetComponent<Transform>());
            item.transform.GetChild(1).GetComponentInChildren<Text>().text = HighScore.instance.players[i].name;
            item.GetComponentInChildren<Text>().text = HighScore.instance.players[i].points.ToString();
        }
    }
}
