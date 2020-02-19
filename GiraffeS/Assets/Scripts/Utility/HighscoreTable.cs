using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] Transform EntryContainer;
    [SerializeField] Transform EntryTemplate;

    int timesPlayed;

    string[] names = { "The very best giraffe", "Supersonic giraffe", "Rocket giraffe", "Usain Bolt giraffe", "Average giraffe", "Running giraffe", "Jogging giraffe", "Walking giraffe", "Happy giraffe", "Don't give up" };

    private void Awake()
    {

        EntryTemplate.gameObject.SetActive(false);
        Color color = EntryTemplate.Find("Time").GetComponent<Text>().color;

        if (PlayerPrefs.HasKey("timesPlayed"))
        {
            timesPlayed = PlayerPrefs.GetInt("timesPlayed");
        }
        else
        {
            PlayerPrefs.SetInt("timesPlayed", 0);
            timesPlayed = 0;
        }

        float templateHeight = 25.0f;
        if (timesPlayed <= 10)
        {
            for (int i = 0; i < timesPlayed; i++)
            {
                Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                EntryTransform.gameObject.SetActive(true);

                int rank = i + 1;
                //int moduloRank = rank % 10;
                //string rankString;
                //switch (moduloRank)
                //{
                //    default:
                //        rankString = rank + "TH"; break;

                //    case 1: rankString = rank + "ST"; break;
                //    case 2: rankString = rank + "ND"; break;
                //    case 3: rankString = rank + "RD"; break;
                //}
                //EntryTransform.Find("Position").GetComponent<Text>().text = rankString;
                EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();

                string name = names[i];

                EntryTransform.Find("Name").GetComponent<Text>().text = name;

                float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                if (score == PlayerPrefs.GetFloat("xScore") || score == PlayerPrefs.GetFloat("yScore"))
                {
                    EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                    EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                    EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                }
                else
                {
                    EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                    EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                    EntryTemplate.Find("Position").GetComponent<Text>().color = color;
                }

                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
            }
        }

        else if (timesPlayed > 10)
        {
            //float x = PlayerPrefs.GetFloat("xScore");
            //float y = PlayerPrefs.GetFloat("yScore");
            //if (PlayerPrefs.GetFloat("9HScore") < x)
            //{
            //    if (x <= y)
            //    {
            //        // x in 9th and y in 10th

            //        for (int i = 0; i < 10; i++)
            //        {
            //            Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
            //            RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
            //            EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            //            EntryTransform.gameObject.SetActive(true);

            //            int rank = i + 1;

            //            EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();

            //            string name = names[i];

            //            EntryTransform.Find("Name").GetComponent<Text>().text = name;

            //            float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
            //            if (score == PlayerPrefs.GetFloat("xScore") || score == PlayerPrefs.GetFloat("yScore"))
            //            {
            //                EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
            //                EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
            //                EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
            //            }
            //            else
            //            {
            //                EntryTemplate.Find("Time").GetComponent<Text>().color = color;
            //                EntryTemplate.Find("Name").GetComponent<Text>().color = color;
            //                EntryTemplate.Find("Position").GetComponent<Text>().color = color;
            //            }

            //            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
            //        }
            //    }
            //    else
            //    {
            //        // x in 10th
            //    }
            //}
            //else if (PlayerPrefs.GetFloat("9HScore") < y && y < x)
            //{
            //    // y in 9th and x in 10th
            //}

            for (int i = 0; i < 10; i++)
            {
                Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                EntryTransform.gameObject.SetActive(true);

                int rank = i + 1;

                EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();

                string name = names[i];

                EntryTransform.Find("Name").GetComponent<Text>().text = name;

                float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                if (score == PlayerPrefs.GetFloat("xScore") || score == PlayerPrefs.GetFloat("yScore"))
                {
                    EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                    EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                    EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                }
                else
                {
                    EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                    EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                    EntryTemplate.Find("Position").GetComponent<Text>().color = color;
                }

                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
