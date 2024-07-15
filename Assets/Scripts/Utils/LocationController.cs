using System;
using System.Collections;
using UniRx;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils
{
    public class LocationController : MonoBehaviour
    {
        public event Action<bool> LocationAllowed;
        
        public void Check()
        {
            GetCountryInfo()
                .Subscribe(country =>
                    {
                        LocationAllowed?.Invoke(country.Equals("UA", StringComparison.OrdinalIgnoreCase));
                    }, 
                    error =>
                    {
                        Debug.LogError("Error: " + error);
                        LocationAllowed?.Invoke(false);
                    });
        }

        private IObservable<string> GetCountryInfo()
        {
            return Observable.FromCoroutine<string>(observer => FetchCountryInfo(observer));
        }

        private IEnumerator FetchCountryInfo(IObserver<string> observer)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("https://api.country.is"))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    try
                    {
                        var response = JsonConvert.DeserializeObject<CountryResponse>(www.downloadHandler.text);
                        Debug.Log("Location: " + response.country);
                        observer.OnNext(response.country);
                        observer.OnCompleted();
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                    }
                }
                else
                {
                    observer.OnError(new Exception(www.error));
                }
            }
        }

        [Serializable]
        public class CountryResponse
        {
            public string ip;
            public string country;
        }
    }
}
