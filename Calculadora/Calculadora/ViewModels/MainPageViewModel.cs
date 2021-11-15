using Calculator;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculadora.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        string resultText, operacion;

        public double FirstNumber
        {
            get { return firstNumber; }
            set { if (firstNumber != value)
                    {
                    firstNumber = value;
                        OnPropertyChanged();
                    }
                }
        }
        public double SecondNumber
        {
            get { return secondNumber; }
            set { if (secondNumber != value)
                    {
                    secondNumber = value;
                        OnPropertyChanged();
                    }
                }
        }
        public string Resultado
        {
            get { return resultText; }
            set { if (resultText != value)
                    {
                        resultText = value;
                        OnPropertyChanged();
                    }
                }
        }
        public string Operacion
        {
            get { return operacion; }
            set { if (operacion != value)
                    {
                        operacion = value;
                        OnPropertyChanged();
                    }
                }
        }

        public ICommand OnSelectOperator { protected set; get; }
        public ICommand OnSelectClear { protected set; get; }
        public ICommand OnCalculate { protected set; get; }
        public ICommand OnSelectNumber { protected set; get; }

        public MainPageViewModel()
        {
            OnSelectNumber = new Command<string>(
                execute: (string parameter) =>
                {
                    string pressed = parameter;

                    if (this.Resultado == "0" || currentState < 0)
                    {
                        this.Resultado = "";
                        if (currentState < 0)
                            currentState *= -1;
                    }
                    this.Resultado += pressed;
                    double number;
                    if (double.TryParse(this.Resultado, out number))
                    {
                        this.Resultado = number.ToString("N0");
                        if (currentState == 1)
                        {
                            firstNumber = number;
                        }
                        else
                        {
                            secondNumber = number;
                        }
                    }

                });
            OnSelectClear = new Command(() =>
            {
                firstNumber = 0;
                secondNumber = 0;
                currentState = 1;
                this.Resultado = "0";
            });

            OnSelectOperator = new Command<string>(
            execute: (string parameter) =>
            {
                currentState = -2;
                string pressed = parameter;
                mathOperator = pressed;
            });

            OnCalculate = new Command(() =>
            {
                if (this.currentState == 2)
                {
                    var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);
                    this.Resultado = result.ToString();
                    firstNumber = result;
                    currentState = -1;
                }
            });
        }
    }
}