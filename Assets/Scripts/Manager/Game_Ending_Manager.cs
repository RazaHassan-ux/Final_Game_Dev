using UnityEngine;
using UnityEngine.SceneManagement;

public class game_ending_Manager : MonoBehaviour
{
    public int sceneIndexToLoad = 2;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }

}
