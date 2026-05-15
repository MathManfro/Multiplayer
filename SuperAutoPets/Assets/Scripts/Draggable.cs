using UnityEngine;
using UnityEngine.EventSystems;

// Exige que o GameObject tenha um CanvasGroup para controlarmos o Raycast
[RequireComponent(typeof(CanvasGroup))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 1. Salva o slot original caso o jogador solte o pet num lugar inválido
        parentAfterDrag = transform.parent;

        // 2. Move o pet para a raiz do Canvas para ele não renderizar atrás de outros painéis
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); // Garante que fique por cima de toda a UI

        // 3. Desativa o bloqueio de raycast. Isso permite que o mouse "atravesse" o pet e detecte o slot abaixo dele
        canvasGroup.blocksRaycasts = false;

        // Opcional: Deixa o pet um pouco transparente enquanto arrasta
        canvasGroup.alpha = 0.8f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Faz o pet seguir exatamente a posição do mouse/dedo
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 1. Define o novo pai (se caiu num DropSlot, o parentAfterDrag terá mudado; senão, volta pro original)
        transform.SetParent(parentAfterDrag);

        // 2. Reativa o raycast e a opacidade
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
}