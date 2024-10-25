using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{
    public GameObject blockPrefab;  
    public int iloscKostek = 10;    
    public float delay = 1.0f;      
    private List<Vector3> positions = new List<Vector3>(); 
    public float minX = -10f; 
    public float maxX = 10f;  
    public float minZ = -10f; 
    public float maxZ = 10f;  
    public float yHeight = 1.5f; 

    void Start()
    {
        GenerateRandomPositions();

        StartCoroutine(GenerujObiekty());
    }


    void GenerateRandomPositions()
    {
        for (int i = 0; i < iloscKostek; i++)
        {
            float randomX = Random.Range(minX, maxX);  
            float randomZ = Random.Range(minZ, maxZ);  
            positions.Add(new Vector3(randomX, yHeight, randomZ));  
        }
    }

    IEnumerator GenerujObiekty()
    {
        foreach (Vector3 position in positions)
        {
            GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity); 
            yield return new WaitForSeconds(delay); 
        }
    }
}
