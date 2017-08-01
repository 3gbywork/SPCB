using Microsoft.SharePoint.Client;
using SPBrowser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPBrowser.PropertyGridUtility.Adapter
{
    public static class ClientObjectAdapter
    {
        internal static object ConvertObject(object obj)
        {
            var clientObj = obj as ClientObject;
            if (clientObj != null)
            {
                var properties = new Dictionary<string, object>();
                ClientObjectPropertyUtility.CopyProperty(properties, clientObj);

                object value = null;
                if (properties.TryGetValue("TitleResource", out value))
                {
                    properties["TitleResource"] = new DictionaryPropertyGridAdapter(value as Dictionary<string, string>);
                }
                if (properties.TryGetValue("DescriptionResource", out value))
                {
                    properties["DescriptionResource"] = new DictionaryPropertyGridAdapter(value as Dictionary<string, string>);
                }

                return new DictionaryPropertyGridAdapter(properties);
            }

            return obj;
        }
    }
}
