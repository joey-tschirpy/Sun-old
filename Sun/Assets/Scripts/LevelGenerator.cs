using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private int width, height, depth;

    private int xOffset, yOffset, zOffset;
    private Node[,,] levelData;

    // Start is called before the first frame update
    //void Start()
    //{
    //    xOffset = width / 2;
    //    yOffset = 0;
    //    zOffset = depth / 2;


    //    levelData = new Node[width, height, depth];
    //    GenerateLevel();
    //    GenerateMesh();
    //}

    private void OnValidate()
    {
        xOffset = width / 2;
        yOffset = 0;
        zOffset = depth / 2;

        Clear();

        levelData = new Node[width, height, depth];
        GenerateLevel();
        GenerateMesh();
    }

    private void GenerateLevel()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    levelData[x, y, z] = new Node(x - xOffset, y - yOffset, z - zOffset);
                }
            }
        }
    }

    private void GenerateMesh()
    {
        List<Vector3> verticies = new List<Vector3>();
        List<int> tris = new List<int>();

        GameObject o = new GameObject();
        o.name = "level mesh";
        MeshFilter mf = o.AddComponent<MeshFilter>();
        MeshRenderer mr = o.AddComponent<MeshRenderer>();
        Mesh mesh = new Mesh();
        mr.material = new Material(Shader.Find("Standard"));

        mf.mesh = mesh;

        int index = 0;

        for (int z = 0; z < levelData.GetLength(2); z++)
        {
            for (int y = 0; y < levelData.GetLength(1); y++)
            {
                for (int x = 0; x < levelData.GetLength(0); x++)
                {
                    Node n = levelData[x, y, z];
                    //front face
                    verticies.Add(n.tfl);
                    tris.Add(index++);

                    verticies.Add(n.tfr);
                    tris.Add(index++);

                    verticies.Add(n.bfl);
                    tris.Add(index++);

                    verticies.Add(n.bfl);
                    tris.Add(index++);

                    verticies.Add(n.tfr);
                    tris.Add(index++);

                    verticies.Add(n.bfr);
                    tris.Add(index++);
                }
            }
        }

        mesh.vertices = verticies.ToArray();
        mesh.triangles = tris.ToArray();
        mesh.RecalculateNormals();

        o.transform.SetParent(this.transform);
    }

    private void Clear()
    {
        int count = 0;
        while (this.transform.childCount > 0 && count < 500)
        {
            Destroy(this.transform.GetChild(0).gameObject);
            count++;
        }
    }

    private void OnDrawGizmos()
    {
        for (int z = 0; z < levelData.GetLength(2); z++)
        {
            for (int y = 0; y < levelData.GetLength(1); y++)
            {
                for (int x = 0; x < levelData.GetLength(0); x++)
                {
                    Gizmos.DrawCube(levelData[x, y, z].pos, Vector3.one * 0.1f);
                }
            }
        }
    }
}

public struct Node
{
    public Vector3 pos;
    public Vector3 tfl, tfr, tbl, tbr, bfl, bfr, bbl, bbr;

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
    }
}
