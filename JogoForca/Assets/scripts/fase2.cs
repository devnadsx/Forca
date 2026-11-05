using UnityEngine;
using UnityEngine.InputSystem; // Importa o novo sistema de input


public class fase2 : MonoBehaviour
{
    string palavraSecreta = "COMPUTADOR";
    char[] palavraOculta;
    int vidas = 6;
    bool jogoAcabou = false;
    

    void Start()
    {
        // cria os espaço
        palavraOculta = new char[palavraSecreta.Length];
        for (int i = 0; i < palavraOculta.Length; i++)
        {
            palavraOculta[i] = '_';
        }

        Debug.Log(" Agora vamos para a 2 fase. Clique na tela do jogo e digite uma letra no teclado.");
        Debug.Log("Palavra: " + string.Join(" ", palavraOculta));


        if (Keyboard.current != null)
        {
            Keyboard.current.onTextInput += AoDigitarLetra;
        }
    }

    void AoDigitarLetra(char caractereDigitado)
    {

        if (jogoAcabou) return;


        char letra = char.ToUpper(caractereDigitado);


        if (letra >= 'A' && letra <= 'Z')
        {
            bool acertou = false;


            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (palavraSecreta[i] == letra)
                {
                    palavraOculta[i] = letra;
                    acertou = true;
                }
            }


            if (acertou)
            {
                Debug.Log($"Boa! A letra '{letra}' está certa.");
            }
            else
            {
                vidas--;
                Debug.Log($"Ih, não tem '{letra}'. Você ainda tem {vidas} chances.");
            }
            if(vidas <= 3)
            {
                Debug.Log($"Dica: É algo que usamos no nosso dia a dia, especialmente nós alunos do Senac.");
            }

            string palavraAtual = new string(palavraOculta);
            Debug.Log("Palavra: " + string.Join(" ", palavraOculta));


            if (palavraAtual == palavraSecreta)
            {
                Debug.Log(" Mandou bem! Você acertou tudo!");
                jogoAcabou = true;
            }
            else if (vidas <= 0)
            {
                Debug.Log($"Acabaram as chances! A palavra era {palavraSecreta}.");
                jogoAcabou = true;
            }
        }
    }


    void OnDestroy()
    {
        if (Keyboard.current != null)
        {
            Keyboard.current.onTextInput -= AoDigitarLetra;
        }
    }
}
