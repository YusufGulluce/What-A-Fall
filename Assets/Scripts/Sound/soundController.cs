using System;
using UnityEngine;

public class soundController : MonoBehaviour, IDataPersistance
{
    private soundButtonController sbController;
    public bool OnOff = true;
    public PlayList[] playLists;

    private void Awake()
    {
        sbController = GameObject.FindGameObjectWithTag("Sound Button").GetComponent<soundButtonController>();
        foreach (PlayList pl in playLists)
        {
            foreach (Sound s in pl.sounds) 
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.pitch = s.pitch;
                s.source.volume = s.volume;
            }
        }
    }

    public void Play( string name )
    {
        if (OnOff)
        {
            PlayList pl = Array.Find(playLists, playlist => playlist.name == name);
            int randomIndex = UnityEngine.Random.Range(0, pl.sounds.Length);
            pl.sounds[randomIndex].source.Play();
        }
    }

    public void changeOnOff(bool OnOff)
    {
        this.OnOff = OnOff;
    }

    public bool getOnOff()
    {
        return this.OnOff;
    }

    public void LoadData(GameData data)
    {
        this.OnOff = data.OnOff;
        sbController.setFirstOnOff(data.OnOff);
    }

    public void SaveData(ref GameData data)
    {
        data.OnOff = this.OnOff;
    }
}
