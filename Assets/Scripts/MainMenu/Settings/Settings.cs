using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject settings;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private AudioMixer fxMixer;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider fxSlider;

    [SerializeField]
    private Slider gameSlider;

    [SerializeField]
    private ToggleGroup musicToogleGroup;

    public Toggle[] musicToogle;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(setVolume);
        fxSlider.onValueChanged.AddListener(setVolumeFx);
        gameSlider.onValueChanged.AddListener(setVolumeGame);
        musicToogle = musicToogleGroup.GetComponentsInChildren<Toggle>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSettings()
    {
        settings.SetActive(true);
    }

    public void exitSettings()
    {
        settings.SetActive(false);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setVolumeFx(float volume)
    {
        fxMixer.SetFloat("fxVolume", volume);
    }

    public void setVolumeGame(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        fxMixer.SetFloat("fxVolume", volume);
    }

    public void musicValueChanged()
    {
        if (musicToogle[0].isOn)
        {
            musicToogle[0].gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(0f, 160f, 255f, 255f);
            musicToogle[1].gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(148f, 136f, 118f, 255f);
            musicSlider.interactable = false;
            fxSlider.interactable = false;
            gameSlider.interactable = false;
            audioMixer.SetFloat("volume", -50);
            fxMixer.SetFloat("fxVolume", -50);
        }
        else
        {
            musicToogle[1].gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(0f, 160f, 255f, 255f);
            musicToogle[0].gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(148f, 136f, 118f, 255f);
            musicSlider.interactable = true;
            fxSlider.interactable = true;
            gameSlider.interactable = true;
            audioMixer.SetFloat("volume", 0);
            fxMixer.SetFloat("fxVolume", 0);
        }
    }


}
