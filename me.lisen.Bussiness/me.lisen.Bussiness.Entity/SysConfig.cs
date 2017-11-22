using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.lisen.Bussiness.Entity
{
    public class SysConfig
    {
        public string LoginProvider { get; set; } //登陆提供者模式：Session、Cookie
        public string CheckOnLine { get; set; } //允许重复登录
        public string VerifyCodeNum { get; set; }//配置验证码随机数位数
        public string AllowUserRegister { get; set; } //允许用户注册
        public string UseMessage { get; set; } //启用即时通讯
        public string IsLog { get; set; } //启用系统日志
        public string CommandTimeout { get; set; } //数据库超时时间
        public string CacheType { get; set; } //服务器缓存类型:WebCache、Redis
        public string CorpId { get; set; } //企业号
        public string CorpSecret { get; set; }//企业号凭证密钥
        public string FilterIP { get; set; } //设置IP过滤
        public string FilterTime { get; set; } //设置时段过滤
        public string Contact { get; set; } //联系我们
        public string CustomerCompanyName { get; set; } //公司名称
        public string SystemName { get; set; } //系统名称
        public string SoftName { get; set; }//软件名称
        public string Version { get; set; }//版本
        public string RegisterKey { get; set; } //邀请码
        public string ErrorToMail { get; set; } //系统错误自动发送邮件
        public string MailName { get; set; } //发出邮箱的名称
        public string MailUserName { get; set; } //发出邮箱的地址
        public string MailPassword { get; set; }//发出邮箱的密码
        public string MailHost { get; set; } //发出邮箱设置邮箱主机
        public string SMSAccount { get; set; } //短信账户
        public string SMSPswd { get; set; }//短信密码
        public string SMSUrl { get; set; } //短信接口地址
        public string SignalRUrl { get; set; } //SignalR服务接口
    }
}
