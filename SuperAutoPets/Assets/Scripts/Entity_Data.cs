using UnityEngine;

[CreateAssetMenu(fileName = "NovoPetComida", menuName = "SAP/Entidade")]
public class EntityData : ScriptableObject
{
    public int cod; // ID do Banco
    public string nome;
    public int poderBase; // Ataque/Vida inicial
    public float valor; // Custo de compra
    public Sprite icon;
    public bool isFood; // Diferencia Pet de Comida
}