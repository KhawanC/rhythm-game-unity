using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu1;
    [SerializeField] GameObject menu2;

    public void ativarMenu2()
    {
        menu1.SetActive(false);
        menu2.SetActive(true);
    }

    public void ativarMenu1()
    {
        menu1.SetActive(true);
        menu2.SetActive(false);
    }


    public void iniciarFase1()
    {
        SceneManager.LoadScene(1);
    }

    public void encerrarJogo()
    {
        Application.Quit();
    }
}
