using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
   // public int score;
    public int levelint;
    public TMPro.TMP_Text uitLevel;
    public TMPro.TMP_Text AWinnerIsYou;
    public GameObject[] levels;
    public GameObject level;
    public int score = 0;
    public Player player;
    // public TMPro.TMP_Text uitScore;
    // Start is called before the first frame update
    void Start()
    {
        levelint = 0;
        UpdateGUI();
        StartLevel();
    }

    // Update is called once per frame
    void Update(){
  
        
    }
    public void UpdateGUI()
    { uitLevel.text = "Level: " + (levelint + 1) + " of  8";
        //uitScore.text = "Score: " + score;
    }
    void StartLevel()
    {
        if (level != null)
        {
            Destroy(level);
        }

        level = Instantiate<GameObject>(levels[levelint]);

        UpdateGUI();
    }
    public void NextLevel()
    {
        levelint++;
        if (levelint >= 8)
        {
            Victory();
        }
        StartLevel();
    }
    public void Victory(){
        uitLevel.text = "";
        AWinnerIsYou.text = "CONGRADULATIONS! A WINNER IS YOU!";
    }
}
