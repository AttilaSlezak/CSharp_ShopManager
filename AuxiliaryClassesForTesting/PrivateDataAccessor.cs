using System;
using System.Reflection;


namespace AuxiliaryClassesForTesting
{
    public class PrivateDataAccessor
    {
        public static object GetObjectFromCertainMethod(string methodName, MethodInfo[] methods, Object fromObj, Object arg)
        {
            object result = null;
            foreach (MethodInfo oneMethod in methods)
            {
                if (oneMethod.Name == methodName)
                {
                    if (arg == null)
                        result = oneMethod.Invoke(fromObj, new object[] { });
                    else
                        result = oneMethod.Invoke(fromObj, new object[] { arg });
                    break;
                }
            }
            return result;
        }

        public static object GetObjectFromCertainMethod(string methodName, MethodInfo[] methods, Object fromObj)
        {
            return GetObjectFromCertainMethod(methodName, methods, fromObj, null);
        }

        private void SetObjectInCertainMethod(string methodName, MethodInfo[] methods, Object fromObj, Object newObj)
        {
            foreach (MethodInfo oneMethod in methods)
            {
                if (oneMethod.Name == methodName)
                {
                    oneMethod.Invoke(fromObj, new object[] { newObj });
                    break;
                }
            }
        }
    }
}
