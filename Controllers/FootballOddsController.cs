using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tipsternal.Models;

namespace FootballOdds.Controllers
{
    public class FootballOddsController:Controller
    {
        public string Index(string id) { 
           return "<b>Current FootballOdds is :"+id+"</b>";
        }
     
        public string parseJson(){
            CookieContainer cookie = new CookieContainer();
            string oddsJson = SendDataByPost("http://localhost:3000", cookie);
          
            //将json转换成指定对象
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Odds> list =js.Deserialize<List<Odds>>(oddsJson);
            //创建sqlserver链接
            string strconn = "server=localhost;Database=FootballLeagueOdds;uid=admin;pwd=1234";
            SqlConnection conn = new SqlConnection(strconn);//创建链接
            conn.Open();
            //将list保存到数据库
            foreach (Odds obj in list) {

                string title = obj.title;
                string bet_url = obj.bet_url;
                float win_rate = obj.win_rate;
                float draw_rate = obj.draw_rate;
                float lose_rate = obj.lose_rate;
                DateTime match_date = DateTime.Parse("2012-" + obj.match_date);
              
               string sql = "insert into dbo.FootballOdds(title,bet_url,win_rate,draw_rate,lose_rate,match_date)"
                + " values('"+ title + "','" + bet_url + "','" + win_rate + "','" + draw_rate + "','" + lose_rate + "','" + match_date + "')";
               SqlCommand cmd = new SqlCommand(sql, conn);
              cmd.ExecuteScalar();

            }
            conn.Close();

            return "存儲成功";
        }

 
        public string SendDataByPost(string Url, CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Timeout = 1000000;
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";     

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}