using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_01 : BaseDoor
{
    protected override void OpenDoor()
    {
        base.OpenDoor();

        wings[0]["door_01_wing_left"].speed = -1;
        wings[1]["door_01_wing_right"].speed = -1;
        wings[0].Play();
        wings[1].Play();
    }
    protected override void CloseDoor()
    {
        base.CloseDoor();

        wings[0]["door_01_wing_left"].time = wings[0]["door_01_wing_left"].length;
        wings[1]["door_01_wing_right"].time = wings[1]["door_01_wing_right"].length;
        wings[0]["door_01_wing_left"].speed = 1;
        wings[1]["door_01_wing_right"].speed = 1;
        wings[0].Play();
        wings[1].Play();
    }
}
