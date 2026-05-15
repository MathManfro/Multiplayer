using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Pega o objeto que estava sendo arrastado e acabou de ser solto
        GameObject droppedItem = eventData.pointerDrag;
        Draggable draggableItem = droppedItem.GetComponent<Draggable>();

        if (pet != null && transform.childCount == 0)
        {
            int custo = (int)pet.data.valor; // Valor vindo do ScriptableObject

            if (EconomyManager.Instance.PodeGastar(custo))
            {
                EconomyManager.Instance.GastarOuro(custo);
                pet.GetComponent<Draggable>().parentAfterDrag = transform;
                // Aqui você desativa a flag de "está na loja" do pet
            }
        }
    }
}