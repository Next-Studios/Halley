using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {
    public float Fading = 1f;
    public AudioMixerSnapshot UnMuteAll;
    public AudioMixerSnapshot MuteAll;
    public AudioMixerSnapshot MuteSFX;
    public AudioMixerSnapshot MuteAudioEffects;
    public GameObject MuteSFXbtn, MuteEffectbtn, UnMuteSFXbtn, UnMuteEffectbtn;


    void Start() {
         if (PlayerPrefs.GetString("MuteSFX") == "Mute" && PlayerPrefs.GetString("MuteAudioEffects") == "Mute")
         {
            MuteSFXbtn.SetActive(false);
            UnMuteSFXbtn.SetActive(true);
            MuteEffectbtn.SetActive(false);
            UnMuteEffectbtn.SetActive(true);
        }
         if (PlayerPrefs.GetString("MuteSFX") == "UnMute" && PlayerPrefs.GetString("MuteAudioEffects") == "UnMute")
         {
            MuteSFXbtn.SetActive(true);
            UnMuteSFXbtn.SetActive(false);
            MuteEffectbtn.SetActive(true);
            UnMuteEffectbtn.SetActive(false);

        }
         if (PlayerPrefs.GetString("MuteSFX") == "Mute")
         {
            MuteSFXbtn.SetActive(false);
            UnMuteSFXbtn.SetActive(true);

        }
         if (PlayerPrefs.GetString("MuteAudioEffects") == "Mute")
         {
            MuteEffectbtn.SetActive(false);
            UnMuteEffectbtn.SetActive(true);

        }
         
     }
     

        void Update()
        {
            
                 if (PlayerPrefs.GetString("MuteSFX") == "Mute" && PlayerPrefs.GetString("MuteAudioEffects") == "Mute")
                 {
                     MuteAll.TransitionTo(Fading);
                 }
                 if (PlayerPrefs.GetString("MuteSFX") == "UnMute" && PlayerPrefs.GetString("MuteAudioEffects") == "UnMute")
                 {
                     UnMuteAll.TransitionTo(Fading);
                 }
                 if (PlayerPrefs.GetString("MuteSFX") == "Mute"&& PlayerPrefs.GetString("MuteAudioEffects") == "UnMute")
                 {
                     MuteSFX.TransitionTo(Fading);
                 }
                 if (PlayerPrefs.GetString("MuteAudioEffects") == "Mute"&& PlayerPrefs.GetString("MuteSFX") == "UnMute")
                 {
                     MuteAudioEffects.TransitionTo(Fading);
                 }
                
        }

        public void MuteSFXAction()
        {
            PlayerPrefs.SetString("MuteSFX", "Mute");
        }
        public void UnMuteSFXAction()
        {
            PlayerPrefs.SetString("MuteSFX", "UnMute");
        }
        public void MuteAudioEffectsAction()
        {
            PlayerPrefs.SetString("MuteAudioEffects", "Mute");
        }
        public void UnMuteAudioEffectsAction()
        {
            PlayerPrefs.SetString("MuteAudioEffects", "UnMute");
        }
    }
