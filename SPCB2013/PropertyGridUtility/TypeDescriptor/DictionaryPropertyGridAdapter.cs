using System;
using System.Collections;
using System.ComponentModel;

namespace SPBrowser.PropertyGridUtility
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DictionaryPropertyGridAdapter : ICustomTypeDescriptor
    {
        private IDictionary dictionary;

        public DictionaryPropertyGridAdapter(IDictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = new ArrayList();
            foreach (DictionaryEntry pair in dictionary)
            {
                properties.Add(new DictionaryPropertyDescriptor(dictionary, pair.Key));
            }
            return new PropertyDescriptorCollection((PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor)));
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this.dictionary;
        }
    }
}
