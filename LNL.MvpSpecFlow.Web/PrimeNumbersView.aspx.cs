using System;
using LNL.MvpSpecFlow.Contracts;
using LNL.MvpSpecFlow.Models;
using LNL.MvpSpecFlow.Web.Presenters;

namespace LNL.MvpSpecFlow.Web
{
    public partial class PrimeNumbersView : System.Web.UI.Page, IPrimeNumbersView
    {
        public event Action OnSave;
        public event Action LoadData;
        public event Action CalculatePrimes;
        public PrimeNumbersModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            new PrimeNumbersPresenter(this);

            if (LoadData != null)
                LoadData();

            InitControls();
        }

        private void InitControls()
        {
            if (IsPostBack)
                return;

            MapModelToUi();
        }


        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            MapUiToModel();

            if(OnSave != null)
                OnSave();

            MapModelToUi();
        }

        protected void btnShowPrimes_OnClick(object sender, EventArgs e)
        {
            MapUiToModel();

            if (CalculatePrimes != null)
                CalculatePrimes();

            MapModelToUi();
        }


        private void MapModelToUi()
        {
            txtEntityId.Text = Model.Id.ToString();
            txtEntityName.Text = Model.Name;
            txtEntityNumber.Text = Model.Number.ToString();
            chbEntityIsEnabled.Checked = Model.IsEnabled;
            chbEntityIsNumberPrime.Checked = Model.IsPrime;

            rptPrimesCollection.DataSource = Model.PrimesCollection;
            rptPrimesCollection.DataBind();
        }
        
        private void MapUiToModel()
        {
            Model.Id = int.Parse(txtEntityId.Text);
            Model.Name = txtEntityName.Text;
            Model.Number = int.Parse(txtEntityNumber.Text);
            Model.IsEnabled = chbEntityIsEnabled.Checked;
        }
    }
}