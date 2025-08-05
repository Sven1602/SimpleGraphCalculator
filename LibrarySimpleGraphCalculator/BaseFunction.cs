namespace LibrarySimpleGraphCalculator
{
    public abstract class BaseFunction
    {
        public string Name { get; set; }

        public BaseFunction(string name) {

            this.Name = name;
        }

        public abstract double Calc(double x);
    }
}
