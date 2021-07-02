using System;
using System.Collections.Generic;
using System.Linq;
using EventSystem;
using EventSystem.Events.Sound;
using EventSystem.Events.UI;
using UnityEngine;

namespace Managers
{
    public class SoundManager: MonoBehaviour, IListener
    {
        public AudioSource cameraAudioSource;
        public List<AudioClip> audioSamples;

        public void HandleEvent(object value)
        {
            if (value is PlayInitSound)
            {
                var playInitSoundEvent = (PlayInitSound) value;
                var clips = (from sample in audioSamples where sample.name == playInitSoundEvent.name select sample).ToArray();
                if (clips.Length > 0)
                {
                    cameraAudioSource.volume = playInitSoundEvent.volume;
                    PlaySound(cameraAudioSource, clips[0]);
                }
            }
        }

        private void PlaySound(AudioSource source, AudioClip clip)
        {
            if (clip.LoadAudioData())
            {
                source.clip = clip;
                source.Play();
            }
        }
    }
}