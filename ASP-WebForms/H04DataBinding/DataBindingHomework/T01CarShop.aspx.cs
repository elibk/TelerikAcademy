using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHomework
{
    public partial class T01CarShop : System.Web.UI.Page
    {
        public static List<Producer> producers;

        #region ModelsToyota
        private static List<string> modelsToyota = new List<string>
       {
            "Yun Dong Shuang Qing",
            "Yaris Cabrio Concept",
            "X-Runner",
            "Winglet",
            "VM180",
            "UUV",
            "TownAce Van EV",
            "Town Spider System",
            "TES ERA EV",
            "TAC3",
            "T Sports",
            "SV-3",
            "SV-2",
            "SV-1",
            "SU-HV1",
            "Sports X",
            "Sports EV Twin",
            "Sports EV",
            "Sports 800 Gas Turbine Hybrid",
            "Sports",
            "Sportivo Coupe",
            "Solara Concept",
            "Soarer Aero Cabin",
            "SC",
            "RV-5",
            "RV-2",
            "RV-1",
            "Rugged Youth Utility",
            "RSC",
            "RiN",
            "Retro Cruiser",
            "Publica Sports",
            "Project Go",
            "Prius+",
            "Prius Plug-in Hybrid",
            "Prius PHV",
            "Prius Custom Plus Concept",
            "Prius c Concept",
            "Prius",
            "Pod",
            "PM",
            "Open Deck",
            "NS4",
            "NLSV",
            "NCSV",
            "MRJ",
            "MR2 Street Affair",
            "MR2 Group B Prototype",
            "MR-S",
            "MP-1",
            "Motor Triathlon Race Car",
            "Moguls",
            "ME.WE",
            "Matrix Sport",
            "Marinetta 10",
            "Marinetta",
            "Marine Cruiser",
            "Land Cruiser FJ45 Concept",
            "iiMo",
            "i-unit",
            "i-swing",
            "i-Road",
            "i-real",
            "i-foot",
            "Hybrid X",
            "Hybrid Electric Bus",
            "HV-M4",
            "Hi-CT",
            "HC-CV",
            "GTV",
            "GRMN Sports Hybrid Concept II",
            "GRMN Sports Hybrid Concept",
            "FXV-II",
            "FXV",
            "FXS",
            "FX-1",
            "Furia",
            "Funtime",
            "Funcoupe",
            "Funcargo",
            "Fun-vii",
            "Fun Runner II",
            "Fun Runner",
            "FTX",
            "FT-SX",
            "FT-MV",
            "FT-HS",
            "FT-EV III",
            "FT-EV II",
            "FT-EV",
            "FT-CH",
            "FT-Bh",
            "FT-86 II",
            "FT-86 G Sports",
            "FT-86",
            "FSC",
            "FLV",
            "Fine-X",
            "Fine-T",
            "Fine-S",
            "Fine-N",
            "FCX-80",
            "FCV-R",
            "FCHV-adv",
            "FCHV-4",
            "FCHV-3",
            "FCHV-2",
            "FCHV-1",
            "FCHV",
            "Family Wagon",
            "F3R",
            "F120",
            "F110",
            "F101",
            "EX-III",
            "EX-II",
            "EX-I",
            "EX-7",
            "EX-11",
            "EV-30",
            "EV Prototype",
            "ESV-2",
            "ESV",
            "ES3",
            "Endo",
            "Electronics Car",
            "EB",
            "EA",
            "DV-1",
            "Dream Car Model",
            "Dream Car",
            "DMT",
            "diji",
            "Dear Qin",
            "D-4D 180 Clean Power Concept Car",
            "CX-80",
            "CS&S",
            "Crown Majesta EV",
            "Crown Convertible",
            "CQ-1",
            "Corona Sports Coupe",
            "Corona 1900S Sporty Sedan",
            "Corona 1500S Convertible",
            "Commuter",
            "Century GT45",
            "Celica XYR",
            "Celica Ultimate Concept",
            "Celica Cruising Deck",
            "ccX",
            "Camry TS-01",
            "Camry CNG Hybrid",
            "Camatte",
            "CAL-1",
            "Aygo Crazy",
            "AXV-V",
            "AXV-IV",
            "AXV-III",
            "AXV-II",
            "AXV",
            "Avalon (Concept)",
            "Aurion Sports Concept",
            "ASV-3",
            "ASV-2",
            "ASV",
            "Alessandro Volta",
            "Airport Limousine (1977)",
            "Airport Limousine (1961)",
            "A1",
            "A-BAT",
            "4500GT",
            "1/X",
            "Toyopet X",
            "Scion iQ Concept / Toyota iQ Sport",

       };
        #endregion

        #region ModelsBMW
        private static List<string> modelsBmw = new List<string>
       {
            "501",
            "502",
            "503",
            "507",
            "3200 CS",
            "Typ100",
            "Typ106",
            "Typ107",
            "Typ110",
            "Typ114",
            "Typ115",
            "Typ116",
            "Typ118",
            "Typ120",
            "Typ121",
            "E3",
            "E9",
            "E12",
            "E21",
            "E23",
            "E24",
            "E26",
            "E28",
            "E30",
            "E31",
            "E32",
            "E34",
            "E36",
            "E36/5",
            "E36/7",
            "E36/8",
            "E38",
            "E38/2",
            "E38/3",
            "E39",
            "E46/5",
            "E46/4",
            "E46/3",
            "E46/2",
            "E46/C",
            "E52",
            "E53",
            "E60",
            "E61",
            "E62",
            "E63",
            "E64",
            "E65",
            "E66",
            "E67",
            "E68",
            "E70",
            "E71",
            "E72",
            "E81",
            "E82",
            "E83",
            "E84",
            "E85",
            "E86",
            "E87",
            "E88",
            "E89",
            "E90",
            "E91",
            "E92",
            "E93",
            "F01",
            "F02",
            "F03",
            "F04",
            "F06",
            "F07",
            "F10",
            "F11",
            "F12",
            "F13",
            "F15",
            "F18",
            "F20",
            "F21",
            "F22",
            "F25",
            "F26",
            "F30",
            "F31",
            "F32",
            "F33",
            "F34",
            "F35",
            "F36",
            "F80",
            "F82",
            "G11",


                   };
        #endregion

        #region ModelsLada
        private static List<string> modelsLada = new List<string>
       {
           "ВАЗ 2101 (Жигули)",
            "ВАЗ 2102",
            "ВАЗ 2103",
            "ВАЗ 2104",
            "ВАЗ 2105",
            "ВАЗ 2106",
            "ВАЗ 2107",
            "Самара (ВАЗ 2108)",
            "Спутник (ВАЗ 2109)",
            "110 - Вега (ВАЗ 2110)",
            "111 (ВАЗ 2111)",
            "112 (ВАЗ 2112)",
            "Самара 2 (ВАЗ 2113, ВАЗ 2114, ВАЗ 2115)",
            "Нива (Лада 4х4; ВАЗ 2121)",
            "Шевролет Нива",
            "Калина",
            "Приора (ВАЗ 2170)",
            "Гранта",
            "Революшън (Revolution)",

       };
        #endregion

        List<string> extras = new List<string>() 
        {
            "Remote keyless entry",
            "OnStar System",
            "Anti-lock brakes (ABS)",
            "Electronic stability/skid-control system",
            "Telescoping steering wheel/adjustable pedals",
            "Rear-seat DVD player",
            "GPS navigation system",
            "Side airbags",
            "Center console with power outlet",
            "Roadside assistance"
        };

        List<string> engines = new List<string>()
        {
            "ANY",
            "AMF",
            "ATL",
            "BHC",
            "BAD",
            "AGN"
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                producers = new List<Producer>
                {
                    new Producer
                    {
                        Name = "Toyota",
                        Models = modelsToyota
                    },
                    new Producer
                    {
                        Name = "BMW",
                        Models = modelsBmw
                    },
                    new Producer
                    {
                        Name = "Lada",
                        Models = modelsLada
                    },


                };


                this.DDLProducers.DataSource = producers;
               
               
                this.ExtrasCheckBox.DataSource = extras;
               

                this.RadioButtonListEngines.DataSource = engines;
                this.DataBind();
                this.DDLProducers.Items.Insert(0, new ListItem("--Select--", "-1"));
            }

        }

        protected void SubmitCar_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                StringBuilder strBuild = new StringBuilder();
                strBuild.Append("Producer: ");
                strBuild.AppendLine(this.DDLProducers.SelectedValue);
                strBuild.Append("Model: ");
                strBuild.AppendLine(this.DDLModels.SelectedValue);

                strBuild.Append("Engine: ");
                strBuild.AppendLine(this.RadioButtonListEngines.SelectedValue);

                var hasExtras = false;
                strBuild.Append("Extras: ");
                foreach (ListItem item in this.ExtrasCheckBox.Items)
                {
                    if (item.Selected)
                    {
                        hasExtras = true;
                        strBuild.Append(item.Value);
                        strBuild.Append(", ");
                    }
                }
                if (hasExtras)
                {
                    strBuild.Length--;
                    strBuild.Length--;
                }
                else
                {
                    strBuild.Append("Not available.");
                }
                
                this.DisplayField.Text = strBuild.ToString();
            }
        }

        protected void ListProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var selIndex = this.DDLProducers.SelectedIndex;
            if (selIndex == 0)
            {
                this.DDLModels.Enabled = false;
            }
            else
            {
                this.DDLModels.Enabled = true;
                this.DDLModels.DataSource = producers[selIndex - 1].Models;
           
            }

            this.DataBind();
            this.DDLModels.Items.Insert(0, new ListItem("--Select--", "-1"));
            this.DDLModels.SelectedIndex = 0;
        }

        protected void DropDown_OnServerValidate(object source, ServerValidateEventArgs args)
        {

            args.IsValid = args.Value != "-1";
        }
    }
}