using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Laser
{
    [SerializeField]
    private bool r = true, g = true, b = true;

    [SerializeField, Min(0)]
    private int power = 1;

    public bool R => r;
    public bool G => g;
    public bool B => b;
    public int Power => power;

    public Laser(bool red, bool green, bool blue, int power)
    {
        r = red;
        g = green;
        b = blue;
        this.power = power;
    }

    public Laser(Laser laser)
    {
        r = laser.r;
        g = laser.g;
        b = laser.b;
        power = laser.power;
    }

    public Color Color
    {
        get { return new Color(r ? 1 : 0, g ? 1 : 0, b ? 1 : 0); }
    }

    public static Laser Add(Laser laserOne, Laser laserTwo, bool addingPower = true)
    {
        bool r = laserOne.r || laserTwo.r;
        bool g = laserOne.g || laserTwo.g;
        bool b = laserOne.b || laserTwo.b;

        // Add powers or take highest
        int power = addingPower ? laserOne.power + laserTwo.power : Mathf.Max(laserOne.power, laserTwo.power);

        return new Laser(r, g, b, power);
    }
}