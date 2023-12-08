using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public bool isFirst = false;

    public int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        Storage[] storages = GameObject.FindObjectsOfType<Storage>();

        if(storages.Length == 1)
        {
            isFirst = true;
        }

        foreach(Storage storage in storages)
        {
            if(!storage.isFirst)
            {
                Destroy(storage);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
