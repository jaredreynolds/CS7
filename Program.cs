using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trash
{
    class Program
    {
        static void Main(string[] args)
        {
			try {
				Console.WriteLine($".NET version: {DotNetVersion.Get()}");
				
				var tests = new[] {
					new Test("Read-only Autoproperty", () => new CS6().ReadonlyAutoProperty),
					new Test("Autoproperty Initializer", () => new CS6().AutoPropertyInitializer),
					new Test("Expression-bodied Function Members", () => new CS6().ToString()),
					new Test("Expression-bodied Function Members", () => new CS6().ExpressionBodiedProperty),
					new Test("using static", () => new CS6().UsingStatic),
					new Test("Null Conditional Operator", () => new CS6().NullConditional),
					new Test("String Interpolation", () => new CS6().StringInterpolation),
					new Test("Exception Filter", () => new CS6().ExceptionFilter()),
					new Test("nameof", () => new CS6().Nameof()),
					new Test("Await in Catch and Finally blocks", () => new CS6().AwaitFinally().GetAwaiter().GetResult()),
					new Test("Index Intitializers", () => $"{new CS6().IndexInitializer().Count} items"),
					
					new Test("Inline out Vars", () => new CS7().InlineOutVars()),
					new Test("Better Tuples", () => new CS7().Tuples()),
					new Test("is With Assignment", () => new CS7().IsWithAssignment()),
					new Test("switch With Assignment and Pattern Matching", () => new CS7().SwitchWithPatternMatching()),
					new Test("Local ref", () => new CS7().LocalRefs()),
					new Test("Local Functions", () => new CS7().LocalFns()),
					new Test("More Expression-bodied Members", () => new CS7().MoreExpressionBodiedMembers()),
					new Test("throw Expressions", () => new CS7().ThrowExpressions()),
					new Test("Generalized async return types (ValueTask)", () => new CS7().ValueTasks().ToString()),
					new Test("Numeric literal syntax improvements", () => new CS7().NumericLiteralSyntaxImprovements())
				};
				
				foreach (var test in tests) {
					try {
						Console.WriteLine();
						Console.WriteLine("** " + test.Name);
						Console.WriteLine(test.Run());
					} catch (Exception ex) {
						Console.WriteLine(ex);
					}
				}
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}
        }
    }
	
	public class Test {
		public string Name { get; set; }
		public Func<string> Run { get; set; }
		
		public Test() {
		}
		
		public Test(string name, Func<string> run) {
			this.Name = name;
			this.Run = run;
		}
	}
}
