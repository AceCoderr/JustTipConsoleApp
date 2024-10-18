using JustTipConsoleApp.Models;
using JustTipConsoleApp.Strategy;

namespace JustTipConsoleApp.Controllers
{
    public class MainController
    {
        private Business _business;
        private ITipCalcStrategy _tipCalcStrategy;

        public MainController(ITipCalcStrategy tipCalcStrategy) 
        {
            this._tipCalcStrategy = tipCalcStrategy;
            _business = new Business(_tipCalcStrategy);
        }
        public void AddEmployee(string empName)
        {
            _business.AddEmployee(empName);
        }
        public void CreateRoster(string rosName)
        {
            _business.CreateRoster(rosName);
        }

        public void AssignEmployeesToRoster(string rosName, string empName,DateTime startTime,DateTime endTime)
        {
            _business.AssignEmployeesToRoster(rosName,empName,startTime,endTime);
        }

        public void DistributeTips(string rosName,decimal totalTips)
        {
            _business.DistributeTip(rosName,totalTips);
        }
        public void ChangeStrategy(string option)
        {
            _business.ChangeStrategy(option);
        }
        public void ShowTips()
        {
            _business.ShowTips();
        }


    }
}
