  private void button2_Click(object sender, EventArgs e)
        {
            string location = @"D:\T\testPlugt.dll";
            TestReflection a = new TestReflection();
            a.Test(location, "Run");
        }
        public class TestReflection
        {
            public void Test(string file, string methodName)
            {
                Assembly assembly = Assembly.LoadFile(file);
                Type type = assembly.GetType("testPlugt.Test");
                if (type != null)
                {
                    MethodInfo methodInfo = type.GetMethod(methodName);
                    if (methodInfo != null)
                    {
                        object result = null;
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        object classInstance = Activator.CreateInstance(type, null);
                        if (parameters.Length == 0)
                        {
                            //This works fine
                            result = methodInfo.Invoke(classInstance, null);
                        }
                        else
                        {
                            object[] parametersArray = new object[] { "Hello" };
                            //The invoke does NOT work it throws "Object does not match target type"             
                            result = methodInfo.Invoke(methodInfo, parametersArray);
                        }
                    }
                }
            }
        }