using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : Singleton<MusicPlayer>
{
    [SerializeField] List<AudioClip> _musicTracks;
    [SerializeField] bool _randomPlay = false;
    [SerializeField] int _startTrackIndex = 0;

    private AudioClip _currentTrack;

    //cashed
    private AudioSource _musicSource;

    private int _currentTrackIndex;
    public void StopPlayMusic()
    {
        _musicSource.Pause();
    }

    public void StopForConcreteTime(float pauseTimeSecs)
    {
        StartCoroutine(PauseMusicInSecs(pauseTimeSecs));
    }

    private IEnumerator PauseMusicInSecs(float pauseTimeSecs)
    {
        _musicSource.Pause();
        yield return new WaitForSeconds(pauseTimeSecs);
        _musicSource.UnPause();
    }


    private void Start()
    {
        _currentTrackIndex = _startTrackIndex;
        _musicSource = GetComponent<AudioSource>();
        gameObject.transform.position = Camera.main.transform.position;
        SelectFirstTrack();
    }

    private void SelectFirstTrack()
    {
        if (_randomPlay)
        {
            SelectRandomTrack();
        }
        else
        {
            _currentTrack = _musicTracks[_startTrackIndex];
            _musicSource.clip = _currentTrack;
        }
        _musicSource.Play();
    }

    private void SelectRandomTrack()
    {
        if (_musicTracks.Count == 1)
        {
            SelectNextTrack();
            return;
        } 
        int newTrackIndex = UnityEngine.Random.Range(0, _musicTracks.Count);
        if (_musicTracks[newTrackIndex] == _currentTrack)
        {
            SelectRandomTrack();
        }
        else
        {
            _currentTrack = _musicTracks[newTrackIndex];
            _musicSource.clip = _currentTrack;
        }
    }

    private void SelectNextTrack()
    {
        if(_currentTrackIndex == _musicTracks.Count - 1)
        {
            _currentTrackIndex = 0;
        }
        else
        {
            _currentTrackIndex++;
        }
        _currentTrack = _musicTracks[_currentTrackIndex];
        _musicSource.clip = _currentTrack;
    }

    private void Update()
    {
        if (!_musicSource.isPlaying)
        {
            if (_randomPlay)
            {
                SelectRandomTrack();
            }
            else
            {
                SelectNextTrack();
            }
            _musicSource.Play();
        }
    }
}
