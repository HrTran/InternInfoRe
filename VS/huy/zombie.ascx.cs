using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Orm.Interns.DatabaseInteracts;
using System.Data.SqlClient;

namespace Orm.Interns.huy
{
    public partial class zombie : System.Web.UI.UserControl
    {
        private static int KeywordId;
        private static int _pagenumber;
        private static int total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Data();
            }
        }

        /*
        protected void drpDList_DataBound(object sender, EventArgs e)
        {
            //kwd = Int32.Parse(drpDList.Text);
            KeywordId = drpDList.selectValue.tostring();
            DataTable myDatatable = PostOrmDB.GetAllbykeywordId(KeywordId);
         
            Label Lbl2 = e.Item.FindControl("lb2") as Label;
            try
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                Lbl2.Text = dr["SampleContent"].ToString();
            }
            catch (Exception ex)
            {
                Lbl2.Text = ex.Message;
            }
         
         
            drpDList.DataSource = myDatatable;
            drpDList.DataTextField = "Ten";
            drpDList.DataValueField = "ID";
            drpDList.DataBind();
        }
        */
        protected void get10Lines_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label Lbl2 = e.Item.FindControl("lb2") as Label;
            try
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                Lbl2.Text = dr["SampleContent"].ToString();
            }
            catch (Exception ex)
            {
                Lbl2.Text = ex.Message;
            }
        }

        protected void Load_Data()
        { 
            KeywordId = Convert.ToInt32(Request.QueryString["keywordid"]);
            total = PostOrmDB.count_by_keywordid(KeywordId);
            _pagenumber = total/10;

            if(total > 1)
            {
                rptPages.Visible = true;
                btn_pre.Visible = true;
                btn_next.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                if (total < 5)
                {
                    for (int i = 0; i < total; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
                }
                else 
                {
                    if(PageNumber < 2)
                    {
                        pages.Add((PageNumber - 1).ToString());
                        pages.Add((PageNumber).ToString());
                        pages.Add((PageNumber + 1).ToString());
                        pages.Add(  (((PageNumber + 1)+_pagenumber)/2 + 1)  .ToString());
                        btn_last.Visible = true;
                    } else if(PageNumber > (total - 2))
                    {
                        pages.Add((((PageNumber + 1) - 1) / 2 + 1).ToString());
                        pages.Add((PageNumber - 1).ToString());
                        pages.Add((PageNumber).ToString());
                        pages.Add((PageNumber + 1).ToString());
                        btn_first.Visible = true;
                    } else
                    {
                        pages.Add((PageNumber - 1).ToString());
                        pages.Add((PageNumber).ToString());
                        pages.Add((PageNumber + 1).ToString());
                        pages.Add((((PageNumber + 1) + _pagenumber) / 2 + 1).ToString());
                        btn_first.Visible = true;
                        btn_last.Visible = true;
                    }
                    
                }
                rptPages.DataSource = pages;
                rptPages.DataBind(); 
            }
            else
            {
                rptPages.Visible = false;
                DataTable myDatatable = PostOrmDB.SelectTop10ByKeywordId(KeywordId);
                get10Lines.DataSource = myDatatable;
                get10Lines.ItemDataBound += get10Lines_ItemDataBound;
                get10Lines.DataBind();
            }
                

        }

        protected void bnt_Click()
        {
            DataTable myDatatable = PostOrmDB.SelectBy10(KeywordId, PageNumber * 10, 10);
            get10Lines.DataSource = myDatatable;
            get10Lines.ItemDataBound += get10Lines_ItemDataBound;
            get10Lines.DataBind();
        }
        protected void btn_next_Click(object sender, EventArgs e)
        {
            DataTable myDatatable = PostOrmDB.SelectBy10(KeywordId, (PageNumber + 1) * 10, 10);
            get10Lines.DataSource = myDatatable;
            get10Lines.ItemDataBound += get10Lines_ItemDataBound;
            get10Lines.DataBind();
        }

        protected void btn_pre_Click(object sender, EventArgs e)
        {
            DataTable myDatatable = PostOrmDB.SelectBy10(KeywordId, (PageNumber - 1) * 10, 10);
            get10Lines.DataSource = myDatatable;
            get10Lines.ItemDataBound += get10Lines_ItemDataBound;
            get10Lines.DataBind();
        }

        protected void btn_first_Click(object sender, EventArgs e)
        {
            DataTable myDatatable = PostOrmDB.SelectBy10(KeywordId, 0 , 10);
            get10Lines.DataSource = myDatatable;
            get10Lines.ItemDataBound += get10Lines_ItemDataBound;
            get10Lines.DataBind();
        }

        protected void btn_last_Click(object sender, EventArgs e)
        {
            DataTable myDatatable = PostOrmDB.SelectBy10(KeywordId, _pagenumber * 10, 10);
            get10Lines.DataSource = myDatatable;
            get10Lines.ItemDataBound += get10Lines_ItemDataBound;
            get10Lines.DataBind();
        }

        /*
        protected void LoadData()
        {  
            KeywordId = Convert.ToInt32(Request.QueryString["keywordid"]);
            DataTable myDatatable = PostOrmDB.SelectTop10ByKeywordId(KeywordId);
            
            PagedDataSource pgitems = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(myDatatable);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 10;
            pgitems.CurrentPageIndex = PageNumber;

            if (pgitems.PageCount > 1)
            {
                rptPages.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i < pgitems.PageCount; i++)
                {
                    
                    pages.Add((i + 1).ToString());
                }
                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
                rptPages.Visible = false;
            
            get10Lines.DataSource = pgitems;
            //get10Lines.ItemDataBound += get10Lines_ItemDataBound;
            get10Lines.DataBind();
        }
        */
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }
        protected void rptPages_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            Load_Data();
        }

    }
}