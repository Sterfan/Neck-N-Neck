using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] Transform EntryContainer;
    [SerializeField] Transform EntryTemplate;

    string[] names = { "The very best giraffe", "Supersonic giraffe", "Rocket giraffe", "Usain Bolt giraffe", "Average giraffe", "Running giraffe", "Jogging giraffe", "Walking giraffe", "Happy giraffe", "Don't give up" };

    private void Awake()
    {
        EntryTemplate.gameObject.SetActive(false);

        float templateHeight = 25.0f;
        for (int i = 0; i < 10; i++)
        {
            Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
            RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
            EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            EntryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }
            EntryTransform.Find("Position").GetComponent<Text>().text = rankString;

            string name = names[i];

            EntryTransform.Find("Name").GetComponent<Text>().text = name;

            //int score = Random.Range(0, 10000); //Get PlayerPrefs score here
            float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here

            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("F3");
        }
    }

}
