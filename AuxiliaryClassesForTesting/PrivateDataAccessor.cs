using System;
using System.Reflection;


namespace AuxiliaryClassesForTesting
{
    public class PrivateDataAccessor
    {
        public static object GetObjectFromCertainMethod(MethodInfo method, object fromObj, object args)
        {
            object result = null;
        
            if (args == null)
                result = method.Invoke(fromObj, new object[] { });
            else if (args.GetType() == typeof(object[]))
            {
                object[] newObjArray = (object[])args;
                method.Invoke(fromObj, newObjArray);
            }
            else
                result = method.Invoke(fromObj, new object[] { args });

            return result;
        }


        public static object GetObjectFromCertainMethod(string methodName, MethodInfo[] methods, object fromObj, object args)
        {
            MethodInfo method = SearchForProperMethod(methodName, methods, args);
            if (method != null)
                return GetObjectFromCertainMethod(method, fromObj, args);
            else
                return null;
        }

        public static object GetObjectFromCertainMethod(string methodName, MethodInfo[] methods, object fromObj)
        {
            return GetObjectFromCertainMethod(methodName, methods, fromObj, null);
        }

        public static object GetObjectFromCertainMethod(MethodInfo method, object fromObj)
        {
            return GetObjectFromCertainMethod(method, fromObj, null);
        }

        public static void SetObjectInCertainMethod(MethodInfo method, object fromObj, object args)
        {
            if (args == null)
                method.Invoke(fromObj, new object[] { });
            else if (args.GetType() == typeof(object[]))
            {
                object[] argsArray = (object[])args;
                method.Invoke(fromObj, argsArray);
            }
            else
            {
                method.Invoke(fromObj, new object[] { args });
            }
        }

        public static void SetObjectInCertainMethod(string methodName, MethodInfo[] methods, object fromObj, object args)
        {
            MethodInfo method = SearchForProperMethod(methodName, methods, args);
            if (method != null)
                SetObjectInCertainMethod(method, fromObj, args);
        }

        public static object GetObjectFromCertainProperty(PropertyInfo property, object fromObj)
        {
            return property.GetValue(fromObj);
        }
        
        private static bool IsCastable(Type castTo, Type castFrom)
        {
            if (castTo == typeof(object))
                return true;
            else if (castTo == castFrom)
                return true;
            else if (castTo.IsAssignableFrom(castFrom))
                return true;
            else if (castTo == typeof(int) && castFrom == typeof(char))
                return true;
            else
                return false;
        }

        private static MethodInfo SearchForProperMethod(string methodName, MethodInfo[] methods, Object args)
        {
            bool areParametersMatching;
            foreach (MethodInfo oneMethod in methods)
            {
                areParametersMatching = true;
                if (oneMethod.Name != methodName)
                    continue;

                if (args == null)
                {
                    if (oneMethod.GetParameters().Length == 0)
                    {
                        return oneMethod;
                    }
                }
                else if (args.GetType() == typeof(object[])) {
                    if (oneMethod.GetParameters().Length == ((Object[]) args).Length) {
                        for (int i = 0; i<oneMethod.GetParameters().Length; i++) {
                            if (!IsCastable(oneMethod.GetParameters()[i].ParameterType, ((Object[]) args)[i].GetType())) {
                                areParametersMatching = false;
                                break;
                            }
                        }
                        if (areParametersMatching)
                            return oneMethod;
                        else
                            continue;
                    }
                } else if (oneMethod.GetParameters().Length == 1 && IsCastable(oneMethod.GetParameters()[0].ParameterType,
                    args.GetType()))
                return oneMethod;
            }
            return null;
        }
    }
}
