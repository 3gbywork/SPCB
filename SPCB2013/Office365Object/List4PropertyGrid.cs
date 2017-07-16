using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Workflow;
using SPBrowser.PropertyGridUtility;
using SPBrowser.Utils;
using System;
using System.Collections.Generic;

namespace SPBrowser.Office365Object
{
    public class List4PropertyGrid : List
    {
        private List list;
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public List4PropertyGrid(List list) : base(list.Context, list.Path)
        {
            this.list = list;

            ClientObjectPropertyUtility.CopyProperty(properties, list);
        }

        public new bool AllowContentTypes => this.list.AllowContentTypes;
        public new bool AllowDeletion => this.list.AllowDeletion;
        public new int BaseTemplate => this.list.BaseTemplate;
        public new BaseType BaseType => this.list.BaseType;
        public new BrowserFileHandling BrowserFileHandling => this.list.BrowserFileHandling;
        public new ContentTypeCollection ContentTypes => this.list.ContentTypes;
        public new bool ContentTypesEnabled
        {
            get { return this.list.ContentTypesEnabled; }
            set { this.list.ContentTypesEnabled = value; }
        }

        public new bool CrawlNonDefaultViews
        {
            get { return this.list.CrawlNonDefaultViews; }
            set { this.list.CrawlNonDefaultViews = value; }
        }

        public new CreatablesInfo CreatablesInfo => this.list.CreatablesInfo;
        public new DateTime Created => this.list.Created;
        public new ChangeToken CurrentChangeToken => this.list.CurrentChangeToken;
        public new CustomActionElementCollection CustomActionElements => this.list.CustomActionElements;
        public new ListDataSource DataSource => this.list.DataSource;
        public new Guid DefaultContentApprovalWorkflowId
        {
            get { return this.list.DefaultContentApprovalWorkflowId; }
            set { this.list.DefaultContentApprovalWorkflowId = value; }
        }

        public new string DefaultDisplayFormUrl
        {
            get { return this.list.DefaultDisplayFormUrl; }
            set { this.list.DefaultDisplayFormUrl = value; }
        }

        public new string DefaultEditFormUrl
        {
            get { return this.list.DefaultEditFormUrl; }
            set { this.list.DefaultEditFormUrl = value; }
        }

        public new string DefaultNewFormUrl
        {
            get { return this.list.DefaultNewFormUrl; }
            set { this.list.DefaultNewFormUrl = value; }
        }

        public new View DefaultView => this.list.DefaultView;
        public new string DefaultViewUrl => this.list.DefaultViewUrl;
        public new string Description
        {
            get { return this.list.Description; }
            set { this.list.Description = value; }
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
            get { return this.list.Direction; }
            set { this.list.Direction = value; }
        }

        public new string DocumentTemplateUrl
        {
            get { return this.list.DocumentTemplateUrl; }
            set { this.list.DocumentTemplateUrl = value; }
        }

        public new DraftVisibilityType DraftVersionVisibility
        {
            get { return this.list.DraftVersionVisibility; }
            set { this.list.DraftVersionVisibility = value; }
        }

        public new BasePermissions EffectiveBasePermissions => this.list.EffectiveBasePermissions;
        public new BasePermissions EffectiveBasePermissionsForUI => this.list.EffectiveBasePermissionsForUI;
        public new bool EnableAttachments
        {
            get { return this.list.EnableAttachments; }
            set { this.list.EnableAttachments = value; }
        }

        public new bool EnableFolderCreation
        {
            get { return this.list.EnableFolderCreation; }
            set { this.list.EnableFolderCreation = value; }
        }

        public new bool EnableMinorVersions
        {
            get { return this.list.EnableMinorVersions; }
            set { this.list.EnableMinorVersions = value; }
        }

        public new bool EnableModeration
        {
            get { return this.list.EnableModeration; }
            set { this.list.EnableModeration = value; }
        }

        public new bool EnableVersioning
        {
            get { return this.list.EnableVersioning; }
            set { this.list.EnableVersioning = value; }
        }

