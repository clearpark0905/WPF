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
using Oracle.DataAccess.Client;

namespace WpfOracleConTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 네트워크 연결 정보 직접 대입
                string strCon = @"Data Source=XE;User Id=scott;Password=tiger";

                // Oracle 연결
                OracleConnection conn = new OracleConnection(strCon);
                conn.Open();

                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                // SQL문 지정 및 SELECT 실행
                cmd.CommandText = "SELECT * FROM EMP";
                OracleDataReader rdr = cmd.ExecuteReader();

                // 레코드 계속 가져와서 루핑
                List<Emp> emps = new List<Emp>();
                while(rdr.Read())
                {
                    //MessageBox.Show("시작");
                    emps.Add(new Emp()
                    {
                        Ename = rdr.GetString(rdr.GetOrdinal("ENAME")),
                        Empno = rdr.GetInt32(rdr.GetOrdinal("EMPNO"))
                    });
                    //MessageBox.Show("끝");

                }

                ListView01.ItemsSource = emps;

                rdr.Close();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());

            }
        }

        //private void btn_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }

    public class Emp
    {
        public String Ename { get; set;}
        
            
        public int Empno { get; set; }
    }
}
