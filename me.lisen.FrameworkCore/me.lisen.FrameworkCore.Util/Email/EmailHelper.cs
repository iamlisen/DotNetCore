using me.lisen.Bussiness.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace me.lisen.FrameworkCore.Util.Email
{
    /// <summary>
    /// 发送邮件公共方法
    /// </summary>
    public class EmailHelper
    {
        static SysConfig sysConfig = null;
        public static string host;
        public static string from;
        public static string password;
        public static string fromUser;
        static EmailHelper()
        {
            sysConfig = config.ConfigManager.GetValue<SysConfig>();
            host = sysConfig.MailHost;
            from = sysConfig.MailName;
            password = sysConfig.MailPassword;
            fromUser = sysConfig.MailUserName;
        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isHtml">邮件内容是否默认Html格式，默认为true</param>
        /// <param name="encoding">邮件格式，默认UTF-8</param>
        /// <param name="isSSL">是否使用ssl，默认为true</param>
        /// <param name="port">smtp端口，默认为25</param>
        /// <returns></returns>
        public static bool SendEmail(string to, string subject, string body, bool isHtml = true, string encoding = "UTF-8", bool isSSL = true, int port = 25)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(to));
                mailMessage.Subject = subject;
                mailMessage.SubjectEncoding = Encoding.GetEncoding(encoding);
                mailMessage.Body = body;
                mailMessage.BodyEncoding = Encoding.GetEncoding(encoding);
                mailMessage.IsBodyHtml = isHtml;
                mailMessage.From = new MailAddress(fromUser,from);
                SmtpClient smtpClient = new SmtpClient(host, port);
                smtpClient.Credentials = new System.Net.NetworkCredential(fromUser, password);
                smtpClient.Send(mailMessage);
                smtpClient.SendCompleted += SmtpClient_SendCompleted;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 邮件发送完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过启动线程发送邮件，防止阻塞
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isHtml">邮件内容是否默认Html格式，默认为true</param>
        /// <param name="encoding">邮件格式，默认UTF-8</param>
        /// <param name="isSSL">是否使用ssl，默认为true</param>
        /// <param name="port">smtp端口，默认为25</param>
        public static void SendEmailThread(string to, string subject, string body, bool isHtml = true, string encoding = "UTF-8", bool isSSL = true, int port = 25)
        {
            new Thread(() =>
            {
                SendEmail(to, subject, body, isHtml, encoding, isSSL, port);
            }).Start();
        }
    }
}
