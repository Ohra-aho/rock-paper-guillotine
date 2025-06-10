using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveHub : MonoBehaviour
{
    public List<UnityEvent> save_functions;

    public void SaveAll()
    {
        for(int i = 0; i < save_functions.Count; i++)
        {
            save_functions[i].Invoke();
        }
    }
}
