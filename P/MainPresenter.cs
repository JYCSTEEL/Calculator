using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    public class MainPresenter
    {
        public MainView View { get=> MainView.Instance; }
        private BasicSetUpPresenter BasicSetUpPresenter;
        private CalculatorPresenter CalculatorPresenter;
        private DatabaseHelper DatabaseHelper;

        public MainPresenter(MainView mainView) {
            BasicSetUpPresenter = BasicSetUpPresenter.Instance;
            CalculatorPresenter = CalculatorPresenter.Instance;
            DatabaseHelper = DatabaseHelper.Instance;
        }


    }
}
