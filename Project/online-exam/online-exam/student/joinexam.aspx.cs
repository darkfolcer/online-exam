﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.student
{
    public partial class joinexam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            string examId = Request["examId"].ToString();
            Response.Redirect("question.aspx?examId="+examId+"?questionId=1");
        }
    }
}