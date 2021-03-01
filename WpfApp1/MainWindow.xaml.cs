using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// 계산기
namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber; //연산할 때 앞에 입력한 값을 저장하는 변수
        SelectedOperator selectedOperator;
        double result; //연산한 결과 값을 저장하는 변수
        public MainWindow()
        {
            InitializeComponent();
            //각 버튼에 대한 이벤트 함수를 안만들고 아래와 같이 해도 상관 없음.
            //AcButton.Click += AcButton_Click;
        }

        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multipleication,
            Division
        }

        public class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }
            public static double Subtract(double n1, double n2)
            {
                return n1 - n2;
            }
            public static double Multiple(double n1, double n2)
            {
                return n1 * n2;
            }
            public static double Divide(double n1, double n2)
            {
                return n1 / n2;
            }
        }

        // 아래의 이벤트 함수를 쓰려면 xaml에서 Click="numberButton_Click"으로 해줘야 함

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("버튼 눌림");
            int selectedValue = 0;
            if(sender == ZeroButton)
            {
                selectedValue = 0;
                if(resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == OneButton)
            {
                selectedValue = 1;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == TwoButton)
            {
                selectedValue = 2;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == ThreeButton)
            {
                selectedValue = 3;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == FourButton)
            {
                selectedValue = 4;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == FiveButton)
            {
                selectedValue = 5;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == SixButton)
            {
                selectedValue = 6;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == SevenButton)
            {
                selectedValue = 7;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == EightButton)
            {
                selectedValue = 8;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == NineButton)
            {
                selectedValue = 9;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
        }
        //Plus, Minus, Multiple, Divide 4개가 있는 이벤트 함수
        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = double.Parse(resultLabel.Content.ToString());
            resultLabel.Content = "0";

            if (sender == PlusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender == MinusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            if (sender == MultipleButton)
            {
                selectedOperator = SelectedOperator.Multipleication;
            }
            if (sender == DivideButton)
            {
                selectedOperator = SelectedOperator.Division;
            }
        }

        //AC 버튼 클릭
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        //PlusMinus 버튼 클릭
        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        //PlusMinus 버튼 클릭
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * 0.01;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        //Dot 버튼 클릭
        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean a;
            a = resultLabel.Content.ToString().Contains(".");
            if (resultLabel.Content.ToString() == "0")
            {
                return;
            }
            else
            {
                if (a == false)
                {
                    resultLabel.Content += ".";
                }
            }
        }

        //Equl 버튼 클릭
        private void EqulButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            newNumber = double.Parse(resultLabel.Content.ToString());
            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multipleication:
                    result = SimpleMath.Multiple(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }
            resultLabel.Content = result.ToString();
        }

        /*
        //숫자 0 버튼 클릭
        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "0";
            }
            else
            {
                resultLabel.Content += "0";
            }
        }

        //숫자 1 버튼 클릭
        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "1";
            }
            else
            {
                resultLabel.Content += "1";
            }
        }

        //숫자 2 버튼 클릭
        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "2";
            }
            else
            {
                resultLabel.Content += "2";
            }
        }

        //숫자 3 버튼 클릭
        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "3";
            }
            else
            {
                resultLabel.Content += "3";
            }
        }

        //숫자 4 버튼 클릭
        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "4";
            }
            else
            {
                resultLabel.Content += "4";
            }
        }

        //숫자 5 버튼 클릭
        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "5";
            }
            else
            {
                resultLabel.Content += "5";
            }
        }

        //숫자 6 버튼 클릭
        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "6";
            }
            else
            {
                resultLabel.Content += "6";
            }
        }

        //숫자 7 버튼 클릭
        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content += "7";
            }
        }

        //숫자 8 버튼 클릭
        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "8";
            }
            else
            {
                resultLabel.Content += "8";
            }
        }

        //숫자 9 버튼 클릭
        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "9";
            }
            else
            {
                resultLabel.Content += "9";
            }
        }
        */




    }
}
