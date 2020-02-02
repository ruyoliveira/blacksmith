using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public GameObject[] playerPrefab;

    private int maxPlayers = 2;
    private bool[] instatiatedPlayers;

    // Start is called before the first frame update
    void Start()
    {
        instatiatedPlayers = new bool[maxPlayers];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxPlayers; i++)
        {
            if (Input.GetButtonDown("Fire" + i) && !instatiatedPlayers[i])
            {
                GameObject player = Instantiate(playerPrefab[i], transform.position, transform.rotation, transform);
                player.GetComponent<DebugMove>().input = i;
                player.transform.Find("PlayerActionCollider").GetComponent<Player>().id = i;
                instatiatedPlayers[i] = true;
            }
        }
    }
}
