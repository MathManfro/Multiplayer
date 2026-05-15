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
                if (slot.childCount > 0) Destroy(slot.GetChild(0).gameObject);

                EntityData sorteado = todosOsPets[Random.Range(0, todosOsPets.Count)];

                // Instancia o pet como filho do slot
                GameObject novoPet = Instantiate(petPrefab, slot);

                // --- O PULO DO GATO ESTÁ AQUI ---
                RectTransform rt = novoPet.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.localPosition = Vector3.zero; // Zera a posição relativa ao slot
                    rt.localScale = Vector3.one;     // Garante que o tamanho seja 100%

                    // Opcional: Garante que ele preencha o slot se os anchors estiverem corretos
                    rt.anchoredPosition = Vector2.zero;
                }

                novoPet.GetComponent<PetDisplay>().Setup(sorteado);
            }
        }
    }
}