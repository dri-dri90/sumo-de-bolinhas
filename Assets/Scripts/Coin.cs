using UnityEngine;

/// <summary>
/// Moeda coletável em 3D. Precisa de um Collider marcado como "Is Trigger"
/// (ex: SphereCollider ou BoxCollider) e um Rigidbody com "Is Kinematic" marcado
/// (só pra o OnTriggerEnter funcionar sem precisar de física real na moeda).
/// Ao ser tocada por uma bolinha, aplica o efeito e se destrói.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BolinhaController bolinha = other.GetComponent<BolinhaController>();
        if (bolinha == null) return;

        bolinha.ColetarMoeda();
        CoinSpawner.Instance?.NotificarMoedaColetada(this);
        Destroy(gameObject);
    }
}