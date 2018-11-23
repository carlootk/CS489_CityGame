using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAnimation : MonoBehaviour
{

    private Rigidbody rb;
    public Material tankMaterial;
    public GameObject[] LeftWheels;
    //all right wheels
    public GameObject[] RightWheels;
    public ScoreBoard sb;

    public GameObject LeftTrack;

    public GameObject RightTrack;
    public float wheelsSpeed = 2f;
    public float tracksSpeed = 2f;
    public AudioSource m_MovementAudio;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.
    public AudioClip m_EngineIdling;            // Audio to play when the tank isn't moving.
    public AudioClip m_EngineDriving;           // Audio to play when the tank is moving.
    private float m_OriginalPitch;              // The pitch of the audio source at the start of the scene.
    public float m_PitchRange = 0.2f;           // The amount by which the pitch of the engine noises can v

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_OriginalPitch = m_MovementAudio.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb.IsSleeping())
        {
            WheelMotion();
        }

        EngineAudio();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("FloorTile"))
        {
            Renderer rend = other.GetComponent<Renderer>();
            sb.UpdateCounts(rend.sharedMaterial, tankMaterial);
            rend.material = tankMaterial;
        }
    }

    private void WheelMotion()
    {
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
    }

    private void EngineAudio()
    {
        // If there is no input (the tank is stationary)...
        if (rb.IsSleeping())
        {
            // ... and if the audio source is currently playing the driving clip...
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                // ... change the clip to idling and play it.
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            // Otherwise if the tank is moving and if the idling clip is currently playing...
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                // ... change the clip to driving and play.
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }
}
