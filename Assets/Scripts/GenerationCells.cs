using System.Collections.Generic;
using UnityEngine;

public class GenerationCells : MonoBehaviour
{
    [SerializeField] List<GameObject> cells = new List<GameObject>();

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for(int i = -5; i <= 10; i++)
        {
            for(int j = -10; j <= 10; j++)
            {
                GameObject cell = Instantiate(cells[Random.Range(0, 3)]);
                cell.name = $"Cell {i}-{j}";
                cell.transform.position = new Vector3(j, i, 0);
                cell.transform.SetParent(transform, false);
            }
        }
    }
}
