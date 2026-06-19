# Service Locator
유니티 프로젝트에서 전역 서비스(매니저, 시스템 등)를 관리하기 위한서비스 로케이터입니다. ConcurrentDictionary를 사용하여 스레드에대한 안전을 고려했습니다.


<br>
<br>
<br>

## 🔧Usage

#### 등록, 해제
<T> 타입을 키로 등록하고 중복되는 경우 무시합니다. <br>
```cs
Services.Register<IAudioService>(new AudioService());
Services.Unregister<IAudioService>();
```

<br>
<br>


#### 조회
```cs
var audio = Services.Get<IAudioService>();
if (audio != null) {
    audio.PlayMusic("BGM_Main");
}
```

<br>
<br>

#### 교체
```cs
Services.Replace<IAudioService>(new NewAudioService());
```

