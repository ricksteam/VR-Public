using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private static GameObject player;

    //Create Player before any Start methods are called
    void Awake()
    {
        player = Instantiate(playerPrefab);
    }

    public static GameObject getPlayer(){ return player; }
    
    public static void movePlayer(GameObject warp)
    {
        player.transform.position = warp.transform.position;
    }

}
