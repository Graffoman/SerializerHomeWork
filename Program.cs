using SerializerHomework;
using SerializerHomework.FilesAndClassesToSerialize;
using SerializerHomework.MySerializers;
using SerializerHomework.TestClasses;
using System.Text.Json;

int iterations = 10000000;

var testClass = new F().Get();

Console.WriteLine(MyStringSerializer.Serialize(testClass));

var timer = new MyTimer<MyClass>(iterations);

var info = timer.MeasureTime(() => MyStringSerializer.Serialize(testClass), "MyStringSerializer On F class");
Console.WriteLine(info);

info = timer.MeasureTime(() => JsonSerializer.Serialize(testClass), "JsonSerializer On F class");
Console.WriteLine(info);


var rowsToDeserialize = File.ReadAllLines(@"FilesAndClassesToSerialize\myClass.csv");
var myCsvSerializer = new MyCsvSerializer(";");

info = timer.MeasureTime(() => myCsvSerializer.Deserialize<MyClass>(rowsToDeserialize), "MyCsvSerializer On csv file");
Console.WriteLine(info);

var myClass = myCsvSerializer.Deserialize<MyClass>(rowsToDeserialize);

info = timer.MeasureTime(() => MyStringSerializer.Serialize(myClass), "MyStringSerializer On MyClass");
Console.WriteLine(info);
