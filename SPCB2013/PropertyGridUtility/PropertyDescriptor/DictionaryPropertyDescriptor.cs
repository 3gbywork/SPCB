using System;
using System.Collections;
using System.ComponentModel;

namespace SPBrowser.PropertyGridUtility
{
    public class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        private IDictionary dictionary;
        private object key;

        public DictionaryPropertyDescriptor(IDictionary dictionary, object key) : base(key.ToString(), null)
        {
            this.dictionary = dictionary;
            this.key = key;
        }

        public override Type ComponentType => null;

        public override bool IsReadOnly => false;

        public override Type PropertyType => dictionary[key]?.GetType();

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            return dictionary[key];
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            dictionary[key] = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
