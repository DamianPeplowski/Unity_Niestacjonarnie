using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;

    public int ilosc_kostek = 15;
    int objectCounter = 0;
    public Material[] materials;
    public GameObject block;
    public float range = 10.0f; 

    void Start()
    {

        GeneratePositions();

        StartCoroutine(GenerujObiekt());
    }

    void GeneratePositions()
    {

        Vector3 obecna_pozycja = transform.position;

        for (int i = 0; i < ilosc_kostek; i++)
        {
            float randomX = UnityEngine.Random.Range(-range, range);
            float randomZ = UnityEngine.Random.Range(-range, range);

            Vector3 newPosition = new Vector3(obecna_pozycja.x + randomX, 1.5f, obecna_pozycja.z + randomZ); 
            positions.Add(newPosition);
        }
    }

    IEnumerator GenerujObiekt()
    {

        while (objectCounter < ilosc_kostek)
        {
            Vector3 pos = positions[objectCounter];
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;

            objectCounter++;
            yield return new WaitForSeconds(this.delay);
        }
    }
}
