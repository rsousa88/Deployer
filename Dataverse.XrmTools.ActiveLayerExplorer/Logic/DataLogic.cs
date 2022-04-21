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
using Dataverse.XrmTools.ActiveLayerExplorer.Models;
using Dataverse.XrmTools.ActiveLayerExplorer.Helpers;
using Dataverse.XrmTools.ActiveLayerExplorer.AppSettings;
using Dataverse.XrmTools.ActiveLayerExplorer.Repositories;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Logic
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
