using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour //bing ai me ayudó a solucionar dudas que tenía en este código así mismo, recibí ayuda en la lógica por parte de mi compañero andré xd
{
    public static ObjectPooling Instance { get; private set; }

    public GameObject spritePrefab;
    public int initialPoolSize;

    private List<GameObject> availableObjects = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateObject();
        }
    }

    void CreateObject()
    {
        GameObject obj = Instantiate(spritePrefab);
        obj.SetActive(false);
        availableObjects.Add(obj);
    }

    public GameObject RequestObject()
    {
        if (availableObjects.Count == 0)
        {
            CreateObject();
        }

        //toma el primer objeto disponible
        GameObject obj = availableObjects[0];
        availableObjects.RemoveAt(0);
        obj.SetActive(true);
        return obj;
    }

    public void DespawnObject(GameObject obj)
    {
        //desactiva el objeto y lo añade a la lista de objetos disponibles
        obj.SetActive(false);
        availableObjects.Add(obj);
    }
}

