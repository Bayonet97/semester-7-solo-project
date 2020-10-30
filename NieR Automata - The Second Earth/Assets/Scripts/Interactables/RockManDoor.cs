using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        RockManInteractable.OnOpeningDoor += OpenDoor;
    }

    private void OpenDoor()
    {
        throw new NotImplementedException();
    }
}
