using Microsoft.SharePoint.Client;
using SPBrowser.PropertyGridUtility;
using SPBrowser.Utils;
using System;
using System.Collections.Generic;

namespace SPBrowser.Office365Object
{
    public class Field4PropertyGrid : Field
    {
        private Field field;
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public Field4PropertyGrid(Field field) : base(field.Context, field.Path)
        {
            this.field = field;

            ClientObjectPropertyUtility.CopyProperty(properties, field);
        }

        public new bool AutoIndexed => this.field.AutoIndexed;
        public new bool CanBeDeleted => this.field.CanBeDeleted;
        public new string DefaultFormula
        {
            get { return this.field.DefaultFormula; }
            set { this.field.DefaultFormula = value; }
        }
        public new string DefaultValue
        {
            get { return this.field.DefaultValue; }
            set { this.field.DefaultValue = value; }
        }
        public new string Description
        {
            get { return this.field.Description; }
            set { this.field.Description = value; }
        }
        public new DictionaryPropertyGridAdapter DescriptionResource
        {
            get
            {
                if (properties.TryGetValue("DescriptionResource", out object value))
                {
                    return new DictionaryPropertyGridAdapter(value as Dictionary<string, string>);
                }
                return null;
            }
        }
        public new string Direction
        {
            get { return this.field.Direction; }
            set { this.field.Direction = value; }
        }
        public new bool EnforceUniqueValues
        {
            get { return this.field.EnforceUniqueValues; }
            set { this.field.EnforceUniqueValues = value; }
        }
        public new string EntityPropertyName => this.field.EntityPropertyName;
        public new FieldType FieldTypeKind
        {
            get { return this.field.FieldTypeKind; }
            set { this.field.FieldTypeKind = value; }
        }
        public new bool Filterable => this.field.Filterable;
        public new bool FromBaseType => this.field.FromBaseType;
        public new string Group
        {
            get { return this.field.Group; }
            set { this.field.Group = value; }
        }
        public new bool Hidden
        {
            get { return this.field.Hidden; }
            set { this.field.Hidden = value; }
        }
        public new Guid Id => this.field.Id;
        public new bool Indexed
        {
            get { return this.field.Indexed; }
            set { this.field.Indexed = value; }
        }
        public new string InternalName => this.field.InternalName;
        public new string JSLink
        {
            get { return this.field.JSLink; }
            set { this.field.JSLink = value; }
        }
        public new bool ReadOnlyField
        {
            get { return this.field.ReadOnlyField; }
            set { this.field.ReadOnlyField = value; }
        }
        public new bool Required
        {
            get { return this.field.Required; }
            set { this.field.Required = value; }
        }
        public new string SchemaXml
        {
            get { return this.field.SchemaXml; }
            set { this.field.SchemaXml = value; }
        }
        public new string SchemaXmlWithResourceTokens => this.field.SchemaXmlWithResourceTokens;
        public new string Scope => this.field.Scope;
        public new bool Sealed => this.field.Sealed;
        public new bool Sortable => this.field.Sortable;
        public new string StaticName
        {
            get { return this.field.StaticName; }
            set { this.field.StaticName = value; }
        }
        public new string Title
        {
            get { return this.field.Title; }
            set { this.field.Title = value; }
        }
        public new DictionaryPropertyGridAdapter TitleResource
        {
            get
            {
                if (properties.TryGetValue("TitleResource", out object value))
                {
                    return new DictionaryPropertyGridAdapter(value as Dictionary<string, string>);
                }
                return null;
            }
        }
        public new string TypeAsString
        {
            get { return this.field.TypeAsString; }
            set { this.field.TypeAsString = value; }
        }
        public new string TypeDisplayName => this.field.TypeDisplayName;
        public new string TypeShortDescription => this.field.TypeShortDescription;
        public new string ValidationFormula
        {
            get { return this.field.ValidationFormula; }
            set { this.field.ValidationFormula = value; }
        }
        public new string ValidationMessage
        {
            get { return this.field.ValidationMessage; }
            set { this.field.ValidationMessage = value; }
        }

    }
}
