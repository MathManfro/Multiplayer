using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Pega o objeto que estava sendo arrastado e acabou de ser solto
        GameObject droppedItem = eventData.pointerDrag;
        Draggable draggableItem = droppedItem.GetComponent<Draggable>();

        if (draggableItem != null)
        {
            // Verifica se o slot está vazio. 
            // (Futuramente, aqui você adiciona a lógica de fundir pets iguais se já tiver um filho)
            if (transform.childCount == 0)
            {
                // Muda a variável do pet para que, no OnEndDrag, ele assuma este slot como nova casa
                draggableItem.parentAfterDrag = transform;

                // --- INTEGRAÇÃO COM BANCO/LÓGICA ---
                // Aqui você chamaria o ShopManager para verificar se o jogador tem Ouro suficiente.
                // Se tiver, subtrai o ouro e salva a ação refletindo a tabela COMPRAS.
            }
        }
    }
}