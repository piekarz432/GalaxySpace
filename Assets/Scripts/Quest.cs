using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Quest : MonoBehaviour
{
    [SerializeField]
    GameObject QuestPanel;

    [SerializeField]
    GameObject Content;

    [SerializeField]
    GameObject QuestLine;

    [SerializeField]
    int QuestCounter;

    [SerializeField]
    float Space;

    [SerializeField]
    GameObject Parent;

    private List<GameObject> QuestList = new List<GameObject>();

    private int CounterDestroyedAsteroids;

    private void Start()
    {
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, QuestCounter * 186);
        QuestPanel.SetActive(false);
        CreateQuest();
        QuestUpdate();

    }

    public void ShowQuest()
    {
        QuestPanel.SetActive(true);
        
    }

    public void HideQuest()
    {
        QuestPanel.SetActive(false);
        Content.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
    }

    void CreateQuest()
    {
        for(int i=1; i<=QuestCounter; i++)
        {
            GameObject Quest=Instantiate(QuestLine, Vector3.zero, Quaternion.identity)as GameObject;
            Quest.transform.SetParent(Parent.transform);
            Quest.transform.localScale = new Vector3(1f, 1f, 1f);
            QuestList.Add(Quest);
        }
    }

    void QuestUpdate()
    {

        for (int i = 0; i < QuestList.Count; i++)
        {
            var MaxQuest = ((i * 20 / 2) + 5);
            if (i<=2)
            {
                QuestList[i].GetComponent<QuestLine>().QuestType = QuestType.CounterDestroyedAsteroids;
                QuestList[i].GetComponent<QuestLine>().NameQuest.text = "Destroy " + "<color=#ce6730>"+  MaxQuest + "</color>" + " asteroids.";
                QuestList[i].GetComponent<QuestLine>().QuestReward.text = (i*100+50).ToString();


                if (QuestList[i].GetComponent<QuestLine>().Counter == MaxQuest)
                {
                    QuestList[i].GetComponent<QuestLine>().buttonReward.interactable = true;
                    QuestList[i].GetComponent<QuestLine>().buttonReward.GetComponent<Image>().color = new Color32(53, 26, 25, 255);

                }
                

                
            }
            if (i > 2 && i<=5)
            {
                QuestList[i].GetComponent<QuestLine>().QuestType = QuestType.CounterDestroyedEnemis;
                QuestList[i].GetComponent<QuestLine>().NameQuest.text = "Destroy " + "<color=#ce6730>"+  (MaxQuest-20) + "</color>" + " enemis.";
                QuestList[i].GetComponent<QuestLine>().QuestReward.text = (i * 100 + 150).ToString();

                if (QuestList[i].GetComponent<QuestLine>().Counter == MaxQuest-20)
                {
                    QuestList[i].GetComponent<QuestLine>().buttonReward.interactable = true;
                    QuestList[i].GetComponent<QuestLine>().buttonReward.GetComponent<Image>().color = new Color32(53, 26, 25, 255);

                }
            }

            if (i > 5 && i <= 8)
            {
                QuestList[i].GetComponent<QuestLine>().QuestType = QuestType.CounterMoney;
                QuestList[i].GetComponent<QuestLine>().NameQuest.text = "Collect " + "<color=#ce6730>" + MaxQuest + "</color>" + " money.";

                QuestList[i].GetComponent<QuestLine>().QuestReward.text = (i * 100 + 250).ToString();

                if (QuestList[i].GetComponent<QuestLine>().Counter == MaxQuest)
                {
                    QuestList[i].GetComponent<QuestLine>().buttonReward.interactable = true;
                    QuestList[i].GetComponent<QuestLine>().buttonReward.GetComponent<Image>().color = new Color32(53, 26, 25, 255);

                }
            }

            if (i > 8 && i <= QuestList.Count)
            {
                QuestList[i].GetComponent<QuestLine>().QuestType = QuestType.CounterDestroyedBoss;
                QuestList[i].GetComponent<QuestLine>().NameQuest.text = "Destroy " + "<color=#ce6730>"+  MaxQuest + "</color>" + " boss.";

                QuestList[i].GetComponent<QuestLine>().QuestReward.text = (i * 100 + 300).ToString();

                if (QuestList[i].GetComponent<QuestLine>().Counter == MaxQuest)
                {
                    QuestList[i].GetComponent<QuestLine>().buttonReward.interactable = true;
                    QuestList[i].GetComponent<QuestLine>().buttonReward.GetComponent<Image>().color = new Color32(53, 26, 25, 255);

                }
            }
            QuestList[i].GetComponentInChildren<Text>().text = "<color=#ce6730>"+ 0 +"</color>" +  "/" + MaxQuest;
        }
    }
    
}
