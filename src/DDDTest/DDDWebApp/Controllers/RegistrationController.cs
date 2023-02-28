using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DDDWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        public UserDO Rigister(string name, PhoneNumber phone) 
        {
            //参数合法性校验已在PhoneNumber中处理
            //参数一致性校验
            TelecomInfoDTO rnInfoDTO = telecomService.GetTelecomInfo(phone.Number);
            if (!name.Equals(rnInfoDTO.Name))
            {
                throw new Exception();
            }

            //计算用户标签
            string label = GetLabel(rnInfoDTO);
            //计算销售组
            string salesRepId = GetSalesRepId(phone);

            //构造User对象和Reward对象
            string idCard = rnInfoDTO.IdCard;
            UserDO userDO = new UserDO(idCard,name,phone.Number,label,salesRepId);

            //检查风控
            if (!riskService.Check(idCard, label)) 
            {
                userDO.New = true;
                rewardDO.Available = false;
            }
            else
            {
                userDO.New = false;
                rewardDO.Available = true;
            }
            //存储信息
            rewardDAO.Insert(rewardDO);
            return userDAO.Insert(userDO);
        }

        private string GetLabel(TelecomInfoDTO dto)
        {
            //....
            return null;
        }

        private string GetSalesRepId(PhoneNumber phone)
        {
            SalesRepDO repDO = salesRepDAO.Select(phone.GetAreaCode(), phone.GetOperatorCode());
            if (repDO != null)
            {
                return repDO.SalesRepId;
            }
            return null;
        }
    }

    public class PhoneNumber
    {
        private string number;
        private string protocol;
        private readonly string pattern = "^0[1-9]{2,3}-?\\d{8}$";

        public string Number { get => number; private set => number = value; }

        public  PhoneNumber(string number) 
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new Exception("number不能为空");
            }
            else if(IsValidPhoneNumber(number))
            {
                throw new Exception("number格式错误");
            }

            Number = number;
        }

        private bool IsValidPhoneNumber(string number)
        {
            string pattern = "^0[1-9]{2,3}-?\\d{8}$";
            return Regex.Match(number, pattern).Success;
        }

        public string GetOperatorCode(string phone)
        {
            //...
            return "1";
        }

        public string GetAreaCode(string phone)
        {
            //...
            return "1";
        }
    }
}
