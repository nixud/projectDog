using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerSettings
{
    public static int PlayerNumber = 2;
    public static int PlayerNumberMax = 4;
    public static List<SControlPad> controlPads =
        new List<SControlPad>
        {
            new SControlPad
            (
                KeyCode.W,
                KeyCode.S,
                KeyCode.A,
                KeyCode.D,
                KeyCode.Space
            ),
            new SControlPad
            (
                KeyCode.UpArrow,
                KeyCode.DownArrow,
                KeyCode.LeftArrow,
                KeyCode.RightArrow,
                KeyCode.Return
            )
        };
}
public struct SControlPad
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode attack;

    public SControlPad(KeyCode Up,KeyCode Down,KeyCode Left,KeyCode Right,KeyCode Attack)
    {
        up = Up;
        down = Down;
        left = Left;
        right = Right;
        attack = Attack;
    }
}
