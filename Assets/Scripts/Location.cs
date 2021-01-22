using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;
    [TextArea]
    public string description;
    public Connection[] connections;
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach(Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";
        }
        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower())
                return connection;
        }
        return null;
    }

    internal bool HasItem(Item item)
    {
       foreach (Item it in items)
        {
            if (it == item && it.itemEnabled)
                return true;
        }
        return false;
    }

    public string GetItemsText()
    {
        if (items.Count == 0) return "";
        string result = "You see ";
        bool first = true;
        foreach(Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first) result += " and ";
                result += item.description;
                first = false;
            }
        }
        result += "\n";
        return result;
    }
}
