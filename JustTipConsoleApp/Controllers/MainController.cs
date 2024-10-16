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
        public void AddEmployee()
        {
            _business.AddEmployee();
        }
        public void CreateRoster()
        {
            _business.CreateRoster();
        }

        public void AssignEmployeesToRoster(string rosName, string empName)
        {
            _business.AssignEmployeesToRoster(rosName,empName);
        }

        public void DistributeTips()
        {
            
        }
    }
}
