using UnityEngine;
using System.Collections.Generic;

public class Shop_Manager : MonoBehaviour
{
    public List<EntityData> poolDePets; // Arraste os ScriptableObjects aqui
    public Transform[] shopSlots;
    public GameObject petPrefab;

    public void Roletar()
    {
        // Lógica de Ouro (ex: -1 ouro)
        foreach (Transform slot in shopSlots)
        {
            if (slot.childCount > 0) Destroy(slot.GetChild(0).gameObject);

            EntityData randomPet = poolDePets[Random.Range(0, poolDePets.Count)];
            GameObject newPet = Instantiate(petPrefab, slot);
            newPet.GetComponent<Pet_Instance>().Setup(randomPet);
        }
    }
}