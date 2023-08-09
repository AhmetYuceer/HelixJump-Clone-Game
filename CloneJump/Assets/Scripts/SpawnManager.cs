using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform parentObject;
    [SerializeField] private GameObject Circle;
    [SerializeField] private GameObject spawnPointStart;
    [SerializeField] private GameObject spawnPointEnd;
    [SerializeField] private int spawnCount;
    [SerializeField] private float rangeValue = 10;
    private Vector3 spawnPositon=new Vector3(0,0,0);
    private void Start() 
    {
        SpawnCircle();
    }
    private void SpawnCircle()
    {
        float range = spawnPointStart.transform.position.y - rangeValue;
        spawnPositon.y = range;
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject clone =  Instantiate(Circle,spawnPositon,Quaternion.identity,parentObject);
            spawnPositon.y = clone.transform.position.y - rangeValue;
            clone.GetComponent<Pieces>().PieceRemove();
        }
    }
}
