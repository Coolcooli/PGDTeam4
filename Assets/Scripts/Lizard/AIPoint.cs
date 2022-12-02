using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPoint : MonoBehaviour
{
    enum Approachdir {
        north,east,south,west
    }
    [SerializeField] private Transform north = null;
    [SerializeField] private Transform east = null;
    [SerializeField] private Transform south = null;
    [SerializeField] private Transform west = null;
    private Dictionary<Approachdir, Transform> nextPoints = new Dictionary<Approachdir, Transform>();

    bool active = false;
    LizardPathFinding lizard;


    void Start(){
        nextPoints.Add(Approachdir.north, south);
        nextPoints.Add(Approachdir.east, west);
        nextPoints.Add(Approachdir.south, north);
        nextPoints.Add(Approachdir.west, east);
    }

    void OnTriggerEnter(Collider other){
        switch (other.tag){
            case "Player":
                if(!active) return;
                active = false;
                lizard.moveNext(nextPoints[calculateDirection(other.transform)]);
                break;
            
            case "Lizard":
                active = true;
                lizard = other.GetComponent<LizardPathFinding>();
                break;
        }
    }


    /// <summary>
    /// function that calculates where the player is coming from
    /// </summary>
    /// <param name="player">the transform of the player</param>
    /// <returns>direction of the player</returns>
    Approachdir calculateDirection(Transform player){
        Approachdir direction;

        Vector3 distance = transform.position - player.position;

        //checking which side of the vector is longest
        if(Math.Abs(distance.x) > Math.Abs(distance.z)){
            direction = distance.x < 0 ? Approachdir.east : Approachdir.west;
        }else{
            direction = distance.z < 0 ? Approachdir.north : Approachdir.south;

        }
        Debug.Log(direction);
        return direction;
    }
}
