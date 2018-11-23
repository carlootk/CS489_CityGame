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

    // Use this for initialization
    void Start()
    {

        panel.SetActive(false);
        totalTiles = GameObject.FindGameObjectsWithTag("FloorTile").Length;

    }

    // Update is called once per frame
    void Update()
    {
        greenScore.text = Mathf.Round(p1Tiles / totalTiles * 100).ToString() + "%";
        redScore.text = Mathf.Round(p2Tiles / totalTiles * 100).ToString() + "%";
        blueScore.text = Mathf.Round(p3Tiles / totalTiles * 100).ToString() + "%";
        yellowScore.text = Mathf.Round(p4Tiles / totalTiles * 100).ToString() + "%";
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

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);

    }
}
