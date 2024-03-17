using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MCcircuit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            ScanChart.Visible = false;
            Globals.inputs.Clear();
            string input = InputTextBox.Text;
            Globals.myGate = new Gate(input);
            //MessageBox.Show(Globals.inputs.Count + "");
            Globals.CheckAllBitInpts();
            List<string> results = new List<string>(Globals.FindHazards());
            PrintHazards(results);

            Globals.GenerateStrings(Globals.inputs.Count);
            Globals.GetResolutions("0u1u");
            //MessageBox.Show(Globals.inputs.Count + "");
        }

        void PrintHazards(List<string> results)
        {

            outputTextBox.Clear();
            outputTextBox.AppendText("Found " +results.Count+ " out of " + Globals.combinations.Count);
            outputTextBox.AppendText(Environment.NewLine);
            string line = "";
            for (int i = 0; i < Globals.inputs.Count; i++)
            {
                line += Globals.inputs[i].rep + "\t";
            }
            outputTextBox.AppendText(line);
            outputTextBox.AppendText(Environment.NewLine);
            for (int i = 0; i < results.Count; i++)
            {
                line = "";
                for (int j = 0; j < results[i].Length; j++)
                {
                    line += results[i][j] + "\t";
                }
                outputTextBox.AppendText(line);
                outputTextBox.AppendText(Environment.NewLine);

            }
        }

        private void PrecentButton_Click(object sender, EventArgs e)
        {
            ScanChart.Visible = false;
            outputTextBox.Clear();
            try
            {
                double precent = double.Parse(PrecentTextBox.Text);
                if(precent <= 0 || precent > 1)
                {
                    throw new Exception();
                }
                Globals.inputs.Clear();
                string input = InputTextBox.Text;
                Globals.myGate = new Gate(input);

                Globals.combinations.Clear();
                Globals.combinations = Globals.GenerateStrings(Globals.inputs.Count);
                //int amount = (int)(Globals.combinations.Count*precent);
                //Globals.combinations = Globals.GetRandomElements(Globals.combinations,amount);
                Globals.combinations = Globals.FilterListRandomly(Globals.combinations, precent);
                List<string> results = new List<string>(Globals.FindHazards());
                if(results.Count > 0)
                {
                    outputTextBox.AppendText("This Circuit found hazard using " + precent + " of the inputs");
                    PrintHazards(results);
                }
                else
                {
                    outputTextBox.AppendText("This Circuit is " + precent + " Hazard Free");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("bad input");
            }
            
        }
        private void DisplayGraph(Dictionary<double, int> hazardCounts)
        {
            ScanChart.Series.Clear();
            ScanChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ScanChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            var series = ScanChart.Series.Add("Hazards");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            foreach (var kvp in hazardCounts)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);
            }

            ScanChart.ChartAreas[0].AxisX.Title = "Percentage";
            ScanChart.ChartAreas[0].AxisY.Title = "Count";
            ScanChart.ChartAreas[0].RecalculateAxesScale();
        }
        private void ScanButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Clear();
            Dictionary<double, int> hazardCounts = new Dictionary<double, int>();
            StringBuilder resultsMessage = new StringBuilder();
            for (double percent = 0.01; percent <= 0.99; percent += 0.01)
            {
                int countForCurrentPercent = 0;
                int hazardCount = 0;
                for (int trial = 0; trial < 1000; trial++)
                {
                    Globals.inputs.Clear();
                    string input = InputTextBox.Text;
                    Globals.myGate = new Gate(input);

                    Globals.combinations.Clear();
                    Globals.combinations = Globals.GenerateStrings(Globals.inputs.Count);
                    Globals.combinations = Globals.FilterListRandomly(Globals.combinations, percent);
                    List<string> results = new List<string>(Globals.FindHazards());

                    if (results.Count > 0)
                    {
                        hazardCount++;
                        countForCurrentPercent++;
                    }
                }
                resultsMessage.AppendLine($"For {percent * 100}%: Hazards > 0 in {hazardCount} out of 1000 trials.");
                hazardCounts[percent] = countForCurrentPercent;
            }
            outputTextBox.AppendText(resultsMessage.ToString());
            DisplayGraph(hazardCounts);
            ScanChart.Visible = true;
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            this.lastLocation = e.Location;
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                this.Location = new Point((this.Location.X - this.lastLocation.X) + e.X,(this.Location.Y - this.lastLocation.Y) + e.Y);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public enum Value
    {
        Val_0,
        Val_1,
        Val_u,
        NA,
    }

    public enum LogicGate
    {
        OR,
        AND,
        NOT,
        INPUT,
    }


    public static class Globals
    {
        public static Gate myGate;
        public static List<Gate> inputs = new List<Gate>();
        public static List<string> combinations = new List<string>();
        public static List<Value> outputs = new List<Value>();
        public static void InsertGate(Gate gt)
        {
            bool flag = true;
            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].rep == gt.rep)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                inputs.Add(gt);
            }

        }

        public static List<T> GetRandomElements<T>(List<T> list, int count)
        {
            Random random = new Random();
            return list.OrderBy(item => random.Next()).Take(count).ToList();
        }

        public static List<T> FilterListRandomly<T>(List<T> list, double e)
        {
            List<T> result = new List<T>();
            Random random = new Random();

            foreach (T item in list)
            {
                if (random.NextDouble() <= e) // random.NextDouble() returns a double between 0.0 and 1.0
                {
                    result.Add(item);
                }
            }

            return result;
        }
        public static void InsertValues(string values)
        {
            if(values.Length != inputs.Count)
            {

            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    switch(values[i])
                    {
                        case '0':
                            inputs[i].val = Value.Val_0;
                            break;
                        case '1':
                            inputs[i].val = Value.Val_1;
                            break;
                        case 'u':
                            inputs[i].val = Value.Val_u;
                            break;
                        default:
                            inputs[i].val = Value.NA;
                            break;
                    }

                }
            }
        }

        public static Value GetOutput(Gate gt)
        {
            if(gt.gateType == LogicGate.INPUT)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if(gt.rep == inputs[i].rep)
                    {
                        gt.val = inputs[i].val;
                        break;
                    }
                }
                return gt.val;
            }
            else if(gt.gateType == LogicGate.NOT)
            {
                switch(GetOutput(gt.input1))
                {
                    case Value.Val_0:
                        gt.val = Value.Val_1;
                        break;
                    case Value.Val_1:
                        gt.val = Value.Val_0;
                        break;
                    case Value.Val_u:
                        gt.val = Value.Val_u;
                        break;
                }
                return gt.val;
               
            }
            else if(gt.gateType == LogicGate.OR)
            {
                GetOutput(gt.input1);
                GetOutput(gt.input2);
                if(gt.input1.val == Value.Val_1 || gt.input2.val == Value.Val_1)
                {
                    gt.val = Value.Val_1;
                }
                else if(gt.input1.val == Value.Val_0 && gt.input2.val == Value.Val_0)
                {
                    gt.val = Value.Val_0;
                }
                else
                {
                    gt.val = Value.Val_u;
                }
                return gt.val;
            }
            else
            {
                GetOutput(gt.input1);
                GetOutput(gt.input2);
                if (gt.input1.val == Value.Val_0 || gt.input2.val == Value.Val_0)
                {
                    gt.val = Value.Val_0;
                }
                else if (gt.input1.val == Value.Val_1 && gt.input2.val == Value.Val_1)
                {
                    gt.val = Value.Val_1;
                }
                else
                {
                    gt.val = Value.Val_u;
                }
                return gt.val;
            }
        }

        public static void generateGrayarr(int n)
        {
            combinations.Clear();
            // base case  
            if (n <= 0)
            {
                return ;
            }

            // 'arr' will store all generated codes  
            List<string> arr = new List<string>();

            // start with one-bit pattern  
            arr.Add("0");
            arr.Add("1");

            // Every iteration of this loop generates 2*i codes from previously  
            // generated i codes.  
            int i, j;
            for (i = 2; i < (1 << n); i = i << 1)
            {
                // Enter the previously generated codes again in arr[] in reverse  
                // order. Nor arr[] has double number of codes.  
                for (j = i - 1; j >= 0; j--)
                {
                    arr.Add(arr[j]);
                }

                // append 0 to the first half  
                for (j = 0; j < i; j++)
                {
                    arr[j] = "0" + arr[j];
                }

                // append 1 to the second half  
                for (j = i; j < 2 * i; j++)
                {
                    arr[j] = "1" + arr[j];
                }
            }

            // print contents of arr[]  
            for (i = 0; i < arr.Count; i++)
            {
                combinations.Add(arr[i]);
                //Console.WriteLine(arr[i]);
            }
        }
        public static void CheckAllBitInpts()
        {
            combinations.Clear();
            //generateGrayarr(inputs.Count);
            combinations = GenerateStrings(inputs.Count);
            outputs.Clear();
            int size = (int)Math.Pow(2, inputs.Count);
            for (int i = 0; i < combinations.Count; i++)
            {           
                InsertValues(combinations[i]);
                outputs.Add(GetOutput(myGate));
            }
            return;
        }
        public static int FindCombo(string rep)
        {
            for (int i = 0; i < combinations.Count; i++)
            {
                if (combinations[i] == rep)
                {
                    return i;
                }
            }
            return 0;
        }
        public static List<string> FindHazards()
        {
            List<string> result = new List<string>();
            List<string> temp = new List<string>();
            for (int i = 0; i < combinations.Count - 1; i++)
            {
                string hazInput = combinations[i];
                string compare = "";
                Value tempVal = Value.NA;
                Value tempVal2 = Value.NA;
                bool isSame = true;


                if (hazInput.Contains("u"))
                {
                    temp = GetResolutions(combinations[i]);
                    for (int j = 0; j < temp.Count; j++)
                    {
                        InsertValues(temp[j]);
                        tempVal2 = GetOutput(myGate);
                        if(tempVal2 != tempVal && tempVal != Value.NA)
                        {
                            isSame = false;
                        }
                        tempVal = tempVal2;

                    }
                    if(isSame)
                    {
                        InsertValues(hazInput);
                        if(GetOutput(myGate) == Value.Val_u)
                        {
                             result.Add(hazInput);
                        }
                    }
                }
                //char[] temp;
                //for (int j = 0; j < combinations[i].Length; j++)
                //{
                //    hazInput = combinations[i];
                //    compare = hazInput.Substring(0, j) + (((int.Parse(hazInput[j] + "")) + 1) % 2) + hazInput.Substring(j + 1);
                //    int index = FindCombo(compare);
                //    if (outputs[i] == outputs[index])
                //    {
                //        for (int k = 0; k < combinations[i].Length; k++)
                //        {
                //            if (combinations[i][k] != combinations[index][k])
                //            {
                //                hazInput = hazInput.Substring(0, k) + 'u' + hazInput.Substring(k + 1);
                //            }
                //            InsertValues(hazInput);
                //            if (GetOutput(myGate) == Value.Val_u)
                //            {
                //                bool flag = true;
                //                for (int l = 0; l < result.Count; l++)
                //                {
                //                    if (result[l] == hazInput)
                //                    {
                //                        flag = false;
                //                    }
                //                }
                //                if(flag)
                //                {
                //                    result.Add(hazInput);
                //                }
                                    
                //            }
                //        }
                //    }                     
                    
                //}
            }
            return result;
        }

        public static List<string> GenerateStrings(int n)
        {
            List<string> result = new List<string>();
            GenerateStringsHelper(n, "", result);
            return result;
        }

        public static List<string> GetResolutions(string input)
        {
            List<string> resolutions = new List<string>();
            GetResolutionsHelper(input.ToCharArray(), 0, resolutions);
            return resolutions;
        }

        public static void GetResolutionsHelper(char[] chars, int index, List<string> resolutions)
        {
            if (index == chars.Length)
            {
                resolutions.Add(new string(chars));
                return;
            }

            if (chars[index] == 'u')
            {
                chars[index] = '0';
                GetResolutionsHelper(chars, index + 1, resolutions);

                chars[index] = '1';
                GetResolutionsHelper(chars, index + 1, resolutions);

                chars[index] = 'u'; // Reset to 'u' for backtracking
            }
            else
            {
                GetResolutionsHelper(chars, index + 1, resolutions);
            }
        }

        public static void GenerateStringsHelper(int n, string currentString, List<string> result)
        {
            if (n == 0)
            {
                result.Add(currentString);
                return;
            }

            GenerateStringsHelper(n - 1, currentString + '0', result);
            GenerateStringsHelper(n - 1, currentString + '1', result);
            GenerateStringsHelper(n - 1, currentString + 'u', result);
        }


    }
    public class Gate
    {
        public string rep;
        public Gate input1;
        public Gate input2;
        public Value val;
        public LogicGate gateType;

        public Gate()
        {

        }

        public Gate(string rep)
        {
            this.rep = rep;
            if (rep.Length == 1)
            {
                this.rep = rep;
                gateType = LogicGate.INPUT;
                this.val = Value.NA;
                Globals.InsertGate(this);
            }
            else if (rep.EndsWith("`"))
            {
                this.rep = rep;
                gateType = LogicGate.NOT;
                this.val = Value.NA;
                input1 = new Gate(rep.Substring(1, rep.Length - 3));
            }
            else
            {
                int count_1 = 0;
                int count_2 = 0;
                char lg;
                string part_1 = "";
                string part_2 = "";
                if (rep[0] != '(')
                {

                }
                for (int i = 0; i < rep.Length; i++)
                {
                    if (rep[i] == '(')
                    {
                        count_1++;
                    }
                    else if (rep[i] == ')')
                    {
                        count_2++;
                    }
                    if (count_1 == count_2)
                    {
                        if (rep[i + 1] == '`')
                        {
                            part_1 = rep.Substring(1, i);
                            lg = rep[i + 2];
                            part_2 = rep.Substring(i + 4, rep.Length - (i + 5));
                        }
                        else
                        {
                            part_1 = rep.Substring(1, i - 1);
                            lg = rep[i + 1];
                            part_2 = rep.Substring(i + 3, rep.Length - (i + 4));
                            
                        }
                        switch (lg)
                        {
                            case '+':
                                this.gateType = LogicGate.OR;
                                break;
                            case '*':
                                this.gateType = LogicGate.AND;
                                break;
                            default:
                                this.gateType = LogicGate.INPUT;
                                break;
                        }
                        break;

                    }
                }
                input1 = new Gate(part_1);
                input2 = new Gate(part_2);
            }
        }
    }
}
