using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class inputReciver : MonoBehaviour
{
    Vector3 lastPostion;
    void Start()
    {
        
    }
    public void GetPositon(InputAction.CallbackContext context)
    {
        var position=context.ReadValue<Vector3>();
        if (Vector3.Distance(lastPostion, position) > 1)
        {
            //
            lastPostion=position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
