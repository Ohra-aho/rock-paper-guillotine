using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuffData
{
    public string id;
    public bool used;

    public BuffData(Buff buff)
    {
        used = buff.used;
        id = buff.id;
    }
}
