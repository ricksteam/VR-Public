using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Plane"){ PointsManager.addPoints( 1 ); }
    }

}
