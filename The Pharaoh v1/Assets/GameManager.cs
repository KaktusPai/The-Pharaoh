using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int approvalRating;
    public int money;
    public int guyNumber = 1;

    public GameObject guy;
    public GameObject wincanv;

    public Text statement;
    public Text crime;

    public Text timeT;
    public Text arT;
    public Text mT;
    public Text mT2;

    public Slider timeBar;
    public Slider MBar;
    public Slider ARBar;
    public Slider MBar2;

    public bool die;
    public bool live;
    public bool labor;

    public float gameTime;
    public bool resetTimer;

    void Start()
    {
        wincanv.SetActive(false);
        approvalRating = 80;
        money = 50;
    }

    void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timeT.GetComponent<Text>().text = textTime + " Left!";
        arT.text = approvalRating.ToString() + "% Approval rate";
        mT.text = money.ToString() + "$ Money";        
        mT2.text = money.ToString() + "$";

        timeBar.value = time;
        timeBar.maxValue = gameTime;
        ARBar.value = approvalRating;
        ARBar.maxValue = 120;
        MBar.value = money;
        MBar.maxValue = 1000;
        MBar2.value = money;
        MBar2.maxValue = 1000;
        
        if (resetTimer == true)
        {
            time = gameTime;
            resetTimer = false;
        }

        if (approvalRating > 100)
        {
            approvalRating = 100;
        }

        if (time <= 0 || guyNumber > 4 || approvalRating < 0) 
        {
            wincanv.SetActive(true);
            time = 60;
            if (approvalRating < 0)
            {
                money = -9999999;
            }
        }

        if (guyNumber == 1)
        {
            crime.text = "Peter. Suspected of stealing";
            statement.text = "I might have stolen something, yes, but that doesn't make me a bad guy! If you let me go I will never steal from people again. I'll only take something if a door is left open. And I'll even reduce my takings by 50%!";
        }
        if (guyNumber == 2)
        {
            crime.text = "Jonas. Suspected of murder";
            statement.text = "I am just an old man, I know nothing of this murder! I am old and senile, just let me live my final days in peace. I couldn't even handle a knife tha- which I think was used. I am innocent, did I mention I am old!?";
        }
        if (guyNumber == 3)
        {
            crime.text = "Nicu. Suspected of stealing";
            statement.text = "I am a nice guy, I have never made anyone feel bad ever. I don't know why I am here. Stealing!? No someone has definitely framed me for this. People can be jealous of how nice I am.";
        }
        if (guyNumber == 4)
        {
            crime.text = "Borgus. Suspected of attempted assasination";
            statement.text = "I DID NOT TRY CRUSH ANYONE. I NEVER KILL. NEVER. I TRY TO PICK UP MY BIG ROCK, NO KILL INTENTION. MAN JUST SCARED!";
        }
    }

    public void Die()
    {
        if (guyNumber == 1) {money += 100; approvalRating += 10;}
        if (guyNumber == 2) {money += 50; approvalRating += 20;}
        if (guyNumber == 3) {money -= 50; approvalRating -= 20;}
        if (guyNumber == 4) {money -= 100; approvalRating += 20;}
        guyNumber += 1;
    }

    public void Live()
    {
        if (guyNumber == 1) {money -= 100; approvalRating -= 20;}
        if (guyNumber == 2) {money -= 10; approvalRating -= 20;}
        if (guyNumber == 3) { money += 50; approvalRating += 20;}
        if (guyNumber == 4) { money += 100; approvalRating -= 20;}
        guyNumber += 1;
    }

    public void Labor()
    {
        if (guyNumber == 1) { money += 100; approvalRating -= 10;}
        if (guyNumber == 2) { money -= 50; approvalRating += 5;}
        if (guyNumber == 3) { money += 200; approvalRating -= 10;}
        if (guyNumber == 4) { money += 300; approvalRating -= 30;}
        guyNumber += 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}