using System.Reflection;

namespace SerializerHomework.MySerializers
{
    public class MyStringSerializer
    {
        public static string Serialize<T>(T obj)
        {
            string result = "{";

            var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                string key = field.Name;
                string? value = field.GetValue(obj).ToString();

                if (int.TryParse(value, out int intVal))
                {
                    result += string.Format("\"{0}\":{1}", key, value) + ",";
                }
                else
                {
                    result += string.Format("\"{0}\":\"{1}\"", key, value) + ",";
                }
            }

            result = result.TrimEnd(',') + "}";

            return result;
        }
    }
}
