using System;
using System.Reflection;


namespace AuxiliaryClassesForTesting
{
    public class PrivateDataAccessor
    {
        public static object GetObjectFromCertainMethod(string methodName, MethodInfo[] methods, object fromObj, object arg)
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

        public static object GetObjectFromCertainMethod(string methodName, MethodInfo[] methods, object fromObj)
        {
            return GetObjectFromCertainMethod(methodName, methods, fromObj, null);
        }

        public static void SetObjectInCertainMethod(string methodName, MethodInfo[] methods, object fromObj, object newObj)
        {
            foreach (MethodInfo oneMethod in methods)
            {
                if (oneMethod.Name == methodName)
                {
                    if (newObj.GetType() == typeof(object[]))
                    {
                        object[] newObjArray = (object[])newObj;
                        oneMethod.Invoke(fromObj, newObjArray);
                    }
                    else
                    {
                        oneMethod.Invoke(fromObj, new object[] { newObj });
                    }
                    break;
                }
            }
        }
    }
}
