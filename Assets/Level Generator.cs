using System.ComponentModel;
using NUnit.Framework;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("prefab")]
    public GameObject brickPrefab;
    public float brickSizeX, brickSizeY;
    public float gapSize;
    public Color[] colors;
    [Header("world")]
    public float worldSizeX;
    public float worldSizeY; //max positive coord to be showed on screen
    public float offsetX, offsetY;
    public float offsetBottom;

    private int countX, countY;
    private float startX, startY;

    void Start()
    {
        InitGeneration();
    }

    private void InitGeneration()
    {
        startX = -worldSizeX + offsetX;
        startY = worldSizeY - offsetY;
        countX = (int)((int)(worldSizeX * 2 - offsetX * 2) / (brickSizeX + gapSize)) + 1;
        countY = (int)((int)(worldSizeY * 2 - offsetY) / (brickSizeY + gapSize) - offsetBottom);

        for (int y = 0; y < countY; y++)
        {
            for (int x = 0; x < countX; x++)
            {
                SpawnPrefab(colors[y], -worldSizeX + 0.2f + offsetX + x * (brickSizeX + gapSize), +worldSizeY - offsetY - y * (brickSizeY + gapSize));
            }
        }
    }

    private void SpawnPrefab(Color color, float x, float y)
    {
        Instantiate(brickPrefab, new Vector3(x, y, 0), Quaternion.identity); //.GetComponent<SpriteRenderer>().color = color;
    }

}
