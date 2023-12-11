using System.Collections;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogues;

    private bool isShowingDialogue = false;
    private bool skipDialogue = false;
    private int currentDialogueIndex = 0;

    void Start()
    {
        dialogueText.text = "";
        StartCoroutine(ShowDialogueAfterDelay(3f));
    }

    private void Update()
    {
        if (isShowingDialogue)
        {
            // Verificar si se presiona la tecla F para omitir la animaci�n letra por letra
            if (Input.GetKeyDown(KeyCode.F))
            {
                skipDialogue = true;
            }
        }
    }

    private void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            StartCoroutine(ShowDialogue(dialogues[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        else
        {
            currentDialogueIndex = 0;
            isShowingDialogue = false;
            dialogueText.text = "";
        }
    }

    private IEnumerator ShowDialogue(string dialogue)
    {
        isShowingDialogue = true;
        skipDialogue = false;

        // Configurar la velocidad de aparici�n de las letras
        float letterDelay = 0.05f;

        // Mostrar el di�logo letra por letra o mostrar todo si se presiona la tecla F
        if (!skipDialogue)
        {
            foreach (char letter in dialogue.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }
        }
        else
        {
            dialogueText.text = dialogue;
        }

        // Esperar 3 segundos despu�s de mostrar todo el di�logo
        yield return new WaitForSeconds(3f);

        // Limpiar el di�logo y pasar al siguiente
        isShowingDialogue = false;
        dialogueText.text = "";
        ShowNextDialogue();
    }

    private IEnumerator ShowDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowNextDialogue();
    }
}
