// System
using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

// ActiveLayerExplorer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Repositories;

namespace Dataverse.XrmTools.Deployer.Logic
{
    public class DataLogic
    {
        #region Variables
        private BackgroundWorker _worker;

        private readonly IOrganizationService _sourceSvc;
        private readonly IOrganizationService _targetSvc;

        private EntityCollection _sourceCollection;
        private EntityCollection _mappedCollection;
        private EntityCollection _targetCollection;

        private List<ListViewItem> _resultsData = new List<ListViewItem>();
        #endregion Variables

        #region Constructors
        public DataLogic(BackgroundWorker worker, IOrganizationService sourceSvc, IOrganizationService targetSvc)
        {
            _worker = worker;
            _sourceSvc = sourceSvc;
            _targetSvc = targetSvc;
        }
        #endregion Constructors

        #region Public Methods
        #endregion Public Methods

        #region Private Methods
        #endregion Private Methods
    }
}
