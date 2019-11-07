﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for calling functions related to points.
//Useful for games where points are used for scoring instead of time.
public class PointsManager : MonoBehaviour
{
    private static int points;
    private static List<PointTrigger> pointTriggers = new List<PointTrigger>();
    private static GameObject scoreboard;

    void Start(){
        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");
        resetPoints();
    }

    public static int getPoints() { return points; }
    public static void resetPoints() {
        points = 0;
        checkPoints();
        updateScoreboard();
    }
    public static void addPoints(int p ) {
        points += p;
        checkPoints();
        updateScoreboard();
    }
    public static void subPoints(int p) {
        points -= p;
        checkPoints();
        updateScoreboard();
    }
    public static void multPoints(int p) {
        points *= p;
        checkPoints();
        updateScoreboard();
    }
    public static void divPoints(int p) {
        points /= p;
        checkPoints();
        updateScoreboard();
    }
    
    public static void addPointTrigger( string equality, int points, string function ){
        pointTriggers.Add( new PointTrigger( equality, points, function ) );
    }
    //See if any PointTriggers have their requirements met; if so, call their functions.
    private static void checkPoints(){
        foreach ( PointTrigger pt in pointTriggers ){
            if(pt.testEquality())
                pt.execute();
        }
    }

    private static void updateScoreboard(){
        scoreboard.GetComponentInChildren<TextMesh>().text = points + " pts";
    }
}
