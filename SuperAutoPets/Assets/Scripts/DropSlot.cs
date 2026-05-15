using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public bool isTeamSlot; // Marque como TRUE nos slots da equipe e FALSE nos da loja

    public void OnDrop(PointerEventData eventData)
    {
        GameObject objetoArrastado = eventData.pointerDrag;
        Draggable draggable = objetoArrastado.GetComponent<Draggable>();
        PetDisplay display = objetoArrastado.GetComponent<PetDisplay>();

        if (draggable != null && display != null)
        {
            // Se estou soltando na equipe e o pet veio da loja (pai antigo era slot de loja)
            bool veioDaLoja = !draggable.parentAfterDrag.GetComponent<DropSlot>().isTeamSlot;

            if (isTeamSlot && veioDaLoja)
            {
                int custo = (int)display.data.valor;

                if (EconomyManager.Instance.PodeGastar(custo))
                {
                    EconomyManager.Instance.GastarOuro(custo);
                    draggable.parentAfterDrag = transform;
                }
                else
                {
                    Debug.Log("Dinheiro insuficiente!");
                }
            }
            else
            {
                // Movimentação livre dentro da própria equipe ou entre slots da loja
                draggable.parentAfterDrag = transform;
            }
        }
    }
}