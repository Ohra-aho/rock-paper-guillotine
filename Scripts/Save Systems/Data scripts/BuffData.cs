using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuffData
{
    public string id;
    public int timer;
    public bool used;

    public BuffData(Buff buff)
    {
        timer = buff.timer;
        used = buff.used;
        id = buff.id;
    }
}
