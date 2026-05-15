using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetDisplay : MonoBehaviour
{
    public EntityData data; // Arraste o ScriptableObject aqui ou ele virá via código
    public TextMeshProUGUI textoPoder;
    public Image imagemPet;

    public void Setup(EntityData newData)
    {
        data = newData;
        AtualizarUI();
    }

    public void AtualizarUI()
    {
        if (data != null)
        {
            textoPoder.text = data.poderBase.ToString();
            imagemPet.sprite = data.icon;
        }
    }
}