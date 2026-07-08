using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Fica SÓ na cena _Boot. Responsabilidade única: garantir que o GameSession
/// existe e mandar pra tela de Seleção. Fica separado do GameSession de propósito —
/// assim, se algum outro script criar um GameSession de emergência (fallback),
/// isso não dispara um carregamento de cena indesejado.
/// </summary>
public class BootLoader : MonoBehaviour
{
    [Tooltip("Nome exato da cena de Seleção")]
    public string cenaSelecaoInicial = "Selecao";

    void Start()
    {
        if (GameSession.Instance == null)
        {
            GameObject obj = new GameObject("GameSession");
            obj.AddComponent<GameSession>();
        }

        SceneManager.LoadScene(cenaSelecaoInicial);
    }
}