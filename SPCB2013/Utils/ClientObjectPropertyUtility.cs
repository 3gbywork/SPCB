using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SPBrowser.Utils
{
    public delegate ClientObjectData GetObjectData(ClientObject clientObject);

    public class ClientObjectPropertyUtility
    {
        public static GetObjectData GetProperty { get; set; }

        static ClientObjectPropertyUtility()
        {
            MethodInfo method = typeof(ClientObject).GetProperty("ObjectData", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty).GetGetMethod(true);
            GetProperty = (GetObjectData)Delegate.CreateDelegate(typeof(GetObjectData), method);
        }

        public static void CopyProperty(Dictionary<string, object> proDic, ClientObject Obj)
        {
            ClientObjectData objData = GetProperty(Obj);
            var clientObjData = objData.Properties.Concat(objData.ClientObjectProperties);
            foreach (KeyValuePair<string, object> propertyInfo in clientObjData)
            {
                object obj = propertyInfo.Value;
                if (obj == null)
                {
                    // 设置为null PropertyGrid会抛异常，故改为string.Empty
                    proDic[propertyInfo.Key] = string.Empty;// null;
                }
                else
                {
                    Type proType = obj.GetType();
                    if (proType.IsEnum)
                    {
                        proDic[propertyInfo.Key] = CastEnumValue((obj));
                    }
                    else if (proType.FullName.Equals("Microsoft.SharePoint.Client.UserResource", StringComparison.OrdinalIgnoreCase))
                    {
                        ClientObjectData resourceData = GetProperty((ClientObject)obj);
                        if (resourceData.MethodReturnObjects.TryGetValue("GetValueForUICulture", out object value))
                        {
                            if (value is Dictionary<string, ClientResult<string>> result)
                            {
                                proDic[propertyInfo.Key] = result.ToDictionary(p => p.Key, p => p.Value.Value, StringComparer.OrdinalIgnoreCase);
                            }
                        }
                    }
                    else
                    {
                        proDic[propertyInfo.Key] = obj;
                    }
                }
            }
        }

        public static object CastEnumValue(object value)
        {
            Type underlyingType = Enum.GetUnderlyingType(value.GetType());
            return Convert.ChangeType(value, underlyingType);
        }
    }
}
