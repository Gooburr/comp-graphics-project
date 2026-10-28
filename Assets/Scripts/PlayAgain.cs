using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public Material ColorGrading;
    public void playAgain()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