        public new string EntityTypeName => this.list.EntityTypeName;
        public new EventReceiverDefinitionCollection EventReceivers => this.list.EventReceivers;
        public new FieldCollection Fields => this.list.Fields;
        public new bool FileSavePostProcessingEnabled => this.list.FileSavePostProcessingEnabled;
        public new bool ForceCheckout
        {
            get { return this.list.ForceCheckout; }
            set { this.list.ForceCheckout = value; }
        }

        public new FormCollection Forms => this.list.Forms;
        public new bool HasExternalDataSource => this.list.HasExternalDataSource;
        public new bool Hidden
        {
            get { return this.list.Hidden; }
            set { this.list.Hidden = value; }
        }

        public new Guid Id => this.list.Id;
        public new string ImageUrl
        {
            get { return this.list.ImageUrl; }
            set { this.list.ImageUrl = value; }
        }

        public new InformationRightsManagementSettings InformationRightsManagementSettings => this.list.InformationRightsManagementSettings;
        public new bool IrmEnabled
        {
            get { return this.list.IrmEnabled; }
            set { this.list.IrmEnabled = value; }
        }

        public new bool IrmExpire
        {
            get { return this.list.IrmExpire; }
            set { this.list.IrmExpire = value; }
        }

        public new bool IrmReject
        {
            get { return this.list.IrmReject; }
            set { this.list.IrmReject = value; }
        }

        public new bool IsApplicationList
        {
            get { return this.list.IsApplicationList; }
            set { this.list.IsApplicationList = value; }
        }

        public new bool IsCatalog => this.list.IsCatalog;
        public new bool IsPrivate => this.list.IsPrivate;
        public new bool IsSiteAssetsLibrary => this.list.IsSiteAssetsLibrary;
        public new int ItemCount => this.list.ItemCount;
        public new DateTime LastItemDeletedDate => this.list.LastItemDeletedDate;
        public new DateTime LastItemModifiedDate
        {
            get { return this.list.LastItemModifiedDate; }
            set { this.list.LastItemModifiedDate = value; }
        }

        public new string ListItemEntityTypeFullName => this.list.ListItemEntityTypeFullName;
        public new int MajorVersionLimit
        {
            get { return this.list.MajorVersionLimit; }
            set { this.list.MajorVersionLimit = value; }
        }

        public new int MajorWithMinorVersionsLimit
        {
            get { return this.list.MajorWithMinorVersionsLimit; }
            set { this.list.MajorWithMinorVersionsLimit = value; }
        }

        public new bool MultipleDataList
        {
            get { return this.list.MultipleDataList; }
            set { this.list.MultipleDataList = value; }
        }

        public new bool NoCrawl
        {
            get { return this.list.NoCrawl; }
            set { this.list.NoCrawl = value; }
        }

        public new bool OnQuickLaunch
        {
            get { return this.list.OnQuickLaunch; }
            set { this.list.OnQuickLaunch = value; }
        }

        public new Web ParentWeb => this.list.ParentWeb;
        public new string ParentWebUrl => this.list.ParentWebUrl;
        public new bool ParserDisabled
        {
            get { return this.list.ParserDisabled; }
            set { this.list.ParserDisabled = value; }
        }

        public new Folder RootFolder => this.list.RootFolder;
        public new string SchemaXml => this.list.SchemaXml;
        public new bool ServerTemplateCanCreateFolders => this.list.ServerTemplateCanCreateFolders;
        public new Guid TemplateFeatureId => this.list.TemplateFeatureId;
        public new string Title
        {
            get { return this.list.Title; }
            set { this.list.Title = value; }
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
        public new UserCustomActionCollection UserCustomActions => this.list.UserCustomActions;
        public new string ValidationFormula
        {
            get { return this.list.ValidationFormula; }
            set { this.list.ValidationFormula = value; }
        }

        public new string ValidationMessage
        {
            get { return this.list.ValidationMessage; }
            set { this.list.ValidationMessage = value; }
        }

        public new ViewCollection Views => this.list.Views;
        public new WorkflowAssociationCollection WorkflowAssociations => this.list.WorkflowAssociations;
    }
}
