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

        float x = PlayerPrefs.GetFloat("xScore");
        Debug.Log("x = " + x);
        float y = PlayerPrefs.GetFloat("yScore");
        Debug.Log("y = " + y);

        float templateHeight = 25.0f;
        // IF BOTH INSIDE
        if (timesPlayed <= 10 || x <= PlayerPrefs.GetFloat("9HScore") && y <= PlayerPrefs.GetFloat("9HScore"))
        {
            Debug.Log("BOTH TOP10");
            for (int i = 0; i < timesPlayed && i < 10; i++)
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
            // IF BOTH OUTSIDE
            if (PlayerPrefs.GetFloat("9HScore") < x && PlayerPrefs.GetFloat("9HScore") < y)
            {
                if (x <= y)
                {
                    // x in 9th and y in 10th

                    for (int i = 0; i < 10; i++)
                    {
                        Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                        RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                        EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                        EntryTransform.gameObject.SetActive(true);

                        int rank = i + 1;

                        // Regular stuff for the top 8
                        if (rank < 9)
                        {
                            EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();
                            string name = names[i];
                            float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;
                            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                            EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Position").GetComponent<Text>().color = color;

                        }

                        // Showing x and y in 9th and 10th place
                        else
                        {

                            // Get rank
                            string name = "Believe in yourself";
                            EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;

                            if (rank == 9)
                            {
                                float score = x;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("xPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                            else
                            {
                                float score = y;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("yPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                        }
                    }
                }
                // Just the opposite of before
                else
                {
                    Debug.Log("x in 10th and y9");
                    // x in 10th and y9
                    for (int i = 0; i < 10; i++)
                    {
                        Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                        RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                        EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                        EntryTransform.gameObject.SetActive(true);

                        int rank = i + 1;

                        //normal for top 8
                        if (rank < 9)
                        {
                            EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();
                            string name = names[i];
                            float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;
                            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                            EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Position").GetComponent<Text>().color = color;

                        }
                        // y as 9 and x as 10
                        else
                        {

                            // Get rank
                            string name = "Believe in yourself";
                            EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;

                            if (rank == 9)
                            {
                                float score = y;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("xPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                            else
                            {
                                float score = x;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("yPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                        }
                    }
                }
            }
            // if one in and one out
            else if (PlayerPrefs.GetFloat("9HScore") > y && PlayerPrefs.GetFloat("9HScore") < x || PlayerPrefs.GetFloat("9HScore") > x && PlayerPrefs.GetFloat("9HScore") < y)
            {
                Debug.Log("one in one out");

                for (int i = 0; i < 10; i++)
                {
                    Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                    RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                    EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                    EntryTransform.gameObject.SetActive(true);

                    int rank = i + 1;

                    if (rank < 10)
                    {
                        EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();
                        string name = names[i];
                        float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                        EntryTransform.Find("Name").GetComponent<Text>().text = name;
                        EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                        EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                        EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                        EntryTemplate.Find("Position").GetComponent<Text>().color = color;
                        if (score == PlayerPrefs.GetFloat("xScore") || score == PlayerPrefs.GetFloat("yScore"))
                        {
                            EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                        }

                    }

                    else
                    {
                        // Get rank
                        string name = "Believe in yourself giraffe";
                        EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                        EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                        EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                        EntryTransform.Find("Name").GetComponent<Text>().text = name;

                        if (y > x)
                        {
                            float score = x;
                            EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("yPos").ToString();
                            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                        }
                        else
                        {
                            float score = y;
                            EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("yPos").ToString();
                            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                        }
                    }
                }
            }
            // if one is equal to 10 and other outside
            else if (PlayerPrefs.GetFloat("9HScore") == y && y < x || PlayerPrefs.GetFloat("9HScore") == x && x < y)
            {
                if (x > y)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                        RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                        EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                        EntryTransform.gameObject.SetActive(true);

                        int rank = i + 1;

                        //normal for top 8
                        if (rank < 9)
                        {
                            EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();
                            string name = names[i];
                            float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;
                            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                            EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Position").GetComponent<Text>().color = color;

                        }
                        // y as 9 and x as 10
                        else
                        {

                            string name = "Believe in yourself";
                            EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;

                            if (rank == 9)
                            {
                                float score = y;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("xPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                            else
                            {
                                float score = x;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("yPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                        }
                    }
                }
                else if (y > x)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
                        RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
                        EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                        EntryTransform.gameObject.SetActive(true);

                        int rank = i + 1;

                        //normal for top 8
                        if (rank < 9)
                        {
                            EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();
                            string name = names[i];
                            float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;
                            EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                            EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                            EntryTemplate.Find("Position").GetComponent<Text>().color = color;

                        }
                        // x as 9 and y as 10
                        else
                        {

                            string name = "Believe in yourself";
                            EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                            EntryTransform.Find("Name").GetComponent<Text>().text = name;

                            if (rank == 9)
                            {
                                float score = x;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("xPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                            else
                            {
                                float score = y;
                                EntryTransform.Find("Position").GetComponent<Text>().text = PlayerPrefs.GetInt("yPos").ToString();
                                EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");

                            }
                        }
                    }
                }
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
            //    RectTransform EntryRectTransform = EntryTransform.GetComponent<RectTransform>();
            //    EntryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            //    EntryTransform.gameObject.SetActive(true);

                //    int rank = i + 1;

                //    EntryTransform.Find("Position").GetComponent<Text>().text = rank.ToString();

                //    string name = names[i];

                //    EntryTransform.Find("Name").GetComponent<Text>().text = name;

                //    float score = PlayerPrefs.GetFloat(i + "HScore"); //Get PlayerPrefs score here
                //    if (score == PlayerPrefs.GetFloat("xScore") || score == PlayerPrefs.GetFloat("yScore"))
                //    {
                //        EntryTransform.Find("Time").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                //        EntryTransform.Find("Name").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                //        EntryTransform.Find("Position").GetComponent<Text>().color = new Color(255f / 255, 20f / 255, 147f / 255, 1);
                //    }
                //    else
                //    {
                //        EntryTemplate.Find("Time").GetComponent<Text>().color = color;
                //        EntryTemplate.Find("Name").GetComponent<Text>().color = color;
                //        EntryTemplate.Find("Position").GetComponent<Text>().color = color;
                //    }

                //    EntryTransform.Find("Time").GetComponent<Text>().text = score.ToString("n3");
                //}
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
