using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSourceControls.WorldDataTasks
{
    public partial class WorldDataInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TheWorldDBEntities db = new TheWorldDBEntities();

            //EntityDataSource ds = new EntityDataSource();

            //ds.ConnectionString = ConfigurationManager.ConnectionStrings["WorldDBConnectionString"].ConnectionString.Replace("&quot;","'");
            //ds.DefaultContainerName = "TheWorldDBEntities";
            //ds.EntitySetName = "Countries";
            //ds.EnableUpdate = true;
            //ds.EnableFlattening = false;

            // this.CountriesListView.DataSource = db.Countries.ToList();

            // this.DataBind();

        }



        protected void CustomValidatorTownPopulation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int value;
            var isValid = int.TryParse(args.Value, out value);
            args.IsValid = isValid && value >= 0;
            var validator = (source as CustomValidator).ErrorMessage = string.Format("Must be int number between 0 and {0}.", int.MaxValue);
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {

            this.TownsListView.InsertItemPosition = InsertItemPosition.LastItem;

        }

        protected void ListViewTowns_ItemInserted(object sender,
            ListViewInsertedEventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ListViewCountries_ItemInserted(object sender,
             ListViewInsertedEventArgs e)
        {
            this.ListViewCountries.InsertItemPosition = InsertItemPosition.None;
        }
        protected void CustomValidatorInsertCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value != "-1";
        }

        public void ButtonInsertCountry_Click(object sender, EventArgs e)
        {
            this.ListViewCountries.InsertItemPosition = InsertItemPosition.LastItem;
        }

    }
}