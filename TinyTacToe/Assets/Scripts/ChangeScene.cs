using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void CityScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
