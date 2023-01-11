using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class openDoor : Door_02
{
    public override void ToggleLock()
    {
        
        base.ToggleLock();
        if(IsLocked){
            CloseDoor();
        }else{
            OpenDoor();
        }
    }

    private void Start(){
        if(!IsLocked)
            OpenDoor();
    }
}