using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Button _button;
    [SerializeField] string level;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(UpdateScene);
    }

    // Update is called once per frame
    void UpdateScene()
    {
        SceneManager.LoadScene(level);
        AudioManager.Instance.PlaySoundEffectMusic(AudioManager.Instance.click);
    }
    
}