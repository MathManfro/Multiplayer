using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public List<EntityData> todosOsPets; // Arraste os 3 ScriptableObjects aqui no Inspetor
    public Transform[] slotsDaLoja;
    public GameObject petPrefab;

    public void RoletarLoja()
    {
        if (EconomyManager.Instance.PodeGastar(1))
        {
            EconomyManager.Instance.GastarOuro(1);

            foreach (Transform slot in slotsDaLoja)
            {
                // Limpa o slot atual
                if (slot.childCount > 0) Destroy(slot.GetChild(0).gameObject);

                // Sorteia um pet da lista local
                EntityData sorteado = todosOsPets[Random.Range(0, todosOsPets.Count)];

                // Instancia e configura
                GameObject novoPet = Instantiate(petPrefab, slot);
                novoPet.GetComponent<PetDisplay>().Setup(sorteado);
            }
        }
    }
}