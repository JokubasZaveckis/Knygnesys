using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelPart_Start;
    //[SerializeField] private Transform levelPart_1;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    private Transform TrinamasLevelis;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        

        int startingPawnLevelParts = 5;
        for(int i=0; i<startingPawnLevelParts; i++) //sugeneruoja pradiniu leveliu skaiciu
        {
            SpawnLevelPart();
        }
        
    }

    private void Update()
    {
        if(Vector3.Distance(player.position, lastEndPosition)<PLAYER_DISTANCE_SPAWN_LEVEL_PART) //kai veikejas priarteja prie kintamojo PLAYER_DISTANCE_SPAWN_LEVEL_PART reiksmes atspawnina dar viena random lygi
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    { 
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)]; //parenka random lygi
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition); //randa kokiam aukstyje deti sekanti lygi
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position; //randa paskutinio levelio baigimosi vieta
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    { 
        Transform levelPartTransfrom = Instantiate(levelPart, spawnPosition, Quaternion.identity); //atspawnina nauja lygi
        return levelPartTransfrom; //grazina lygio auksti
    }
}