using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Bot1Spawner : NetworkBehaviour
{

    public GameObject Bot;

    float timer = 0f;
    float waitingTime = 120f;

    public float initialDelay;

    private void Start()
    {
        timer = -initialDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitingTime){
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        int BotType = Random.Range(1, 6);

        GameObject _bot1 = Instantiate(Bot, transform.position, Quaternion.identity);
        _bot1.GetComponent<BotController>().BotType.Value = BotType;
        _bot1.GetComponent<NetworkObject>().Spawn();
    }
}