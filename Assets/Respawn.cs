using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{

    public GameObject tank;
    public GameObject countText;
    private float m_countdown;
    private float currentTime;
    bool isDead;

    // Use this for initialization
    void Start()
    {
        countText.SetActive(false);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.activeSelf == false && !isDead)
        {
            RespawnTank();

        }
        if (countText.activeSelf)
        {
            if (Time.time - currentTime > 1)
            {
                currentTime = Time.time;
                m_countdown--;
                countText.GetComponent<Text>().text = m_countdown.ToString();
            }

        }
        else
        {
            m_countdown = 6;
        }
    }

    private void RespawnTank()
    {
        isDead = true;
        tank.transform.position = transform.position;
        tank.transform.rotation = transform.rotation;
        tank.GetComponent<EnemyHealth>().currentHealth = 3;
        if (tank.name == "MC-1")
        {
            currentTime = Time.time;
            countText.SetActive(true);
            countText.GetComponent<Text>().text = m_countdown.ToString();
        }
        Invoke("RespawnDelay", 5f);
    }

    private void RespawnDelay()
    {
        tank.SetActive(true);
        if (tank.name == "MC-1")
        {
            countText.SetActive(false);
        }
        isDead = false;
    }
}
