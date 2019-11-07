using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private int difficulty = 1;
    //public GameObject spawnWarp;
    private static GameplayManager manager;
    public int winConditionPoints = 5;

    //secretly abstract, but can't make it abstract for a few reasons
    public virtual void reset(){
        print("GameplayManager: OVERRIDE THE reset METHOD!!!!!!!!");
    }

    //we only need this 
    public virtual void onWinConditionPointsReached()
    {
        print("GameplayManager: OVERRIDE THE onWinConditionPointsReached METHOD!!!!!!!!");
    }

    public void setDifficulty(int newDif){ difficulty = newDif; }
    public int getDifficulty() { return difficulty; }

    void Awake(){
        manager = this;
    }
    protected void Start() {
        PlayerManager.movePlayer(GameObject.FindGameObjectWithTag("SpawnPoint"));
        reset();
    }
    //Should be overridden
    public static GameplayManager getManager(){ return manager; }
}
