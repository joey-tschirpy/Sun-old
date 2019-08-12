using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMeshGenerator
{
    private Node[,,] levelData;
    private GameObject o;
    private List<Vector3> verticies;
    private List<int> tris;
    private int index;
    private int bitMask;

    public void GenerateMesh(Node[,,] levelData) {

        this.levelData = levelData;
        verticies = new List<Vector3>();
        tris = new List<int>();

        o = new GameObject();
        o.name = "Room Mesh";
        MeshFilter mf = o.AddComponent<MeshFilter>();
        MeshRenderer mr = o.AddComponent<MeshRenderer>();
        Mesh mesh = new Mesh();
        mr.material = new Material(Shader.Find("Standard"));

        mf.mesh = mesh;

        index = 0;

        for (int z = 0; z < levelData.GetLength(2); z++) {
            for (int y = 0; y < levelData.GetLength(1); y++) {
                for (int x = 0; x < levelData.GetLength(0); x++) {
                    if(levelData[x,y,z].active) {
                        bitMask = GenerateBitMask(x, y, z);
                        DrawFaces(bitMask, levelData[x, y, z]);
                    }
                }
            }
        }

        mesh.vertices = verticies.ToArray();
        mesh.triangles = tris.ToArray();
        mesh.RecalculateNormals();

        o.transform.SetParent(GameObject.Find("RoomGenerator").transform);
    }

    private int GenerateBitMask(int x, int y, int z) {
        int mask = 0;
        if (z > 0) {
            if (levelData[x, y, z - 1].active) {
                mask += 32;
            }
        }
        if (z < levelData.GetLength(2) - 1) {
            if (levelData[x, y, z + 1].active) {
                mask += 16;
            }
        }
        if (x > 0) {
            if (levelData[x - 1, y, z].active) {
                mask += 8;
            }
        }
        if (x < levelData.GetLength(0) - 1) {
            if (levelData[x + 1, y, z].active) {
                mask += 4;
            }
        }
        if (y > 0) {
            if (levelData[x, y - 1, z].active) {
                mask += 2;
            }
        }
        if (y < levelData.GetLength(1) - 1) {
            if (levelData[x, y + 1, z].active) {
                mask += 1;
            }
        }
        return mask;
    }

    private void DrawFaces(int bitMask, Node n) {
        if ((bitMask & 32) != 32) {
            DrawFrontFace(n);
        }
        if((bitMask & 16) != 16) {
            DrawBackFace(n);
        }
        if((bitMask & 8) != 8) {
            DrawLeftFace(n);
        }
        if((bitMask & 4) != 4) {
            DrawRightFace(n);
        }
        if((bitMask & 2) != 2) {
            DrawBottomFace(n);
        }
        if((bitMask & 1) != 1) {
            DrawTopFace(n);
        }
    }



    private void DrawFrontFace(Node n) {
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

    private void DrawBackFace(Node n) {
        verticies.Add(n.bbr);
        tris.Add(index++);
        verticies.Add(n.tbr);
        tris.Add(index++);
        verticies.Add(n.tbl);
        tris.Add(index++);

        verticies.Add(n.bbr);
        tris.Add(index++);
        verticies.Add(n.tbl);
        tris.Add(index++);
        verticies.Add(n.bbl);
        tris.Add(index++);
    }

    private void DrawRightFace(Node n) {
        verticies.Add(n.bfr);
        tris.Add(index++);
        verticies.Add(n.tfr);
        tris.Add(index++);
        verticies.Add(n.tbr);
        tris.Add(index++);

        verticies.Add(n.bfr);
        tris.Add(index++);
        verticies.Add(n.tbr);
        tris.Add(index++);
        verticies.Add(n.bbr);
        tris.Add(index++);
    }

    private void DrawLeftFace(Node n) {
        verticies.Add(n.bbl);
        tris.Add(index++);
        verticies.Add(n.tbl);
        tris.Add(index++);
        verticies.Add(n.tfl);
        tris.Add(index++);

        verticies.Add(n.bbl);
        tris.Add(index++);
        verticies.Add(n.tfl);
        tris.Add(index++);
        verticies.Add(n.bfl);
        tris.Add(index++);
    }

    private void DrawBottomFace(Node n) {
        verticies.Add(n.bbl);
        tris.Add(index++);
        verticies.Add(n.bfl);
        tris.Add(index++);
        verticies.Add(n.bfr);
        tris.Add(index++);

        verticies.Add(n.bbl);
        tris.Add(index++);
        verticies.Add(n.bfr);
        tris.Add(index++);
        verticies.Add(n.bbr);
        tris.Add(index++);
    }

    private void DrawTopFace(Node n) {
        verticies.Add(n.tfl);
        tris.Add(index++);
        verticies.Add(n.tbl);
        tris.Add(index++);
        verticies.Add(n.tfr);
        tris.Add(index++);

        verticies.Add(n.tfr);
        tris.Add(index++);
        verticies.Add(n.tbl);
        tris.Add(index++);
        verticies.Add(n.tbr);
        tris.Add(index++);
    }
}
