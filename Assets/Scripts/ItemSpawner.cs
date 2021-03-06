﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject crown;
    public GameObject fist;
    public GameObject claw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem(Item item, Vector3 position)
    {
        Debug.Log("SPAWNING: " + item.ToString());
        GameObject gameObject = crown;
        switch(item){
            case Item.Crown:
                gameObject = crown;
                break;
            case Item.Fist:
            case Item.Claw:
            case Item.Sword:
                gameObject = fist;
                break;
            case Item.Big_Claw:
            case Item.Big_Fist:
            case Item.Big_Sword:
                gameObject = claw;
                break;
        }
        Debug.Log(gameObject != null);
        if (gameObject != null){
            Debug.Log("object? " + gameObject.ToString());
            GameObject obj = Instantiate(gameObject, position, Quaternion.identity);
            obj.GetComponent<Interactable>().giveItem = item;
            // obj.transform.position = new Vector3(obj.transform.position.x, -0.1f, obj.transform.position.z);
            obj.transform.Translate(Random.insideUnitCircle * new Vector3(1, 0, 1));
        }
    }
}
