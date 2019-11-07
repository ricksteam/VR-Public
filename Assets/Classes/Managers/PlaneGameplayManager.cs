using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGameplayManager : GameplayManager
{
    public GameObject planePrefab;
    public GameObject stand;
    public float secondsTilDespawn = 3;
    private List<GameObject> planes = new List<GameObject>();
    private List<GameObject> hoops = new List<GameObject>();

    void Start(){
        base.Start();
        PointsManager.addPointTrigger( "==", winConditionPoints, "onWinConditionPointsReached" );
        PointsManager.addPointTrigger( "==", 1, "onFirstPointReached" );
        spawnPlane();
    }

/*
    public spawnHoop(){
        
    }*/

    public void onFirstPointReached(){
        print( "Congrats on your 1st point!!!" );
    }

    public override void onWinConditionPointsReached(){
        print("You beat the Plane Game!");
        for(int i = 0; i < 100; i++)
            spawnPlane();
    }

    //Called by Grabber when some Plane in list is grabbed
    public void onPlaneGrabbed( GameObject plane )
    {
        spawnPlane();
    }
    public void onPlaneReleased( GameObject plane )
    {
        StartCoroutine( despawnCountdown( plane ) );
    }

    //Removes a Plane from the list and destroys it
    public void killPlane( GameObject plane )
    {
        planes.Remove( plane );
        GameObject.Destroy( plane );
    }

    //Kills the passed plane and creates a new one
    public void respawnPlane( GameObject plane )
    {
        killPlane( plane );
        spawnPlane();
    }

    //Kills all planes in scene
    public override void reset()
    {
        foreach (GameObject plane in planes)
        {
            killPlane( plane );
        }
    }

    //Creates a new Plane GameObject and adds it to the list
    private void spawnPlane()
    {
        GameObject temp = GameObject.Instantiate(planePrefab);
        temp.transform.position = stand.transform.position + new Vector3(0, stand.transform.localScale.y, 0);
        planes.Add(temp);
    }

    //Coroutine for counting down and despawning plane after certain amount of time
    private IEnumerator despawnCountdown( GameObject plane )
    {
        float endTime = Time.realtimeSinceStartup + secondsTilDespawn;
        while ( Time.realtimeSinceStartup < endTime )
        {
            yield return new WaitForSeconds( .5f );
        }
        killPlane( plane );
    }

}
