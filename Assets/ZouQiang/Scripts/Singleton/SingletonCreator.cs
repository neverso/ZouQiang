namespace ZouQiang
{
    using System;
    using System.Reflection;

    public static class SingletonCreator
    {
        public static T CreateSingleton<T>() where T : class, ISingleton
        {
            // 使用反射 获取私有构造函数
            var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            
            // 获取无参构造函数
            var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);

            if (ctor == null)
            {
                throw new Exception("Non-Public Constructor() not found! in " + typeof(T));
            }

            // 通过构造函数，返回实例
            var retInstance = ctor.Invoke(null) as T;
            retInstance.OnSingletonInit();

            return retInstance;
        }
    }
}