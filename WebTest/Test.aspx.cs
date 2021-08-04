using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using WebTest.Models;

namespace WebTest
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var listData = new List<ImportedData>();

            if (TextBox1.Text.Length > 0)
                TextBox1.Text = "";

            try
            {
                var path = Server.MapPath("~/App_Data/Document/test.csv");

                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        listData.Add(new ImportedData(Helper.split(reader.ReadLine(), ',')) { });
                    }
                }
            }
            catch (HttpException hEx)
            {
                Helper.writeLog(hEx);
            }
            catch (ArgumentNullException anEx)
            {
                Helper.writeLog(anEx);
            }
            catch (FileNotFoundException fnfEx)
            {
                Helper.writeLog(fnfEx);
            }
            catch (IOException ioEx)
            {
                Helper.writeLog(ioEx);
            }
            catch (Exception ex)
            {
                Helper.writeLog(ex);
            }

            Session["ImportedData"] = listData;
            GridView1.DataSource = listData;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var showData = new List<ImportedData>();
            var loadData = (List<ImportedData>)Session["ImportedData"];
            var keyword = TextBox1.Text;

            try
            {
                if (keyword.Length > 0)
                {
                    foreach (var entry in loadData)
                    {
                        if (Helper.contains(entry.StringContent, keyword))
                        {
                            entry.MatchTimes++;
                            showData.Add(entry);
                        }
                    }

                    Session["ImportedData"] = loadData;
                    GridView1.DataSource = showData;
                }
                else
                {
                    GridView1.DataSource = loadData;
                }
            }
            catch (Exception ex)
            {
                Helper.writeLog(ex);
            }

            GridView1.DataBind();
        }
    }
}