using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [Header("Bancos de Dados Locais")]
    public List<EntityData> poolDePets;     // Arraste APENAS os Pets para cá
    public List<EntityData> poolDeComidas;  // Arraste APENAS as Comidas para cá

    [Header("Locais na UI")]
    public Transform[] slotsDePets;         // Arraste os Slots de Pet aqui
    public Transform[] slotsDeComidas;      // Arraste os Slots de Comida aqui

    [Header("Configurações")]
    public GameObject petPrefab;            // O Prefab universal que usamos para os dois

    public void RoletarLoja()
    {
        if (EconomyManager.Instance.PodeGastar(1))
        {
            EconomyManager.Instance.GastarOuro(1);

            // 1. Enche a prateleira de PETS
            foreach (Transform slot in slotsDePets)
            {
                LimparSlot(slot);
                if (poolDePets.Count > 0)
                {
                    EntityData sorteado = poolDePets[Random.Range(0, poolDePets.Count)];
                    InstanciarEntidade(sorteado, slot);
                }
            }

            // 2. Enche a prateleira de COMIDAS
            foreach (Transform slot in slotsDeComidas)
            {
                LimparSlot(slot);
                if (poolDeComidas.Count > 0)
                {
                    EntityData sorteado = poolDeComidas[Random.Range(0, poolDeComidas.Count)];
                    InstanciarEntidade(sorteado, slot);
                }
            }
        }
        else
        {
            Debug.Log("Sem dinheiro para roletar a loja!");
        }
    }

    // Função auxiliar para evitar repetição de código
    private void LimparSlot(Transform slot)
    {
        if (slot.childCount > 0) Destroy(slot.GetChild(0).gameObject);
    }

    // Função auxiliar para instanciar e centralizar
    private void InstanciarEntidade(EntityData dado, Transform slot)
    {
        GameObject novaEntidade = Instantiate(petPrefab, slot);

        RectTransform rt = novaEntidade.GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.localPosition = Vector3.zero;
            rt.localScale = Vector3.one;
        }

        novaEntidade.GetComponent<PetInstance>().Setup(dado);
    }
}