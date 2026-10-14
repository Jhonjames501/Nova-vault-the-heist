using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CodeCollector : MonoBehaviour
{
    public static CodeCollector Instance;

    [Header("Code Settings")]
    private List<int> currentCode = new List<int>();
    private int[] targetCode = { 7, 3, 9, 4 }; // Código objetivo de ejemplo
    [SerializeField] private int requiredDigitsLength = 4;

    [Header("UI Reference")]
    [SerializeField] private Text codeDisplayText; // UI CODE: 7 3 _ _
    [SerializeField] private GameObject victoryPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateCodeUI();
        if(victoryPanel != null) victoryPanel.SetActive(false);
    }

    public void AddDigit(int digit)
    {
        if (currentCode.Count < requiredDigitsLength)
        {
            // Validar si es el dígito correcto en su posición correspondiente (opcional o secuencial)
            currentCode.Add(digit);
            UpdateCodeUI();

            // Animación de escala en el texto con LeanTween
            if(codeDisplayText != null)
            {
                LeanTween.scale(codeDisplayText.gameObject, Vector3.one * 1.2f, 0.1f)
                    .setLoopPingPong(1);
            }

            // Comprobar si completó el código
            if (currentCode.Count == requiredDigitsLength)
            {
                TriggerVaultOpen();
            }
        }
    }

    void UpdateCodeUI()
    {
        if (codeDisplayText == null) return;

        string displayStr = "CODE: ";
        for (int i = 0; i < requiredDigitsLength; i++)
        {
            if (i < currentCode.Count)
            {
                displayStr += currentCode[i] + " ";
            }
            else
            {
                displayStr += "_ ";
            }
        }
        codeDisplayText.text = displayStr.TrimEnd();
    }

    void TriggerVaultOpen()
    {
        Debug.Log("¡Código Completo! Abriendo Bóveda...");
        // Notificar a la puerta de la bóveda
        if (VaultDoor.Instance != null)
        {
            VaultDoor.Instance.OpenVault();
        }
    }
}
