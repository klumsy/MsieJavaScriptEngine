﻿namespace MsieJavaScriptEngine.Tests.D_Classic
{
	using NUnit.Framework;

	using MsieJavaScriptEngine;

	[TestFixture]
	public class Es5Tests : Es5TestsBase
	{
		[TestFixtureSetUp]
		public override void SetUp()
		{
			_jsEngine = new MsieJsEngine(JsEngineMode.Classic, true, true);
		}

		#region Object methods
		[Test]
		public override void ObjectKeysMethodIsSupported()
		{
			// Arrange
			const string input1 = "Object.keys(['a', 'b', 'c']).toString();";
			const string targetOutput1 = "0,1,2";

			const string input2 = "Object.keys({ 0: 'a', 1: 'b', 2: 'c' }).toString();";
			const string targetOutput2 = "0,1,2";

			const string input3 = "Object.keys({ 100: 'a', 2: 'b', 7: 'c' }).toString();";
			const string targetOutput3 = "100,2,7";

			const string initCode4 = @"var myObj = function() { };
myObj.prototype = { getFoo: { value: function () { return this.foo } } };;
myObj.foo = 1;
";
			const string input4 = "Object.keys(myObj).toString();";
			const string targetOutput4 = "foo";

			// Act
			var output1 = _jsEngine.Evaluate<string>(input1);
			var output2 = _jsEngine.Evaluate<string>(input2);
			var output3 = _jsEngine.Evaluate<string>(input3);

			_jsEngine.Execute(initCode4);
			var output4 = _jsEngine.Evaluate<string>(input4);

			// Assert
			Assert.AreEqual(targetOutput1, output1);
			Assert.AreEqual(targetOutput2, output2);
			Assert.AreEqual(targetOutput3, output3);
			Assert.AreEqual(targetOutput4, output4);
		}
		#endregion
	}
}