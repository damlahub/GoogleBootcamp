using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private Scene _scene;
    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void levels()
    {
        SceneManager.LoadScene(1);
    }
    public void Lv1()
    {
        SceneManager.LoadScene(2);
    }
    public void Lv2()
    {
        SceneManager.LoadScene(3);
    }
    public void Lv3()
    {
        SceneManager.LoadScene(4);
    }
}
