using UnityEngine;

public class PetInstance : MonoBehaviour
{
    public EntityData data;
    public int nivelAtual = 1;
    public int ataque;
    public int vida;
    public bool congelado;

    public void Setup(EntityData newData)
    {
        data = newData;
        ataque = data.poderBase;
        vida = data.poderBase;
        // Atualiza UI do prefab aqui
    }
}
