﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelManagement levelManagement;
    public ItemSpawner itemSpawner;
    public GameObject playerPrefab;
    
    public GameObject[] playerList = new GameObject[4];

    void Start()
    {
        // Handle Level Generation
        levelManagement.generateLevel(Guid.NewGuid().ToString());

        //Spawn Players In

        List<int> playerIndexes = new List<int>();
        Debug.Log(SharedData.player1Joined);
        if (SharedData.player1Joined) playerIndexes.Add(1);
        if (SharedData.player2Joined) playerIndexes.Add(2);
        if (SharedData.player3Joined) playerIndexes.Add(3);
        if (SharedData.player4Joined) playerIndexes.Add(4);

        foreach(int index in playerIndexes) {
            Debug.Log(index);
            GameObject obj = Instantiate(playerPrefab, levelManagement.GetGameObjectSpawnLocation(), Quaternion.identity);
            string name = "Player " + index;
            Debug.Log(obj.transform.position);
            obj.GetComponent<PlayerMovement>().setChildTag(name);
            obj.GetComponent<PlayerInteraction>().tagSetup(index);
            obj.name = name;
            playerList[index - 1] = obj;
        }

        var values = Enum.GetValues(typeof(Item));
        foreach(Item item in values) {
            itemSpawner.SpawnItem(item, levelManagement.GetGameObjectSpawnLocation() + new Vector3(0, 1, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            SharedData.Reset();
            Debug.Log("Loading Menu");
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
