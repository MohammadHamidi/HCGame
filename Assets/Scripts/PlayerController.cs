using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("SLideSpeed")]
    [Header("Settings")]
    [Space(2)]
    [Header("Forward_Speed")]
    [SerializeField] private float Forwardspeed = 0;
    [FormerlySerializedAs("speed")]
    [Header("Slide_Speed")]
    [SerializeField] private float SLideSpeed = 0;
    [SerializeField] private GameObject cam2;
    [SerializeField] private GameObject cam1;
    Vector3 clickedScreenPosition =Vector3.zero;
    Vector3 clickedPlayerPosition =Vector3.zero;
    [SerializeField] CrowdSystem crowdSystem;
    float roadWidht = 6;
    public static PlayerController instance { get; set; }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    private void OnTouch(InputValue value)
    {
        var rawInput = value.isPressed;

        Debug.Log($"Raw Touch Value is : {rawInput}");

    }
    private void OnTouchPosition(InputValue value)
    {
        var rawInput = value.Get<Vector2>();
        var clickedScreenPostion = rawInput;
        var clickedPlayerPostion = transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsGameState())
        {
            
            return;
        }

        Running();
        ManageControl();
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
             clickedScreenPosition = Input.mousePosition;
             clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            float xScreenDifrence=Input.mousePosition.x-clickedScreenPosition.x;
            xScreenDifrence /= Screen.width;
            xScreenDifrence *= SLideSpeed;

            
            var postion= clickedPlayerPosition + Vector3.right*xScreenDifrence;
            //postion.x = Mathf.Clamp(postion.x, - roadWidht / 2 + crowdSystem.GetRadius(),  roadWidht / 2 - crowdSystem.GetRadius());
            transform.position = new Vector3 (postion.x,postion.y,transform.position.z);
        } 
    }

    private void Running()
    {
        var distance = ( ChunkManager.instance.GetFinishLine().position.z-transform.position.z);
        //Debug.Log($" Distance to Finish Line ({distance})");
        //Debug.Log($" Distance to Finish Line  Abs ({Mathf.Abs(distance)}) Abs");
        if (Mathf.Abs(distance) <= 1)
        {
            //transform.LookAt(cam2.transform.position);
            GameEventManager.OnStopRunning();
            cam2.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
            return; 
        }
        

        transform.position += Vector3.forward * Forwardspeed* Time.deltaTime;
    }


    private void MoveForward()
    {
        transform.position += Time.deltaTime * Forwardspeed * Vector3.forward;
    }
}
