using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Globalization;
/* Written By Jonathan Goh
 * https://www.facebook.com/hang2005
 */
namespace BaiduPanGET
{
    public partial class MainForm : Form
    {
        string uk;
        string shareid;
        string app_id;
        string sign;
        string fs_id;
        string bdstoken;
        string link;
        string timestamp;
        CookieContainer objcok = new CookieContainer();
        CookieContainer pwdobj = new CookieContainer();
        string sekey;
        string vcode_str;
        string vcode_img;
        string postData;
        Boolean captchablah;
        Image img;
        /*
         * 
         */
        string dllink;
        string md5;
        string filename;
        public MainForm()
        {
            InitializeComponent();
        }
        public void GetDownloadLink(string link) {
            if(gtpwdCK.Checked == true){
                HttpWebRequest pwdreq = (HttpWebRequest)WebRequest.Create(link);
                ((HttpWebRequest)pwdreq).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36";
                HttpWebResponse pwdresp = (HttpWebResponse)pwdreq.GetResponse();
                Stream pwddataStream = pwdresp.GetResponseStream();
                StreamReader pwdreader = new StreamReader(pwddataStream);
                string pwdresponseFromServer = pwdreader.ReadToEnd();
                pwdreader.Close();
                string location = pwdresp.ResponseUri.ToString();
                Regex pwdregex = new Regex("shareid=(?<shareid>\\d+)");
                Match pwdmatch = pwdregex.Match(location);
                if (pwdmatch.Success)
                {
                    string pwdshareid = pwdmatch.Groups["shareid"].Value;
                    Regex pwdregex2 = new Regex("uk=(?<uk>\\d+)");
                    Match pwdmatch2 = pwdregex2.Match(location);
                    if (pwdmatch2.Success)
                    {
                        string pwduk = pwdmatch2.Groups["uk"].Value;
                        HttpWebRequest pwdreq2 = (HttpWebRequest)WebRequest.Create("http://pan.baidu.com/share/verify?shareid="+pwdshareid+"&uk="+pwduk+"&t=1424035403689&channel=chunlei&clienttype=0&web=1");
                        ((HttpWebRequest)pwdreq2).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36";
                        CookieContainer pwdobjcok = new CookieContainer();
                        int epoch = (int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds;
                        for (int i = 0; i < pwdresp.Cookies.Count; i++)
                        {
                            Cookie http_cookie = pwdresp.Cookies[i];
                            pwdobjcok.Add(new Uri("http://pan.baidu.com"), new Cookie(http_cookie.Name, http_cookie.Value));
                        }
                        pwdobjcok.Add(new Uri("http://pan.baidu.com"), new Cookie("bdshare_firstime", epoch.ToString()));
                        pwdreq2.CookieContainer = pwdobjcok;
                        pwdreq2.KeepAlive = true;
                        ((HttpWebRequest)pwdreq2).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36"; //Set User Agent
                        ((HttpWebRequest)pwdreq2).Headers.Set("X-Requested-With", "XMLHttpRequest"); //Set required Header
                        ((HttpWebRequest)pwdreq2).ContentType = "application/x-www-form-urlencoded; charset=UTF-8"; //Set required Header
                        ((HttpWebRequest)pwdreq2).Referer = link; //Set HTTP Referer
                        ((HttpWebRequest)pwdreq2).Method = "POST";
                        string pwdpostData = "pwd="+pwdTXT.Text+"&vcode=";
                        byte[] pwdbyteArray = Encoding.UTF8.GetBytes(pwdpostData);
                        pwdreq2.ContentLength = pwdbyteArray.Length;
                        Stream pwddataStream3 = pwdreq2.GetRequestStream();
                        pwddataStream3.Write(pwdbyteArray, 0, pwdbyteArray.Length); //Write Post DATA
                        pwddataStream3.Close();
                        HttpWebResponse pwdresp2 = (HttpWebResponse)pwdreq2.GetResponse();
                        for (int i = 0; i < pwdresp2.Cookies.Count; i++)
                        {
                            Cookie http_cookie = pwdresp2.Cookies[i];
                            this.pwdobj.Add(new Uri("http://pan.baidu.com"), new Cookie(http_cookie.Name, http_cookie.Value));
                            if (http_cookie.Name == "BDCLND")
                            {
                                this.sekey = http_cookie.Value;
                            }
                        }
                        Stream pwddataStream2 = pwdresp2.GetResponseStream();
                        StreamReader pwdreader2 = new StreamReader(pwddataStream2);
                        string pwdresponseFromServer2 = pwdreader2.ReadToEnd();
                        Regex regex9 = new Regex("\"errno\":(?<errno>-\\d+)");
                        Match match9 = regex9.Match(pwdresponseFromServer2);
                        pwdreader2.Close();
                        if(match9.Success){
                            if (match9.Groups["errno"].Value == "-20")
                            {
                                MessageBox.Show("Password wrong.");
                            }
                        }
                    }
                }
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36";
            if(gtpwdCK.Checked == true){
                request.CookieContainer = this.pwdobj;
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            Regex regex = new Regex("\"bdstoken\":\"(?<bdstoken>.+?)\"");
            Match match = regex.Match(responseFromServer);
            if (!match.Success)
            {
                Regex regex2 = new Regex("\"sign\":\"(?<sign>.+?)\"");
                Match match2 = regex2.Match(responseFromServer);
                string bdstoken = match.Groups["bdstoken"].Value;
                if (match2.Success)
                {
                    Regex regex3 = new Regex("\"app_id\":\"(?<app_id>.+?)\"");
                    Match match3 = regex3.Match(responseFromServer);
                    string sign = match2.Groups["sign"].Value;
                    if (match3.Success)
                    {
                        Regex regex4 = new Regex("\"timestamp\":(?<timestamp>\\d+)");
                        Match match4 = regex4.Match(responseFromServer);
                        string app_id = match3.Groups["app_id"].Value;
                        if (match4.Success)
                        {
                            string timestamp = match4.Groups["timestamp"].Value;
                            Regex regex6 = new Regex("\"shareid\":(?<shareid>\\d+)");
                            Match match6 = regex6.Match(responseFromServer);
                            if (match6.Success)
                            {
                                string shareid = match6.Groups["shareid"].Value;
                                Regex regex7 = new Regex("\"fs_id\":(?<fs_id>\\d+)");
                                Match match7 = regex7.Match(responseFromServer);
                                if (match7.Success)
                                {
                                    string fs_id = match7.Groups["fs_id"].Value;
                                    Regex regex8 = new Regex("\"uk\":(?<uk>\\d+)");
                                    Match match8 = regex8.Match(responseFromServer);
                                    if (match8.Success)
                                    {
                                        string uk = match8.Groups["uk"].Value;
                                        HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://pan.baidu.com/api/sharedownload?sign=" + sign + "&timestamp=" + timestamp + "&bdstoken=" + bdstoken + "&channel=chunlei&clienttype=0&web=1&app_id=" + app_id);
                                        /*Set Cookie*/
                                        if (gtpwdCK.Checked == true)
                                        {
                                            request2.CookieContainer = this.pwdobj;
                                        }
                                        else
                                        {
                                            CookieContainer objcok = new CookieContainer();
                                            for (int i = 0; i < response.Cookies.Count; i++)
                                            {
                                                Cookie http_cookie = response.Cookies[i];
                                                objcok.Add(new Uri("http://pan.baidu.com"), new Cookie(http_cookie.Name, http_cookie.Value));
                                            }
                                            objcok.Add(new Uri("http://pan.baidu.com"), new Cookie("bdshare_firstime", timestamp));
                                            request2.CookieContainer = objcok;
                                            this.objcok = objcok;
                                        }
                                        /*Set Cookie END*/
                                        request2.KeepAlive = true;
                                        ((HttpWebRequest)request2).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36"; //Set User Agent
                                        ((HttpWebRequest)request2).Headers.Set("X-Requested-With", "XMLHttpRequest"); //Set required Header
                                        ((HttpWebRequest)request2).ContentType = "application/x-www-form-urlencoded; charset=UTF-8"; //Set required Header
                                        ((HttpWebRequest)request2).Referer = LinkTXTBOX.Text; //Set HTTP Referer
                                        ((HttpWebRequest)request2).Method = "POST";
                                        if (gtpwdCK.Checked == true)
                                        {
                                            string postData = "encrypt=0&product=share&uk=" + uk + "&primaryid=" + shareid + "&fid_list=%5B" + fs_id + "%5D&extra=%7B%22sekey%22%3A%22"+this.sekey+"%22%7D";
                                            this.postData = postData;
                                        }
                                        else
                                        { 
                                            string postData = "encrypt=0&product=share&uk=" + uk + "&primaryid=" + shareid + "&fid_list=%5B" + fs_id + "%5D";
                                            this.postData = postData;
                                        }
                                        byte[] byteArray = Encoding.UTF8.GetBytes(this.postData);
                                        request2.ContentLength = byteArray.Length;
                                        Stream dataStream3 = request2.GetRequestStream();
                                        dataStream3.Write(byteArray, 0, byteArray.Length); //Write Post DATA
                                        dataStream3.Close();
                                        WebResponse response2 = request2.GetResponse();
                                        Stream dataStream2 = response2.GetResponseStream();
                                        StreamReader reader2 = new StreamReader(dataStream2);
                                        string responseFromServer2 = reader2.ReadToEnd();
                                        reader2.Close();
                                        Regex regex5 = new Regex("\"dlink\":\"(?<dlink>.+?)\",");
                                        Match match5 = regex5.Match(responseFromServer2);
                                        if (match5.Success)
                                        {
                                            Regex regex10 = new Regex("\"md5\":\"(?<md5>.+?)\",");
                                            Match match10 = regex10.Match(responseFromServer2);
                                            string dlink = match5.Groups["dlink"].Value;
                                            string dlink2 = dlink.Replace("\\", "");
                                            //Dltxt.Text = dlink2;
                                            this.dllink = dlink2;
                                            //CopyBTN.Visible = true;
                                            if(match10.Success){
                                                //md5TXT.Text = match10.Groups["md5"].Value;
                                                this.md5 = match10.Groups["md5"].Value;
                                                Regex regex12 = new Regex("\"server_filename\":\"(?<server_filename>.+?)\"");
                                                Match match12 = regex12.Match(responseFromServer2);
                                                if (match12.Success)
                                                {
                                                   //filenameTXT.Text = match12.Groups["server_filename"].Value;
                                                    this.filename = Decode(match12.Groups["server_filename"].Value);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Get file md5 failed.");
                                            }
                                        }
                                        else
                                        {
                                            Regex regex9 = new Regex("\"errno\":(?<errno>-\\d+)");
                                            Match match9 = regex9.Match(responseFromServer2);
                                            if(match9.Success){
                                                if(match9.Groups["errno"].Value == "-20"){
                                                    HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create("http://pan.baidu.com/api/getcaptcha?prod=share&bdstoken="+bdstoken+"&channel=chunlei&clienttype=0&web=1&app_id="+app_id);
                                                    ((HttpWebRequest)request2).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36"; //Set User Agent
                                                    ((HttpWebRequest)request2).Headers.Set("X-Requested-With", "XMLHttpRequest"); //Set required Header
                                                    WebResponse response3 = request3.GetResponse();
                                                    Stream dataStream4 = response3.GetResponseStream();
                                                    StreamReader reader3 = new StreamReader(dataStream4);
                                                    string responseFromServer3 = reader3.ReadToEnd();
                                                    reader3.Close();
                                                    Regex regex10 = new Regex("\"vcode_str\":\"(?<vcode_str>.+?)\"");
                                                    Match match10 = regex10.Match(responseFromServer3);
                                                    if(match10.Success){
                                                        string vcode_str = match10.Groups["vcode_str"].Value;
                                                        Regex regex11 = new Regex("\"vcode_img\":\"(?<vcode_img>.+?)\"");
                                                        Match match11 = regex11.Match(responseFromServer3);
                                                        if (match11.Success)
                                                        {
                                                            string vcode_img = match11.Groups["vcode_img"].Value;
                                                            string vcode_img2 = vcode_img.Replace("\\","");
                                                            WebRequest req = WebRequest.Create(vcode_img2);
                                                            Stream stream = req.GetResponse().GetResponseStream();
                                                            Image img = Image.FromStream(stream);
                                                            this.img = img;
                                                            this.captchablah = true;
                                                            this.uk = uk;
                                                            this.app_id = app_id;
                                                            this.shareid = shareid;
                                                            this.bdstoken = bdstoken;
                                                            this.fs_id = fs_id;
                                                            this.sign = sign;
                                                            this.link = link;
                                                            this.timestamp = timestamp;
                                                            if (gtpwdCK.Checked != true)
                                                            {
                                                                //this.objcok = objcok;
                                                            }
                                                            this.vcode_str = vcode_str;
                                                            this.vcode_img = vcode_img;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
    }
        public void verifyPWD(string url,string pwd)
        {

        }
        public void GetDownloadLinkCaptcha(string captcha)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://pan.baidu.com/api/sharedownload?sign=" + sign + "&timestamp=" + timestamp + "&bdstoken=" + bdstoken + "&channel=chunlei&clienttype=0&web=1&app_id=" + app_id);
            if (gtpwdCK.Checked == true)
            {
                request.CookieContainer = this.pwdobj;
            }
            else
            {
                request.CookieContainer = objcok;
            }
            request.KeepAlive = true;
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.111 Safari/537.36"; //Set User Agent
            ((HttpWebRequest)request).Headers.Set("X-Requested-With", "XMLHttpRequest"); //Set required Header
            ((HttpWebRequest)request).ContentType = "application/x-www-form-urlencoded; charset=UTF-8"; //Set required Header
            ((HttpWebRequest)request).Referer = LinkTXTBOX.Text; //Set HTTP Referer
            ((HttpWebRequest)request).Method = "POST";
            if (gtpwdCK.Checked == true)
            {
                string postData = "encrypt=0&product=share&uk=" + uk + "&primaryid=" + shareid + "&fid_list=%5B" + fs_id + "%5D&extra=%7B%22sekey%22%3A%22" + this.sekey + "%22%7D&vcode_str=" + vcode_str + "&vcode_input=" + captcha;
                this.postData = postData;
            }
            else
            {
                string postData = "encrypt=0&product=share&uk=" + uk + "&primaryid=" + shareid + "&fid_list=%5B" + fs_id + "%5D&vcode_str=" + vcode_str + "&vcode_input=" + captcha;
                this.postData = postData;
            }
            //string postData = "encrypt=0&product=share&uk=" + uk + "&primaryid=" + shareid + "&fid_list=%5B" + fs_id + "%5D&vcode_str="+vcode_str+"&vcode_input="+captcha;
            byte[] byteArray = Encoding.UTF8.GetBytes(this.postData);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length); //Write Post DATA
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Stream dataStream2 = response.GetResponseStream();
            StreamReader reader2 = new StreamReader(dataStream2);
            string responseFromServer2 = reader2.ReadToEnd();
            reader2.Close();
            Regex regex5 = new Regex("\"dlink\":\"(?<dlink>.+?)\",");
            Match match5 = regex5.Match(responseFromServer2);
            if (match5.Success)
            {
                this.captchablah = false;
                string dlink = match5.Groups["dlink"].Value;
                string dlink2 = dlink.Replace("\\", "");
                this.dllink = dlink2;
                Regex regex10 = new Regex("\"md5\":\"(?<md5>.+?)\"");
                Match match10 = regex10.Match(responseFromServer2);
                if (match10.Success)
                {
                    //md5TXT.Text = match10.Groups["md5"].Value;
                    this.md5 = match10.Groups["md5"].Value;
                    Regex regex11 = new Regex("\"server_filename\":\"(?<server_filename>.+?)\"");
                    Match match11 = regex11.Match(responseFromServer2);
                    if(match11.Success){
                        //filenameTXT.Text = match11.Groups["server_filename"].Value;
                        this.filename = Decode(match11.Groups["server_filename"].Value);

                    }
                }
                else
                {
                    MessageBox.Show("Get file md5 failed.");
                }
            }
            else
            {
                MessageBox.Show("Look like the captcha you input is wrong.Get the link again.");
            }
        }
        private void GetBtn_Click(object sender, EventArgs e)
        {
            if (LinkTXTBOX.Text != "")
            {
                CopyBTN.Visible = false;
                workingLBL.Visible = true;
                worker.RunWorkerAsync();
            }
        }

        private void captchaSub_Click(object sender, EventArgs e)
        {
            workingLBL.Visible = true;
            worker2.RunWorkerAsync();
        }

        private void CopyBTN_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Dltxt.Text);
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetDownloadLink(LinkTXTBOX.Text);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {

            }
            else
            {
                workingLBL.Visible = false;
                if(captchablah == true){
                    MessageBox.Show("Captcha Required.");
                    captchaBox.Image = img;
                    captchaBox.Visible = true;
                    captchaTXT.Visible = true;
                    captchaSub.Visible = true;
                }
                else
                {
                Dltxt.Text = dllink;
                md5TXT.Text = md5;
                filenameTXT.Text = filename;
                CopyBTN.Visible = true;
                }
            }
        }

        private void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {
            
            }
            else
            {
                workingLBL.Visible = false;
                Dltxt.Text = dllink;
                md5TXT.Text = md5;
                filenameTXT.Text = filename;
                CopyBTN.Visible = true;
                captchaBox.Visible = false;
                captchaTXT.Visible = false;
                captchaSub.Visible = false;
            }
        }

        private void worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            GetDownloadLinkCaptcha(captchaTXT.Text);
        }

        private void gtpwdCK_CheckedChanged(object sender, EventArgs e)
        {
            if(gtpwdCK.Checked == true){
                pwdTXT.ReadOnly = false;
            }
            else
            {
                pwdTXT.ReadOnly = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        static Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);

        public static string Decode(string s)
        {
            return reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                {
                    return "" + (char)c;
                }
                return m.Value;
            });
        }

        private void AboutLBL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/hang2005");
        }
    }
}
