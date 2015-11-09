﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GRA.SRP.DAL;
using GRA.Tools;
using System.Data;

namespace GRA.SRP.Controls {
    public partial class MyBadgesListControl : System.Web.UI.UserControl {

        protected string BadgeClass { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            int badgeCount = 0;
            if(!IsPostBack) {
                var ds = DAL.PatronBadges.GetAll(((Patron)Session["Patron"]).PID);
                rptr.DataSource = ds;
                rptr.DataBind();
                badgeCount = ds.Tables[0].Rows.Count;
            } else {
                var badgeCountObj = ViewState["BadgeCount"];
                if(!(badgeCountObj != null
                     && int.TryParse(badgeCountObj.ToString(), out badgeCount))) {
                    // if we don't have a count, format for 3
                    badgeCount = 3;
                }
            }

            NoBadges.Visible = (badgeCount == 0);
            if(badgeCount == 1) {
                this.BadgeClass = "col-xs-6 col-xs-offset-3 col-md-4 col-md-offset-4";
            } else if(badgeCount == 2) {
                this.BadgeClass = "col-xs-6 col-md-6";
            } else {
                this.BadgeClass = "col-xs-6 col-md-4";
            }
            ViewState["BadgeCount"] = badgeCount;
        }
    }
}