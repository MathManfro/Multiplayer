using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public List<EntityData> poolDePets; // Arraste os ScriptableObjects aqui
    public Transform[] shopSlots;
    public GameObject petPrefab;

    public void Roletar()
    {
        // Lógica de Ouro (ex: -1 ouro)
        foreach (Transform slot in shopSlots)
        {
            if (EconomyManager.Instance.PodeGastar(EconomyManager.Instance.custoRoll))
            {
                EconomyManager.Instance.GastarOuro(EconomyManager.Instance.custoRoll);

                if (slot.childCount > 0) Destroy(slot.GetChild(0).gameObject);

                EntityData randomPet = poolDePets[Random.Range(0, poolDePets.Count)];
                GameObject newPet = Instantiate(petPrefab, slot);
                newPet.GetComponent<PetInstance>().Setup(randomPet);
            }
            else
            {
                Debug.Log("Sem ouro para roletar!");
            }
        }
    }



}