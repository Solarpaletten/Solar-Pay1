using AspNetCore.Reporting;
using Business.IServices;
using Data.Context;
using Data.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ReportService :IReportService
    {
        private readonly DataContext _dbContext;
        public ReportService(DataContext dataContext)
        {
                _dbContext = dataContext;
        }
        public byte[] GenerateReportAsync(string rfqId)
        {
            string reportName= "InternalCalculations" + "_" + rfq.RFQNumber;
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("RdlcWebApi.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "InternalCalculations", "InternalCalculations.rdlc");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);
			List<ClientContractsDTO> contraccts = (from con in dataContext.Contracts
												   join cc in dataContext.Client_Contract on con.Id equals cc.ContractId
												   join cli in dataContext.Clients on cc.ClientId equals cli.Id
												   where cli.Id == Id
												   select new ClientContractsDTO
												   {
													   ContractId = con.Id.ToString(),
													   ClientId = Id.ToString(),
													   ClientName = cc.Client.FirstName + " " + cc.Client.LastName,
													   Attachment = cc.Attachment,
													   StartDate = cc.ContractStartDate,
													   EndDate = cc.ContractEndDate,
													   ContractName = con.Name,
													   ContractFullForm = con.Fullform
												   }).ToList();
			// prepare data for report
			List<UserDto> userList = new List<UserDto>();

            var user1 = new UserDto { FirstName = "jp", LastName = "jan", Email = "jp@gm.com", Phone = "+976666661111" };
            var user2 = new UserDto { FirstName = "jp2", LastName = "jan", Email = "jp2@gm.com", Phone = "+976666661111" };
            var user3 = new UserDto { FirstName = "முதல் பெயர்", LastName = "கடைசி பெயர்", Email = "jp3@gm.com", Phone = "+976666661111" };
            var user4 = new UserDto { FirstName = "पहला नाम", LastName = "अंतिम नाम", Email = "jp4@gm.com", Phone = "+976666661111" };
            var user5 = new UserDto { FirstName = "jp5", LastName = "jan", Email = "jp5@gm.com", Phone = "+976666661111" };

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);
            userList.Add(user5);

            report.AddDataSource("dsUsers", userList);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(GetRenderType(reportType), 1, parameters);

            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }
    }
}
