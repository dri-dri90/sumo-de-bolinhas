using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BolinhaController bolinha = other.GetComponent<BolinhaController>();
        if (bolinha == null) return;

        bolinha.ColetarMoeda();
        CoinSpawner.Instance?.NotificarMoedaColetada(this);
        Destroy(gameObject);
    }
}