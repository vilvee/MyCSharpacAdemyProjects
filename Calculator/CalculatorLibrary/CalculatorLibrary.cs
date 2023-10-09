
using System.Text;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public enum Operation
    { 
        Add = 1,
        Subtract,
        Multiply,
        Divide,
        Power,
        SquareRoot,
        TenX,
        Sine,
        Cosine,
        Tangent, 
        Cotangent,
        Secant,
        Cosecant
    }

    public class Calculator
    {
        JsonWriter writer;
        private List<string> calculationHistory = new List<string>(); // store history
        public int TimesUsed { get; private set; }

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
            TimesUsed = 0;
            calculationHistory = new List<string>();
        }

        public double DoOperation(double num1, Operation op, double? num2 = null)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);

            if(num2 != null)
            {
                writer.WritePropertyName("Operand2");
                writer.WriteValue(num2);
            }

            writer.WritePropertyName("Operation");

            // Use a switch statement to do the math.
            switch (op)
            {
                case 1:
                    result = num1 + num2.Value;
                    writer.WriteValue(Operation.Add);
                    break;
                case 2:
                    result = num1 - num2.Value;
                    writer.WriteValue(Operation.Subtract);
                    break;
                case 3:
                    result = num1 * num2.Value;
                    writer.WriteValue(Operation.Multiply);
                    break;
                case 4:
                    if (num2 != 0)
                    {
                        result = num1 / num2.Value;
                    }
                    writer.WriteValue(Operation.Divide);
                    break;
                case 5:
                    result = Math.Pow(num1, num2.Value);
                    writer.WriteValue(Operation.Power);
                    break;
                case 6:
                    result = Math.Sqrt(num1);
                    writer.WriteValue(Operation.SquareRoot);
                    break;
                case 7:
                    result = num1 * 10;
                    writer.WriteValue(Operation.TenX);
                    break;
                case 8:
                    result = Math.Sin(num1);
                    writer.WriteValue(Operation.Sine);
                    break;
                case 9:
                    result = Math.Cos(num1);
                    writer.WriteValue(Operation.Cosine);
                    break;
                case 10:
                    result = Math.Tan(num1);
                    writer.WriteValue(Operation.Tangent);
                    break;
                case 11:
                    result = 1 / Math.Tan(num1);
                    writer.WriteValue(Operation.Cotangent);
                    break;
                case 12:
                    result = 1 / Math.Cos(num1);
                    writer.WriteValue(Operation.Secant);
                    break;
                case 13:
                    result = 1/ Math.Sin(num1);
                    writer.WriteValue(Operation.Cosecant);
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            
            TimesUsed++;

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            StoreCalculationHistory(num1, op, result, num2);

            return result;
        }

        public double RetrieveCalculationFromHistory(int num)
        {
            string entry = calculationHistory[num - 1];

            return Convert.ToDouble(entry.Split( " ").Last());
        }


        public void StoreCalculationHistory(double num1, int op, double result, double? num2 = null)
        {
 
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Operation: {0}\n", (Operation)op);
            sb.AppendFormat("Operand 1: {0}\n", num1);

            if (num2 != null)
            {
                sb.AppendFormat("Operand 2: {0}\n", num2);
            }
            
            sb.AppendFormat("Result: {0}\n", result);

            calculationHistory.Add(sb.ToString());
        }

        public void PrintHistory() => calculationHistory.ForEach(entry => Console.WriteLine($"[{calculationHistory.IndexOf(entry) + 1}] {entry}"));
        
        public void DeleteHistory() => calculationHistory.Clear();

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}