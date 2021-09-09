using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{

    public Item[] allItems;
    public static ItemsDatabase Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
