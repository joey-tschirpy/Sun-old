using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    private int width, height, depth;

    private int xOffset, yOffset, zOffset;
    private Node[,,] levelData;

    // Start is called before the first frame update
    void Start()
    {
        xOffset = width / 2;
        yOffset = 0;
        zOffset = depth / 2;


        levelData = new Node[width, height, depth];
        GenerateNodes();
    }

    public void GenerateRoomInEditor() {
        xOffset = width / 2;
        yOffset = 0;
        zOffset = depth / 2;


        levelData = new Node[width, height, depth];
        GenerateNodes();
    }

    private void GenerateNodes()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    levelData[x, y, z] = new Node(x - xOffset, y - yOffset, z - zOffset);
                    if (y == 0) levelData[x, y, z].active = true;
                    if (x == 0) levelData[x, y, z].active = true;
                }
            }
        }
    }

    public void GenerateMesh() {
        if (levelData != null) {
            RoomMeshGenerator rmg = new RoomMeshGenerator();
            rmg.GenerateMesh(levelData);
        }
        else {
            Debug.Log("No level data to generate.");
        }
    }
}

public struct Node
{
    public readonly Vector3 pos;
    public readonly Vector3 tfl, tfr, tbl, tbr, bfl, bfr, bbl, bbr;
    public bool active;

    public Node(int x, int y, int z)
    {
        pos = new Vector3(x, y, z);

        tfl = new Vector3(x - 0.5f, y + 0.5f, z - 0.5f);
        tfr = new Vector3(x + 0.5f, y + 0.5f, z - 0.5f);
        tbl = new Vector3(x - 0.5f, y + 0.5f, z + 0.5f);
        tbr = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);

        bfl = new Vector3(x - 0.5f, y - 0.5f, z - 0.5f);
        bfr = new Vector3(x + 0.5f, y - 0.5f, z - 0.5f);
        bbl = new Vector3(x - 0.5f, y - 0.5f, z + 0.5f);
        bbr = new Vector3(x + 0.5f, y - 0.5f, z + 0.5f);

        active = false;
    }

}
