using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;

namespace WpfDataAnnotations
{
    public class MainViewModel : BaseViewModel
    {
        private EmployeeModel employeeModel;
        private Command changedCommand;

        public EmployeeModel EmployeeModel 
        { 
            get => employeeModel;
            set 
            {
                employeeModel = value;
                OnPropertyChanged(nameof(EmployeeModel));
            }
        }

        public Command ChangedCommand { get => changedCommand ?? (changedCommand = new Command(ChangedAction)); }

        private void ChangedAction(object obj)
        {
            ValidationContext context = new ValidationContext(EmployeeModel, null, null);

            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(EmployeeModel, context, validationResults, true);

            if (!valid)
            {
                Application.Current.Dispatcher.Invoke(() => 
                {
                    foreach (ValidationResult validationResult in validationResults)
                    {
                        Debug.WriteLine(validationResult.ErrorMessage);
                        //MessageBox.Show(validationResult.ErrorMessage);
                    }
                });
            }
        }

        public MainViewModel() 
        {
            EmployeeModel = new EmployeeModel 
            {
                Id = -1,
                Name = "president",
                Age = 200,
                Email = "",
                Department = "xxx",
                Underlings = new int[0] ,
                Token = "xxxx"
            };
        }
    }
}
