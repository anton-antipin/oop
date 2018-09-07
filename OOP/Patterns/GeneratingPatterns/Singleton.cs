// 1. гарантирует что для определенного класса будет создан только один объект,
//      а также предоставит к этому объекту точку доступа
// 2.   - когда необходимо чтобы для класса существовал только один экземпляр
// 3.

namespace OOP.Patterns.GeneratingPatterns.Singleton
{
    #region Template
    class Singleton
    {
        private static Singleton _instance;
        private static object _synchrObj = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }


    }

    class LazySingleton
    {
        private LazySingleton()
        {

        }

        public static LazySingleton GetInstance()
        {
            return Nested.Instance;
        }

        private class Nested
        {
            internal static readonly LazySingleton Instance = new LazySingleton();
        }
    }
    #endregion
}
