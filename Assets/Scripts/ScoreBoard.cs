using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public Text points;
    public GameObject panel;

    // Use this for initialization
    void Start () {

        panel.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindWithTag("Trash") == null)
        {
            panel.SetActive(true);
            StartCoroutine(WaitForIt(3.0F));
        }

        points.text = GameObject.FindGameObjectsWithTag("Trash").Length.ToString() + " left";

    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);

    }
}
