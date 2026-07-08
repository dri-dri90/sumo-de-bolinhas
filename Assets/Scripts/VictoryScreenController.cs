using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Cena de Vitória. Lê o resultado guardado no GameSession (persistente) e mostra
/// qual jogador venceu e qual bolinha ele estava usando. Tem um botão pra voltar
/// à tela de Seleção.
/// </summary>
public class VictoryScreenController : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textoVencedor;
    public TMP_Text textoBolinhaUsada;
    public Image previewCorVencedor;
    public Button botaoVoltar;

    [Header("Cena de destino ao voltar")]
    public string nomeCenaSelecao = "Selecao";

    void Start()
    {
        MostrarResultado();

        if (botaoVoltar != null)
        {
            botaoVoltar.onClick.AddListener(VoltarParaSelecao);
        }
    }

    private void MostrarResultado()
    {
        if (GameSession.Instance == null || GameSession.Instance.VencedorDaPartida == null)
        {
            if (textoVencedor != null) textoVencedor.text = "Sem resultado (teste direto da cena?)";
            return;
        }

        PlayerIndex vencedor = GameSession.Instance.VencedorDaPartida.Value;
        BolinhaData bolinhaVencedora = vencedor == PlayerIndex.Player1
            ? GameSession.Instance.BolinhaP1
            : GameSession.Instance.BolinhaP2;

        string nomeJogador = vencedor == PlayerIndex.Player1 ? "Jogador 1" : "Jogador 2";

        if (textoVencedor != null) textoVencedor.text = $"{nomeJogador} venceu a partida!";
        if (textoBolinhaUsada != null) textoBolinhaUsada.text = $"Bolinha: {bolinhaVencedora.nomeBolinha}";
        if (previewCorVencedor != null)
        {
            previewCorVencedor.color = vencedor == PlayerIndex.Player1
                ? bolinhaVencedora.corJogador1
                : bolinhaVencedora.corJogador2;
        }
    }

    private void VoltarParaSelecao()
    {
        GameSession.Instance.VoltarParaSelecao(nomeCenaSelecao);
    }
}