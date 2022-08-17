namespace UnityEngine
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance => JamSuite.SingletonHelper<T>.Instance;
        public static T WeakInstance => JamSuite.SingletonHelper<T>.WeakInstance;
    }
}

namespace JamSuite
{
    public class SingletonHelper<T> where T : UnityEngine.Object
    {
        public static T Instance {
            get {
                if (!_instance) _instance = UnityEngine.Object.FindObjectOfType<T>();
                return _instance;
            }
        }
        public static T WeakInstance => _instance;

        static T _instance;
    }
}
