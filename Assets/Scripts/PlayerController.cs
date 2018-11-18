using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    private Vector3 input;
    private Vector3 moveV;
    private Animator animator;
    private Camera cam;
    private Transform playerTransform;
    private CharacterController characterController;
    public GunController gunC;
    public Text points;
    public GameObject panel;
    public Transform relativeTransform;
    // Use this for initialization
    void Start()
    {

        rb = GetComponentInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        cam = FindObjectOfType<Camera>();
        playerTransform = transform.GetChild(0);
        panel.SetActive(false);
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        input = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) input += relativeTransform.forward;
        if (Input.GetKey(KeyCode.S)) input += -relativeTransform.forward;
        if (Input.GetKey(KeyCode.A)) input += -relativeTransform.right;
        if (Input.GetKey(KeyCode.D)) input += relativeTransform.right;
        moveV = input * speed;
        characterController.SimpleMove(moveV * Time.deltaTime);
        animator.SetFloat("For", input.magnitude);
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(camRay, out rayLength))
        {
            Vector3 lookPoint = camRay.GetPoint(rayLength);
            Debug.DrawLine(camRay.origin, lookPoint, Color.red);

            playerTransform.LookAt(new Vector3(lookPoint.x, playerTransform.position.y, lookPoint.z));
            // playerTransform.Rotate(0, 55, 0);
        }

        if (Input.GetButton("Fire1"))
        {
            gunC.isFiring = true;
        }
        else
        {
            gunC.isFiring = false;
        }

        if (GameObject.FindWithTag("Trash") == null)
        {
            panel.SetActive(true);
            StartCoroutine(WaitForIt(3.0F));
        }

        points.text = GameObject.FindGameObjectsWithTag("Trash").Length.ToString() + " left";
    }

    void FixedUpdate()
    {
        //rb.AddForce(moveV);
    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);

    }
}
