using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarsCatalog
{
    public partial class CarsCatalog : System.Web.UI.Page
    {
        List<Producer> Producers = new List<Producer>() 
            { 
                new Producer() {
                    ProducerID = 1,
                    ProducerName = "BMW", 
                    Models = new List<CarModel>() 
                    {
                        new CarModel() { CarName = "720" },
                        new CarModel() { CarName= "850" },
                        new CarModel() { CarName= "930" },
                    }
                },
                new Producer() {
                    ProducerID = 2,
                    ProducerName = "Mercedes", 
                    Models = new List<CarModel>() 
                    {
                        new CarModel() { CarName = "SLK" },
                        new CarModel() { CarName= "M214" },
                        new CarModel() { CarName= "S852" },
                    }
                }
            };

        List<Extra> extras = new List<Extra>()
        {
            new Extra() { Type = "Extra1" },
            new Extra() { Type = "Extra2" },
            new Extra() { Type = "Extra3" },
            new Extra() { Type = "Extra4" }
        };

        string[] engines = new string[] { "engine1", "engine2", "engine3", "engine4" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DropDownProducer.DataSource = Producers;
                this.DropDownProducer.DataBind();
                this.DropDownProducer.SelectedIndex = 0;

                LoadModelDataSource();

                this.CheckBoxList_Extra.DataSource = extras;
                this.CheckBoxList_Extra.DataBind();

                this.RadioButtonList_Engine.DataSource = engines;
                this.RadioButtonList_Engine.DataBind();
            }
        }

        protected void DropDownProducer_IndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DropDownProducer.Items.Count; i++)
            {
                if (this.DropDownProducer.Items[i].Selected)
                {
                    string name = this.DropDownProducer.Items[i].Text;
                    Producer producer = this.Producers.Where(p => p.ProducerName == name).FirstOrDefault();
                    this.DropDownModel.DataSource = producer.Models;
                    this.DropDownModel.DataBind();
                }
            }
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.DropDownProducer.Items.Count; i++)
            {
                if (this.DropDownProducer.Items[i].Selected)
                {
                    sb.Append("<b>Producer: </b>" + this.DropDownProducer.Items[i].Text + "<br />");
                }
            }

            for (int i = 0; i < this.DropDownModel.Items.Count; i++)
            {
                if (this.DropDownModel.Items[i].Selected)
                {
                    sb.Append("<b>Model: </b>" + this.DropDownModel.Items[i].Text + "<br />");
                }
            }

            sb.Append("<b>Extras: </b>");
            for (int i = 0; i < this.CheckBoxList_Extra.Items.Count; i++)
            {
                if (this.CheckBoxList_Extra.Items[i].Selected)
                {
                    sb.Append(this.CheckBoxList_Extra.Items[i].Text + "<br />");
                }
            }

            for (int i = 0; i < this.RadioButtonList_Engine.Items.Count; i++)
            {
                if (this.RadioButtonList_Engine.Items[i].Selected)
                {
                    sb.Append("<b>Engine: </b>" + this.RadioButtonList_Engine.Items[i].Text + "<br />");
                }
            }

            this.LiteralResult.Text = sb.ToString();
        }

        private void LoadModelDataSource()
        {
            for (int i = 0; i < this.DropDownProducer.Items.Count; i++)
            {
                if (this.DropDownProducer.Items[i].Selected)
                {
                    string name = this.DropDownProducer.Items[i].Text;
                    Producer producer = this.Producers.Where(p => p.ProducerName == name).FirstOrDefault();
                    this.DropDownModel.DataSource = producer.Models;
                    this.DropDownModel.DataBind();
                }
            }
        }
    }
}