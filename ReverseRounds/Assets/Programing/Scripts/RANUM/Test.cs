using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource 컴포넌트를 할당할 변수

    void Start()
    {
        // (선택 사항) 만약 PlayOnAwake를 사용하지 않는 경우, 코루틴 등으로 지연하여 재생할 수 있습니다.
        //StartCoroutine(PlayDelayed(3f)); 
    }

    // (선택 사항)
    //IEnumerator PlayDelayed(float delayTime)
    //{
    //    yield return new WaitForSeconds(delayTime);
    //    audioSource.Play();
    //}

    void Update()
    {
        // 사용자가 특정 키를 누르면 오디오 재생
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            Debug.Log("발사");
        }
    }
}