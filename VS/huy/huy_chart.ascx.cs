using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Orm.Interns.DatabaseInteracts;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;

namespace Orm.Interns.huy
{
    public partial class huy_chart : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /* get data
             */
            DataTable dt = PostOrmDB.GetTop10MentionKeyword();

            var query = dt.AsEnumerable()
                .GroupBy(row => new
                {
                    Text = row.Field<string>("keyword_value"),
                    Keyword = row.Field<int>("KeywordId"),
                    Senti = row.Field<int>("SentiLabel")
                })
                .Select(grp => new
                { 
                    Text = grp.Key.Text,
                    Keyword = grp.Key.Keyword,
                    Senti = grp.Key.Senti,
                    Count = grp.Count()
                });

            List<string> ltext = new List<string>();
            List<string> lkeyword = new List<string>();
            List<int> lpos = new List<int>();
            List<int> lnor = new List<int>();
            List<int> lneg = new List<int>();

            /* 
             * get value of pos/nor/neg 
             */
            /*
            foreach (var senti in query)
            {
                    if (!lkeyword.Contains(senti.Keyword.ToString()))
                    {
                        lkeyword.Add(senti.Keyword.ToString());

                        if (senti.Senti == 0 || senti.Senti == 1)
                        {
                            lneg.Add(senti.Count);
                        }
                        else{
                            lneg.Add(0);
                        }
                        if (senti.Senti == 2)
                        {
                            lnor.Add(senti.Count);
                        }
                        else{
                            lnor.Add(0);
                        }

                        if (senti.Senti == 3 || senti.Senti == 4)
                        {
                            lpos.Add(senti.Count);
                        }
                        else
                        {
                            lpos.Add(0);
                        }

                    }
                    else
                    {
                        if (senti.Senti == 0 || senti.Senti == 1)
                        {
                            lneg[lneg.Count-1]=senti.Count;
                        }

                        if (senti.Senti == 2)
                        {
                            lnor[lnor.Count - 1] = senti.Count;
                        }

                        if (senti.Senti == 3 || senti.Senti == 4)
                        {
                            lpos[lpos.Count - 1] = senti.Count;
                        }

                    }

            }
             * */

            foreach (var senti in query)
            {
                if (!ltext.Contains(senti.Text))
                {
                    ltext.Add(senti.Text);

                    if (senti.Senti == 0 || senti.Senti == 1)
                    {
                        lneg.Add(senti.Count);
                    }
                    else
                    {
                        lneg.Add(0);
                    }
                    if (senti.Senti == 2)
                    {
                        lnor.Add(senti.Count);
                    }
                    else
                    {
                        lnor.Add(0);
                    }

                    if (senti.Senti == 3 || senti.Senti == 4)
                    {
                        lpos.Add(senti.Count);
                    }
                    else
                    {
                        lpos.Add(0);
                    }

                }
                else
                {
                    if (senti.Senti == 0 || senti.Senti == 1)
                    {
                        lneg[lneg.Count - 1] = senti.Count;
                    }

                    if (senti.Senti == 2)
                    {
                        lnor[lnor.Count - 1] = senti.Count;
                    }

                    if (senti.Senti == 3 || senti.Senti == 4)
                    {
                        lpos[lpos.Count - 1] = senti.Count;
                    }

                }

            }

            List<string> lstr = new List<string>();
            /*
            foreach (var item in lkeyword)
            {
                lstr.Add(item.ToString());
            }
            */
            foreach (var item in ltext)
            {
                lstr.Add(item);
            }

            //string[] o_keyword = lstr.ToArray();
            string[] o_text = lstr.ToArray();
            object[] o_neg = lneg.Cast<object>().ToArray();
            object[] o_nor = lnor.Cast<object>().ToArray();
            object[] o_pos = lpos.Cast<object>().ToArray();


            /* Display chart
             * 
             */
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
            .InitChart(new Chart { DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Bar })
            .SetTitle(new Title { Text = "Distribution of Top 10 Keywords In A Week" })
            //.SetXAxis(new XAxis { Categories = o_keyword })
            .SetXAxis(new XAxis { Categories = o_text })
            .SetPlotOptions(new PlotOptions { Column = new PlotOptionsColumn { Stacking = Stackings.Normal } })
            .SetSeries(new[]
                       {
                           new Series { Name = "Negative", Data = new Data(o_neg) },
                           new Series { Name = "Normal", Data = new Data(o_nor) },
                           new Series { Name = "Positive", Data = new Data(o_pos) }
                       });

            huyChart.Text = chart.ToHtmlString();



        }

    }

}