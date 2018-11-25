using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    public Text greenScore;
    public Text redScore;
    public Text blueScore;
    public Text yellowScore;
    public Text timerText;
    public GameObject panel;
    public Material p1Material;
    public Material p2Material;
    public Material p3Material;
    public Material p4Material;
    private int p1Tiles;
    private int p2Tiles;
    private int p3Tiles;
    private int p4Tiles;
    private float totalTiles;
    public float maxTime;
    private float countdownTimer;
    private float lastTimestamp;
    private float[] percents = new float[4];
    private float timerSpeed = 1f;
    private bool gameOver;

    // Use this for initialization
    void Start()
    {

        gameOver = false;
        panel.SetActive(false);
        totalTiles = GameObject.FindGameObjectsWithTag("FloorTile").Length;
        countdownTimer = maxTime;
        timerText.text = ((int)countdownTimer / 60).ToString() + ":" + ((int)countdownTimer % 60).ToString("00");

    }



    // Update is called once per frame
    void Update()
    {
        percents[0] = Mathf.Round(p1Tiles / totalTiles * 100);
        greenScore.text = percents[0].ToString() + "%";

        percents[1] = Mathf.Round(p2Tiles / totalTiles * 100);
        redScore.text = percents[1].ToString() + "%";

        percents[2] = Mathf.Round(p3Tiles / totalTiles * 100);
        blueScore.text = percents[2].ToString() + "%";

        percents[3] = Mathf.Round(p4Tiles / totalTiles * 100);
        yellowScore.text = percents[3].ToString() + "%";


        if (Time.time - lastTimestamp >= timerSpeed && !gameOver)
        {
            lastTimestamp = Time.time;
            countdownTimer--;
            int minutes = (int)countdownTimer / 60;
            int seconds = (int)countdownTimer % 60;
            timerText.text = minutes.ToString() + ":" + seconds.ToString("00");
        }

        if (Time.time >= maxTime + 1 && !gameOver)
        {
            gameOver = true;
            ShowWinner();
            StartCoroutine("EndGame", 10f);
        }
    }

    private void ShowWinner()
    {
        String winner = "";
        float max = 0;
        int winPos = 0;
        for (int i = 0; i < percents.Length; i++)
        {
            if (max < percents[i])
            {
                max = percents[i];
                winPos = i;
            }
        }
        switch (winPos)
        {
            case 0:
                winner = "Green";
                break;
            case 1:
                winner = "Red";
                break;
            case 2:
                winner = "Blue";
                break;
            case 3:
                winner = "Yellow";
                break;
        }
        panel.GetComponent<Text>().text = winner + " wins!";
        panel.SetActive(true);
    }

    public void UpdateCounts(Material oldMaterial, Material newMaterial)
    {
        if (oldMaterial == p1Material)
            p1Tiles--;
        else if (oldMaterial == p2Material)
            p2Tiles--;
        else if (oldMaterial == p3Material)
            p3Tiles--;
        else if (oldMaterial == p4Material)
            p4Tiles--;

        if (newMaterial == p1Material)
            p1Tiles++;
        else if (newMaterial == p2Material)
            p2Tiles++;
        else if (newMaterial == p3Material)
            p3Tiles++;
        else if (newMaterial == p4Material)
            p4Tiles++;

    }



    IEnumerator EndGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(0);

    }
}
